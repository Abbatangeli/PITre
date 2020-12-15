﻿// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using Foundation;
using InformaticaTrentinaPCL.CommonAction.MVP;
using InformaticaTrentinaPCL.Home;
using InformaticaTrentinaPCL.Home.MVPD;
using InformaticaTrentinaPCL.iOS.Helper;
using InformaticaTrentinaPCL.iOS.Login.Session;
using InformaticaTrentinaPCL.iOS.TabBar.Document.Common.Storyboard;
using InformaticaTrentinaPCL.Signature;
using InformaticaTrentinaPCL.Signature.MVP;
using InformaticaTrentinaPCL.Utils;
using UIKit;
using static InformaticaTrentinaPCL.Home.Network.LibroFirmaResponseModel;

namespace InformaticaTrentinaPCL.iOS.TabBar.Document.Action.Root.Storyboard
{
	/// <summary>
	/// UIVControllerSign si occupa di gestire il flusso dei documenti da firmare . Implementa un interfaccia "ActionCommonInterface" in comune con gli
	/// altri tipi di documenti. 
	/// 
	/// </summary>
	public partial class UIVControllerSign : UIViewController
    {
        #region variabili 
		public AbstractDocumentListItem model;
        private const string NAME_CLASS = "UIVControllerSign";
        public ActionType actionType;
        private SignaturePresenter presenter;
        private ControllerDetailAction common;
        private int TotalRecordCountSigned = 0;
        private List<AbstractDocumentListItem> listOtp;
        private SignFlowType signFlowType;
        private string signType;
        #endregion

		#region func class
		public UIVControllerSign(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Configures for sign otp.
        /// </summary>
        /// <param name="list">List.</param>
        /// <param name="actionType">Action type.</param>
        /// <param name="TotalRecordCountSigned">Total record count signed.</param>
        public void ConfigureForSignOtp(List<AbstractDocumentListItem> list, ActionType actionType, int TotalRecordCountSigned, string signType, SignFlowType signFlowType)
        {
            this.actionType = actionType;
            this.TotalRecordCountSigned = TotalRecordCountSigned;
            this.listOtp = list;
            this.signType = signType;
            this.signFlowType = signFlowType;
        }

        private void SetPresenter()
        {
            presenter = new SignaturePresenter(common, IosNativeFactory.Instance());
            presenter.OnViewReady();
            presenter.UpdateAlias(IosNativeFactory.Instance().GetSessionData().userInfo.signConfiguration.alias);
            presenter.UpdateDomain(IosNativeFactory.Instance().GetSessionData().userInfo.signConfiguration.dominio);
        }

        private void ConfigurationNavigation()
        {
            ActionNavigationType[] buttons = { ActionNavigationType.ActionBack };
            Navigation.NavigationCustom(Utility.LanguageConvert("signDocumentTitle"), this, buttons, null, (obj) =>
            {
                if (obj == ActionNavigationType.ActionTabletClose)
                {
                    DismissViewController(true, null);
                }
                else if (obj == ActionNavigationType.ActionTabletBack)
                {
                    DismissViewController(true, null);
                }
                else
                {
                    NavigationController.PopViewController(true);
                }
            });
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetPresenter();
            ConfigurationNavigation(); 
		}

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            ConfigureTablet();
        }

        private void ConfigureTablet()
        {
            this.left.Constant = StyleTablet.WidthCommonPresentation(this.View);
            this.right.Constant = StyleTablet.WidthCommonPresentation(this.View);
            this.bottom.Constant = StyleTablet.TopKeyboard();
            this.top.Constant = StyleTablet.TOP_FROM_NAVIGATION;
        }

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

            if (segue.DestinationViewController is ControllerDetailAction)
            {
                common = (ControllerDetailAction)segue.DestinationViewController;
                common.ConfigureSign(Callback);
                common.ConfigureModel(model, actionType);
            }
		}

        private void Callback(SupporTypeAction action, String note, Dictionary<string, string> extra)
        {
            if (action == SupporTypeAction.REQUEST_OTP)
            {
                presenter?.RequestOTP();
            }
            else if (action == SupporTypeAction.UPDATE_TEXT_PIN)
            {
                presenter?.UpdatePIN(note);
            }
            else if (action == SupporTypeAction.UPDATE_TEXT_OTP)
            {
                presenter?.UpdateOTP(note);
            }
            else if (action == SupporTypeAction.UPDATE_TEXT_DOMINIO)
            {
                presenter?.UpdateDomain(note);
            }
            else if (action == SupporTypeAction.UPDATE_TEXT_CODICE_FISCALE)
            {
                presenter?.UpdateAlias(note);
            }
            else if (action == SupporTypeAction.ACTION_DONE)
            {
                if (actionType.Equals(ActionType.VIEW_OTP))
                {
                    presenter?.SignDocumentsHSM(this.listOtp, signFlowType);
                }
                else
                {
                    presenter?.SignDocument(model);
                }
            }
            else if (action == SupporTypeAction.ACTION_COMPLETE)
            {
                UIViewControllerDocumentList.signFlowFinishedType = signType;
                Alert.PopUpStateDocument(Home.Network.SectionType.SIGN, this, ActionType.SIGN, extra);
            }
        }
        #endregion
    }
}
