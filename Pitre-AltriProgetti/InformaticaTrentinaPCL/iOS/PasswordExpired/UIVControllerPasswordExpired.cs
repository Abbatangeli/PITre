﻿// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using Foundation;
using InformaticaTrentinaPCL.ChangePassword;
using InformaticaTrentinaPCL.ChangePassword.MVP;
using InformaticaTrentinaPCL.iOS.Helper;
using InformaticaTrentinaPCL.iOS.Login.Session;
using InformaticaTrentinaPCL.Login;
using InformaticaTrentinaPCL.Login.MVP;
using UIKit;

namespace InformaticaTrentinaPCL.iOS.PasswordExpired
{
    public enum TypeCellPassword
    {
        OLD,
        NEW,
        CONFIRM,
        ADMIN
    }


    public class ClassCellPasswordExpired
    {
        public ClassCellPasswordExpired(string title,string image,UIVControllerPasswordExpired controller,ChangePasswordPresenter presenter,TypeCellPassword typeCellPassword)
        {
            this.title = title;
            this.image = image;
            this.controller = controller;
            this.presenterPassword = presenter;
            this.typeCell = typeCellPassword;
        }

        public string title = "";
		public string image = "";
        public UIVControllerPasswordExpired controller;
        public ChangePasswordPresenter presenterPassword;
        public TypeCellPassword typeCell;
	}

    public partial class UIVControllerPasswordExpired : UIViewController, IUITableViewDelegate, IUITableViewDataSource,ILoginView
    {
        private bool enabled = false;
        private List<ClassCellPasswordExpired> titleTab = new List<ClassCellPasswordExpired>();
        public LoginAdministrationState state;
        ClassCellPasswordExpired ammi;
        ClassCellPasswordExpired passwordNew;
        ChangePasswordPresenter presenterPassword;
        public string username;
        public Action<UserInfo> OnExpiredOk;
        Keyboard keyboard;

		public UIVControllerPasswordExpired (IntPtr handle) : base (handle)
		{
		}

        public void ConfigureTable()
		{
            presenterPassword = new ChangePasswordPresenter(this,IosNativeFactory.Instance(),username);
			tableView.Delegate = this;
			tableView.DataSource = this;
            tableView.EstimatedRowHeight = 100;
            tableView.RowHeight = UITableView.AutomaticDimension;
            var preferences = new Preferences();

            ammi = new ClassCellPasswordExpired(Utility.LanguageConvert(""), "",this, presenterPassword,TypeCellPassword.ADMIN);
            passwordNew = new ClassCellPasswordExpired(Utility.LanguageConvert("password_new"),"", this,presenterPassword,TypeCellPassword.NEW);
            titleTab.Clear();
            titleTab.Add(new ClassCellPasswordExpired(Utility.LanguageConvert("password_use"), "", this, presenterPassword,TypeCellPassword.OLD));
            titleTab.Add(passwordNew);
            titleTab.Add(new ClassCellPasswordExpired(Utility.LanguageConvert("password_ripet"), "", this, presenterPassword,TypeCellPassword.CONFIRM));
			titleTab.Add(ammi);

            if (state == LoginAdministrationState.DEFAULT)
                titleTab.Remove(ammi);

            ammi.title = (state == LoginAdministrationState.UNSELECTED) ? Utility.LanguageConvert("choose_amm") : "";
        }

        public void ConfigureKeyboardNotification()
        {
            if (Utility.IsTablet()) return;

            keyboard = new Keyboard();

            keyboard.KeyboardListenerWillDidShow( (obj) => {

                this.View.Frame = new CoreGraphics.CGRect(0,-100, this.View.Frame.Width, this.View.Frame.Height);

            });

            keyboard.KeyboardListenerWillDidHide((obj) => {

                this.View.Frame = new CoreGraphics.CGRect(0, 0, this.View.Frame.Width, this.View.Frame.Height);

            });
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ConfigureTable();
            buttonDone.Enabled = false;
            buttonDone.SetTitle(Utility.LanguageConvert("button_done").ToUpper(), UIControlState.Normal);
			Utility.ButtonStyleDefault(buttonDone,
									  enabled ? Colors.COLOR_BUTTON_DEFAULT : Colors.COLOR_BUTTON_DISABLED_DEFAULT,
									  UIColor.LightGray,
									  UIColor.White);

            labelTitle.Text = Utility.LanguageConvert("password_expired");
            Font.SetCustomStyleFont(labelTitle, Font.MODALE_TITLE, UITextAlignment.Center);

            labelSubtitle.Text = Utility.LanguageConvert("password_desc");
            Font.SetCustomStyleFont(labelSubtitle, Font.SENDER,UITextAlignment.Center);

            labeltitleUsername.Text = Utility.LanguageConvert("username_Login").ToUpper();
			Font.SetCustomStyleFont(labeltitleUsername, Font.LABEL);

            labelName.Text = username;
			Font.SetCustomStyleFont(labelName, Font.MODALE_TITLE);

		}

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            ConfigureKeyboardNotification();

        }

        public void OnServerChanged(string message)
        {
            throw new NotImplementedException();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            keyboard.RemoveListener();
        }

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			this.marginLeft.Constant = StyleTablet.MarginRightAndLeftForViewController();
			this.marginRight.Constant = StyleTablet.MarginRightAndLeftForViewController();
			this.marginDown.Constant = StyleTablet.MarginBottomAndTopForViewController();
            this.marginUp.Constant = StyleTablet.TOP_FROM_NAVIGATION;
		}

        [Export("tableView:didSelectRowAtIndexPath:")]
        public void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (titleTab.Count == 4 && indexPath.Row == titleTab.Count - 1)
            {
                PerformSegue("UIViewControllerChooseAdministrator", null);
            }
        }

        public nint RowsInSection(UITableView tableView, nint section)
        {
            return titleTab.Count;
        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if (titleTab.Count == 4 && indexPath.Row == titleTab.Count-1)
            {
				UITCellPasswordAmm cellamm = (UITCellPasswordAmm)tableView.DequeueReusableCell("UITCellPasswordAmm");
				cellamm.Update(titleTab[indexPath.Row]);
				return cellamm;
            }

			UITVCellPassword cell = (UITVCellPassword)tableView.DequeueReusableCell("UITVCellPassword");
            cell.Update(titleTab[indexPath.Row]);
			return cell;
        }

		partial void ActionButtonClose(Foundation.NSObject sender)
		{
            presenterPassword.LoginAsync(false);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.DestinationViewController is UIViewControllerChooseAdministrator)
            {
                UIViewControllerChooseAdministrator controller = (UIViewControllerChooseAdministrator)segue.DestinationViewController;
                controller.Callback = Callback;
                controller.username = username;
            }
       }

        public void Callback(AmministrazioneModel model)
        {
            if (model == null)
            {
                state = LoginAdministrationState.UNSELECTED;
                ammi.title = Utility.LanguageConvert("choose_amm");
            }
            else
            {
                state = LoginAdministrationState.SELECTED;
                ammi.title = model.descrizione;
                presenterPassword.UpdateAdministration(model, state);
            }
           
            tableView.ReloadData();
        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            return base.ShouldPerformSegue(segueIdentifier, sender);
        }

        public void EnableButton(bool enabled)
        {
            buttonDone.Enabled = enabled;
            Utility.ButtonStyleDefault(buttonDone,
                                       enabled ? Colors.COLOR_BUTTON_DEFAULT : Colors.COLOR_BUTTON_DISABLED_DEFAULT,
                                   UIColor.LightGray,
                                   UIColor.White);
        }

        public void ChangePasswordOk(UserInfo userLogged)
        {
            if (userLogged != null)
            {
                SaveCredentials();
            }
        }

        /// <summary>
        /// Saves the credenzial all interno dello store
        /// </summary>
        public void SaveCredentials()
        {
            var preferences = new Preferences();
            var username = preferences.GetString(Constant.USERNAME_KEY, null);
            preferences.Set(Constant.PASSWORD_KEY, passwordNew.title);
        }

        public void ShowListAdministration()
        {
            state = LoginAdministrationState.UNSELECTED;
            ConfigureTable();
            tableView.ReloadData();
            this.PerformSegue("UIViewControllerChooseAdministrator", null);
        }

        public void ShowError(string e, bool isLight)
        {
            ShowErrorHelper.Show(this,isLight,e);
        }

        public void OnUpdateLoader(bool isShow)
        {
            Utility.Loading(this.View, isShow);
        }

        public void OnLoginOK(UserInfo user)
        {
            if (OnExpiredOk != null)
               OnExpiredOk(user);
        }

        public void ShowChangePassword()
        {
            Console.WriteLine("Error : ShowChangePassword");
        }

        public void ShowUpdatePopup(string url)
        {
          //  throw new NotImplementedException();
        }
    }
}
