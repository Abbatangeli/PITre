﻿// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using Foundation;
using InformaticaTrentinaPCL.CommonAction;
using InformaticaTrentinaPCL.CommonAction.MVP;
using InformaticaTrentinaPCL.Home;
using InformaticaTrentinaPCL.Home.MVPD;
using InformaticaTrentinaPCL.iOS.Helper;
using InformaticaTrentinaPCL.iOS.Login.Session;
using UIKit;

namespace InformaticaTrentinaPCL.iOS.TabBar.Document.Action.Root.Storyboard
{
    /// <summary>
    ///  questa classe è in grado di gestire i 3 controller Action refuse , Action adl , action 
    /// </summary>
    public partial class UIVControllerIActionPresenter : UIViewController//, ActionCommonInterface
    {
        public AbstractDocumentListItem AbstractDocument;
        public ActionType actionType;
        public IActionPresenter iactionPresenter;
        private ControllerDetailAction commonAction;

        public UIVControllerIActionPresenter(IntPtr handle) : base(handle)
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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ConfigureNavigation();
            iactionPresenter.OnViewReady();
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            this.marginLeft.Constant = StyleTablet.WidthCommonPresentation(this.View);
            this.marginRight.Constant = StyleTablet.WidthCommonPresentation(this.View);
            this.marginDown.Constant = StyleTablet.TopKeyboard();
            this.marginUp.Constant = StyleTablet.TOP_FROM_NAVIGATION;
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.DestinationViewController is ControllerDetailAction)
            {
                commonAction = (ControllerDetailAction)segue.DestinationViewController;

                if (actionType == ActionType.ACCEPT)
                {
                    iactionPresenter = new ActionAccettaPresenter(commonAction, IosNativeFactory.Instance());
                    commonAction.ConfigureAccept(CallbackAccept);
                }
                else if (actionType == ActionType.REFUSE)
                {
                    iactionPresenter = new ActionRifiutaPresenter(commonAction, IosNativeFactory.Instance());
                    commonAction.ConfigureAccept(CallbackAccept);
                }
                else if (actionType == ActionType.ACCEPT_AND_ADL)
                {
                    iactionPresenter = new ActionADLPresenter(commonAction, IosNativeFactory.Instance());
                    commonAction.ConfigureAccept(CallbackAccept);
                }

                commonAction.ConfigureModel(AbstractDocument,actionType);
            }
        }


        private void CloseTask(SupporTypeAction supportType)
        {
             if (supportType == SupporTypeAction.ACTION_DONE)
                iactionPresenter.ButtonConfirm(AbstractDocument);
             else if (supportType == SupporTypeAction.ACTION_COMPLETE)
                Alert.PopUpStateDocument(Home.Network.SectionType.TODO, this, this.actionType);
        }

        public void CallbackAccept(SupporTypeAction supportType,String notetext)
        {
            if (supportType == SupporTypeAction.UPDATE_TEXT_NOTE)
            {
                iactionPresenter.UpdateNote(notetext);
            }
         
            CloseTask(supportType);
        }
    }
}