// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using Foundation;
using InformaticaTrentinaPCL.Assegna;
using InformaticaTrentinaPCL.Assegna.MVPD;
using InformaticaTrentinaPCL.CommonAction.MVP;
using InformaticaTrentinaPCL.Home;
using InformaticaTrentinaPCL.Home.MVPD;
using InformaticaTrentinaPCL.Home.Network;
using InformaticaTrentinaPCL.Interfaces;
using InformaticaTrentinaPCL.iOS.Helper;
using InformaticaTrentinaPCL.Signature.MVP;
using InformaticaTrentinaPCL.Utils;
using UIKit;

namespace InformaticaTrentinaPCL.iOS.TabBar.Document.Action.Root.Storyboard
{
    public enum SupporTypeAction
    {
        UPDATE_TEXT_CODICE_FISCALE,
        UPDATE_TEXT_DOMINIO,
        UPDATE_TEXT_PIN,
        UPDATE_TEXT_OTP,
        UPDATE_TEXT_NOTE,
        DELETE_ASSIGN,
        ACTION_OTP,
        ACTION_ASSIGN,
        ACTION_DONE,
        ACTION_COMPLETE,
        ACTION_REGION,
        REQUEST_OTP
    }

    public partial class ControllerDetailAction : UIViewController, IActionView, IAssegnaView, ISignatureView
    {
        private Action<SupporTypeAction, String> Callback;
        private Action<SupporTypeAction, String, Dictionary<string, string>> CallbackWithExtra;
        public Action<Ragione> CallbackRagion;

        private String titleButtonFooter;
        private AbstractDocumentListItem model;
        private ActionType actiontype;
        private const int h_default = 0;
        private int h_note = h_default;
        private int h_data = h_default;
        private int h_pinOtp = h_default;
        private int h_assignDelete = h_default;
        private int h_assignChoose = h_default;

        String title_;
        String desc_;

        ControllerAssignTo assign;
        ControllerAssignToDelete assignDelete;
        UITapGestureRecognizer gesturetap;
        List<Ragione> ragioni;
        Keyboard keyboard;
        ControllerPinOtp pinOtp;

        public ControllerDetailAction(IntPtr handle) : base(handle)
        {
        }

        public ControllerDetailAction() : base()
        {
        }

        public override void ViewDidLoad()
        {
            Console.WriteLine("ViewDidLoad");
            base.ViewDidLoad();
            ConfigureHeaderStyle();
            ConfigureHeader();
            ConfigureKeyboard();
        }

        private void ConfigureTablet()
        {
            leading.Constant = StyleTablet.LEFT_MARGIN_BUTTON_DEFAULT;
            trailing.Constant = StyleTablet.RIGHT_MARGIN_BUTTON_DEFAULT;
        } 
 
        private void ConfigureKeyboard()
        {
            if (CompleteHeader())
            {

                keyboard = new Keyboard();
                keyboard.KeyboardListenerWillDidHide((CoreGraphics.CGRect obj) =>
                {
                    if (Utility.IsTablet() && UIApplication.SharedApplication.StatusBarOrientation.IsPortrait()) return;
                    Keyboard.CUSTOM_Y = 0;
                    this.View.Frame = new CoreGraphics.CGRect(0, 0, this.View.Frame.Width, this.View.Frame.Height);
                });

                keyboard.KeyboardListenerWillDidShow((CoreGraphics.CGRect obj) =>
                {
                    if (Utility.IsTablet() && UIApplication.SharedApplication.StatusBarOrientation.IsPortrait()) return;

                    Console.WriteLine("****" + Keyboard.CUSTOM_Y);
                    if (Keyboard.CUSTOM_Y != 0)
                        this.View.Frame = new CoreGraphics.CGRect(0, -Keyboard.CUSTOM_Y, this.View.Frame.Width, this.View.Frame.Height);
                    else
                        this.View.Frame = new CoreGraphics.CGRect(0, -obj.Height, this.View.Frame.Width, this.View.Frame.Height);
                });
            }

        }

        /// <summary>
        /// Completes the header.
        /// </summary>
        /// <returns><c>true</c>, if header was completed, <c>false</c> otherwise.</returns>
        private bool CompleteHeader()
        {
            if (model == null || actiontype == null)
            {
                return false;
            }
            if (actiontype.Equals(ActionType.VIEW_OTP))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetHeader()
        {
            if (CompleteHeader())
            {             
                var mittente = model.GetMittente();
                var oggetto = model.GetOggetto();
                var data = model.GetData();
                var ragione = model.GetRagione();
                labelDescDate.Text = data;
                labelDescName.Text = mittente;            
                headerSubTitle.Text = oggetto;
                labelTitleDa.Text = string.IsNullOrEmpty(mittente) ? "" : labelTitleDa.Text;
                labelDescFor.Hidden = true;
                labelTitleFor.Hidden = true;
                int x = 0;
                if (string.IsNullOrEmpty(mittente))
                {
                    x = 20;
                }
                if (string.IsNullOrEmpty(ragione))
                {
                    x = x + 20;
                }

                topContainerData.Constant = -x;
            }
            else 
            {
                topFirstContainer.Constant = -200; // alza il 1 container e adatta la view per il caso view otp
                headerSubTitle.Hidden = true;
                headerTitle.Hidden = true;
                labelDescFor.Hidden = true;
                labelTitleDa.Hidden = true;
                labelTitleFor.Hidden = true;
                labelDescDate.Hidden = true;
                labelDescName.Hidden = true;
                labelTitleSend.Hidden = true;
            }
        }

        private void ConfigureHeader()
        {
            Console.WriteLine("ConfigureHeader");
            buttonDone.SetTitle(titleButtonFooter.ToUpper(), UIControlState.Normal);
            labelTitleSend.Text = Utility.LanguageConvert("title_send_todo").ToUpper();
            labelTitleFor.Text = Utility.LanguageConvert("title_for_todo").ToUpper();
            labelTitleDa.Text = Utility.LanguageConvert("title_of_todo").ToUpper();
            headerTitle.Text = Utility.LanguageConvert("title_for_todoHeader");
            ConfigureHeaderStyle();
            ConfigureHeaderForAssign();
            headerTitle.Text = actiontype.SetDescriptionForTypeDocument(actiontype.description, model!=null?model.tipoDocumento: TypeDocument.NONE);
            SetHeader();
        }

        public void ConfigureHeaderForAssign()
        {
            if (actiontype == ActionType.ASSIGN)
            {
                labelDescFor.UserInteractionEnabled = true;
                gesturetap = new UITapGestureRecognizer(TapCarrierLabel);
                labelDescFor.AddGestureRecognizer(gesturetap);
                Font.SetCustomStyleFont(labelDescFor, Font.LINK_TO_PAGE_SECTION);
                labelDescFor.Text = LocalizedString.SELEZIONA_RAGIONE.Get();
                labelTitleFor.Text = Utility.LanguageConvert("title_for_todo").ToUpper();
            }
        }

        public void TapCarrierLabel(UITapGestureRecognizer touch)
        {
            Callback(SupporTypeAction.ACTION_REGION, string.Empty);
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            ConfigureController();
            ConfigureTablet();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        /// <summary>
        /// Configures the header.
        /// </summary>
        public void ConfigureModel(AbstractDocumentListItem model, ActionType actiontype)
        {
            Console.WriteLine("ConfigureModel");
            this.model = model;
            this.actiontype = actiontype;
            titleButtonFooter = actiontype.confirmButton;
        }

        public void ConfigureActionSelectedRegion(ActionType actiontype)
        {

        }

        public void OnOTPRequested()
        {
            Alert.AlertToast(LocalizedString.OTP_RICHIESTO_CON_SUCCESSO.Get(), this);
        }
        
        private void ConfigureHeaderStyle()
        {
            Font.SetCustomStyleFont(headerTitle, Font.LABEL);
            Font.SetCustomStyleFont(headerSubTitle, Font.DETAILS);
            Font.SetCustomStyleFont(labelTitleSend, Font.LABEL);
            Font.SetCustomStyleFont(labelTitleDa, Font.LABEL);
            Font.SetCustomStyleFont(labelTitleFor, Font.LABEL);
            Font.SetCustomStyleFont(labelDescName, Font.DETAILS);
            Font.SetCustomStyleFont(labelDescDate, Font.DETAILS);
            Font.SetCustomStyleFont(labelDescFor, Font.DETAILS);
        }

        private void ConfigureController()
        {
            ContainerData.Hidden = h_data == h_default;
            ContainerPinOtp.Hidden = h_pinOtp == h_default;
            ContainerAssignChoose.Hidden = h_assignChoose == h_default;
            ContainerAssignDelete.Hidden = h_assignDelete == h_default;
            ContainerNote.Hidden = h_note == h_default;
            height_ContainerData.Constant = h_data;
            height_ContainerPinOtp.Constant = h_pinOtp;
            height_ContainerAssignChoose.Constant = h_assignChoose;
            height_ContainerAssignDelete.Constant = h_assignDelete;
            height_ContainerNote.Constant = h_note;
        }

        /// <summary>
        /// Configures the accept.
        /// </summary>
        /// <param name="Callback">Callback.</param>
        public void ConfigureAccept(Action<SupporTypeAction, String> Callback)
        {
            this.Callback = Callback;
            h_note = 60;
        }

        /// <summary>
        /// Configures the assign choose.
        /// </summary>
        /// <param name="titleSection">Title section.</param>
        /// <param name="desc">Desc.</param>
        /// <param name="Callback">Callback.</param>
        public void ConfigureAssignChoose(String titleSection, String desc, Action<SupporTypeAction, String> Callback)
        {
            this.Callback = Callback;
            h_assignChoose = 70;
            this.title_ = titleSection;
            this.desc_ = desc;
            h_note = 60;
            h_assignDelete = h_default;
            if (assign != null)  // reload se solo se è != null
                ConfigureController(); // reload
        }

        /// <summary>
        /// Configures the assign delete.
        /// </summary>
        /// <param name="titleSection">Title section.</param>
        /// <param name="nameAssign">Name assign.</param>
        /// <param name="subName">Sub name.</param>
        /// <param name="Callback">Callback.</param>
        public void ConfigureAssignDelete(String titleSection, AbstractRecipient chooseAssign, Action<SupporTypeAction, String> Callback)
        {
            this.Callback = Callback;
            h_assignChoose = h_default;
            this.title_ = titleSection;
            h_note = 60;
            h_assignDelete = 90;
            ConfigureController(); // reload
            assignDelete.ConfigureController(title_, chooseAssign, Callback);
            assignDelete.Refresh(); // reload
        }

        /// <summary>
        /// Configures the sign.
        /// </summary>
        /// <param name="titleSection">Title section.</param>
        /// <param name="nameAssign">Name assign.</param>
        /// <param name="subName">Sub name.</param>
        /// <param name="Callback">Callback.</param>
        public void ConfigureSign(Action<SupporTypeAction, String, Dictionary<string, string>> Callback)
        {
            h_data = Utility.IsTablet() ? 100 : 140;
            h_pinOtp = 150;
            this.CallbackWithExtra = Callback;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.DestinationViewController is ControllerNote)
            {
                ControllerNote note = (ControllerNote)segue.DestinationViewController;
                if (Callback != null)
                    note.Callback = Callback;
                if (actiontype == ActionType.ACCEPT)
                note.placeholder = LocalizedString.PLACEHOLDER_NOTES_ACCETTA.Get();
                else if (actiontype == ActionType.REFUSE)
                note.placeholder = LocalizedString.PLACEHOLDER_NOTES_RIFIUTA.Get();
                else if (actiontype == ActionType.ACCEPT_AND_ADL)
                note.placeholder = LocalizedString.PLACEHOLDER_NOTES_ACCETTA_E_ADL.Get();
                else if (actiontype == ActionType.ASSIGN)
                note.placeholder = LocalizedString.PLACEHOLDER_NOTES_ASSIGN.Get();

                note.CallbackChangeHeightNote = (Y_position_note, heightUpdateComponent) => {

                    h_note = (int)(heightUpdateComponent)+30;
                    if (h_note > 140)
                        h_note = 140;
                       
                    ConfigureController();
                };
            }

            else if (segue.DestinationViewController is ControllerAssignTo)
            {
                assign = (ControllerAssignTo)segue.DestinationViewController;
                assign.ConfigureController(title_, desc_, Callback);
            }

            else if (segue.DestinationViewController is ControllerAssignToDelete)
            {
                assignDelete = (ControllerAssignToDelete)segue.DestinationViewController;
            }

            else if (segue.DestinationViewController is ControllerData)
            {
                ControllerData data = (ControllerData)segue.DestinationViewController;
                data.SetCodFis(IosNativeFactory.Instance().GetSessionData().userInfo.signConfiguration.alias,(obj) => {
                    if (Callback != null)
                        Callback(SupporTypeAction.UPDATE_TEXT_CODICE_FISCALE, obj);
                    else
                        CallbackWithExtra(SupporTypeAction.UPDATE_TEXT_CODICE_FISCALE, obj, null);
                });
                data.SetDominio(IosNativeFactory.Instance().GetSessionData().userInfo.signConfiguration.dominio, (obj) => {
                    if (Callback != null)
                        Callback(SupporTypeAction.UPDATE_TEXT_DOMINIO, obj);
                    else
                        CallbackWithExtra(SupporTypeAction.UPDATE_TEXT_DOMINIO, obj, null);
                });
            }

            else if (segue.DestinationViewController is ControllerPinOtp)
            {
                pinOtp = (ControllerPinOtp)segue.DestinationViewController;
                CreatePinOtp(true,!IosNativeFactory.Instance().GetSessionData().userInfo.signConfiguration.isOTPAllowed);
            }
        }

        private void CreatePinOtp(bool isEnabled,bool isHidden)
        {
            pinOtp?.SetClass(isEnabled, isHidden,actiontype.Equals(ActionType.VIEW_OTP),
                             (obj) =>
            {
                if (Callback != null)
                {
                    Callback(SupporTypeAction.UPDATE_TEXT_PIN, obj);
                }
                else
                {
                    CallbackWithExtra(SupporTypeAction.UPDATE_TEXT_PIN, obj, null);
                }
            }, (obj) =>
            {
                if (Callback != null)
                {
                    Callback(SupporTypeAction.UPDATE_TEXT_OTP, obj);
                }
                else
                {
                    CallbackWithExtra(SupporTypeAction.UPDATE_TEXT_OTP, obj, null);
                }
            }, (obj) =>
            {
                if (Callback != null)
                {
                    Callback(SupporTypeAction.REQUEST_OTP, obj);
                }
                else
                {
                    CallbackWithExtra(SupporTypeAction.REQUEST_OTP, obj, null);
                }
            }, CallbackOtp);
        }

        private void CallbackOtp(string arg)
        {
            System.Diagnostics.Debug.WriteLine("Qualcosa e` arrivato " + arg);
        }

        partial void ActionButtonDone(NSObject sender)
        {
            CallbackWithExtra?.Invoke(SupporTypeAction.ACTION_DONE, string.Empty, null);
            Callback?.Invoke(SupporTypeAction.ACTION_DONE, string.Empty);
        }

        #region interface view

        public void CompletedActionOK()
        {
            Callback?.Invoke(SupporTypeAction.ACTION_COMPLETE, string.Empty);
        }

        public void EnableConfirmButton(bool enabled)
        {
            buttonDone.Enabled = enabled;
            buttonDone.BackgroundColor = enabled ? Colors.COLOR_BUTTON_FOOTER_DOCUMENT_ENABLE : Colors.COLOR_BUTTON_FOOTER_DOCUMENT_NOT_ENABLE;
        }

        public void ShowError(string e, bool isLight)
        {
            ShowErrorHelper.Show(this, isLight, e);
        }

        public void OnUpdateLoader(bool isShow)
        {
            Utility.Loading(this.View, isShow);
        }

        public void EnableButton(bool enabled)
        {
            EnableConfirmButton(enabled);
        }

        public void OnAssegnaOk(Dictionary<string, string> extra)
        {
            Callback(SupporTypeAction.ACTION_COMPLETE, string.Empty);
        }

        public void ShowListaRagioni(List<Ragione> ragioni)
        {
            this.ragioni = ragioni;
            UIActionSheet actionSheet;
            actionSheet = new UIActionSheet(Utility.LanguageConvert("title_Sele_Ragio"));
            actionSheet.AddButton(Utility.LanguageConvert("cancel"));
            foreach (var v in ragioni.ToArray())
                actionSheet.AddButton(v.descrizione);

            actionSheet.DestructiveButtonIndex = 0;
            actionSheet.Clicked += delegate (object a, UIButtonEventArgs b)
            {
                if (b.ButtonIndex == 0 || b.ButtonIndex == -1) return;

                Font.SetCustomStyleFont(labelDescFor, Font.DETAILS);

                var index = b.ButtonIndex - 1;
                var region = ragioni.ToArray()[index].descrizione;
                labelDescFor.Text = region;
                if (CallbackRagion != null)
                    CallbackRagion(ragioni.ToArray()[index]);
            };
            actionSheet.ShowInView(this.View);
        }

        #endregion

        #region ISignatureView

        public void SignatureDone(Dictionary<string, string> extra)
        {
            CallbackWithExtra(SupporTypeAction.ACTION_COMPLETE, string.Empty, extra);
        }

        public void EnableRequestOTPButton(bool enabled)
        {
           // modifica la cella direttamente 
            CreatePinOtp(enabled, !IosNativeFactory.Instance().GetSessionData().userInfo.signConfiguration.isOTPAllowed);
            pinOtp?.Refresh();
        }

        public void EnableSignatureButton(bool enabled)
        {
            EnableConfirmButton(enabled);
        }

        public void CompletedActionOK(Dictionary<string, string> extra)
        {
            Alert.PopUpStateDocument(SectionType.SIGN,this, actiontype, extra);
        }

        public void ShowSelectRagione(bool visible)
        {
            labelDescFor.Hidden = !visible;
            labelTitleFor.Hidden = !visible;
        }

        #endregion
    }
}