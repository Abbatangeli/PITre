// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using InformaticaTrentinaPCL.Assegna;
using InformaticaTrentinaPCL.Assegna.MVPD;
using InformaticaTrentinaPCL.CommonAction.MVP;
using InformaticaTrentinaPCL.Home;
using InformaticaTrentinaPCL.Home.MVPD;
using InformaticaTrentinaPCL.Interfaces;
using InformaticaTrentinaPCL.iOS.EmbedComponent;
using InformaticaTrentinaPCL.iOS.Helper;
using InformaticaTrentinaPCL.iOS.Login.Session;
using InformaticaTrentinaPCL.iOS.TabBar.Document.Action.Assign.Storyboard;
using InformaticaTrentinaPCL.Utils;
using UIKit;

namespace InformaticaTrentinaPCL.iOS.TabBar.Document.Action.Root.Storyboard
{
    /// <summary>
    /// è il controller dove viene implementato tutta la logica di assign 
    /// </summary>
    public partial class UIVControllerAssign : UIViewController
    {
		#region Variables of class
		public AbstractDocumentListItem AbstractDocumentListItem;
		public ActionType actionType;
        private UIVControllerSearchAssign searchAssign;
        private AbstractRecipient chooseAssign;
        private AssegnaPresenter presenter;
        private ControllerDetailAction common;
		#endregion

		#region UIVControllerAssign
		public UIVControllerAssign(IntPtr handle) : base(handle)
        {
        }

        private void ConfigureNavigation()
        {
            ActionNavigationType[] buttons = { ActionNavigationType.ActionBack };
            Navigation.NavigationCustom(actionType.titleBar, this, buttons, null, (obj) =>
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
                    this.NavigationController.PopViewController(true);
            });
        }

        private void ConfigurePresenter()
        {
            presenter = new AssegnaPresenter(common, IosNativeFactory.Instance(), AbstractDocumentListItem);
            presenter.OnViewReady();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ConfigureNavigation();
            ConfigurePresenter();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
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

                String desc = Utility.LanguageConvert("selected_delega");
                if (actionType == ActionType.ASSIGN)
                    desc = Utility.LanguageConvert("selected_assign");

                common.ConfigureAssignChoose(Utility.LanguageConvert("title_assign_to"),desc,Callback);
			}
			else if (segue.DestinationViewController is UIVControllerSearchAssign)
            {
				searchAssign = (UIVControllerSearchAssign)segue.DestinationViewController;
                searchAssign.CallbackSetAssign = Callback_ACTION_ASSIGN;
                searchAssign.currentDocument = AbstractDocumentListItem;
			}

            common.CallbackRagion = CallbackRagion;
            common.ConfigureModel(AbstractDocumentListItem,actionType);
		}

        private void Callback_ACTION_ASSIGN(AbstractRecipient choose)
        {
            chooseAssign = choose;
            presenter.UpdateAssegnatario(choose);
            common.ConfigureAssignDelete(Utility.LanguageConvert("title_assign_to"),chooseAssign, Callback);
            common.ConfigureModel(AbstractDocumentListItem, actionType);
        }

        private void Callback(SupporTypeAction action, String note)
        {
            if (action == SupporTypeAction.UPDATE_TEXT_NOTE)
            {
                presenter.UpdateNote(note);
            }
            else if (action == SupporTypeAction.ACTION_ASSIGN)
            {
                // avvio la schermata successiva per la scelta del ruolo , modello , user ecc
                PerformSegue("UIVControllerSearchAssign", null); 
            }
            else if (action == SupporTypeAction.DELETE_ASSIGN)
            {
                String desc = Utility.LanguageConvert("selected_delega");
                if (actionType == ActionType.ASSIGN)
                    desc = Utility.LanguageConvert("selected_assign");

                common.ConfigureAssignChoose(Utility.LanguageConvert("title_assign_to"), desc, Callback);
                common.ConfigureModel(AbstractDocumentListItem, actionType);
                presenter.UpdateAssegnatario(null);
                presenter.UpdateRagione(null);
            }
            else if(action == SupporTypeAction.ACTION_DONE)
            {
                presenter.Trasmetti();
            }
            else if (action == SupporTypeAction.ACTION_COMPLETE)
            {
                Alert.PopUpStateDocument(Home.Network.SectionType.TODO, this, actionType, Ext.CreateStringForThankYouPage(AbstractDocumentListItem));
            }
            else if (action == SupporTypeAction.ACTION_REGION)
            {
                presenter.GetListaRagioni();
            }
        }

        private void CallbackRagion(Ragione ragione)
        {
            presenter.UpdateRagione(ragione);
        }

		#endregion
    }
}
