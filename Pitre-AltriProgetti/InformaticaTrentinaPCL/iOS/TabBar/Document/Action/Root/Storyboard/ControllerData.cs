// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using InformaticaTrentinaPCL.iOS.Helper;
using UIKit;

namespace InformaticaTrentinaPCL.iOS.TabBar.Document.Action.Root.Storyboard
{
    public partial class ControllerData : UIViewController,IUITextFieldDelegate
	{
        String cFiscale;
        String dominio;
        Action<String> CallbackTextCod;
        Action<String> CallbackTextDom;

		public ControllerData (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            textDomi.Delegate = this;
            textCodFis.Delegate = this;
            labelCodFisc.Text = Utility.LanguageConvert("cod_fis");
            labelDominio.Text = Utility.LanguageConvert("dom_cert");
            if (!string.IsNullOrEmpty(dominio))
            textDomi.Text = dominio;
            if (!string.IsNullOrEmpty(cFiscale))
                textCodFis.Text = cFiscale.ToUpper();
            Font.SetCustomStyleFont(this.labelDominio, Font.HEADER_TABLE, UITextAlignment.Left);
            Font.SetCustomStyleFont(this.labelCodFisc, Font.HEADER_TABLE, UITextAlignment.Left);
            Font.SetCustomStyleFont(this.textCodFis, Font.DETAILS, UITextAlignment.Left);
            Font.SetCustomStyleFont(this.textDomi, Font.DETAILS, UITextAlignment.Left);
            footer1.BackgroundColor = Colors.COLOR_SEARCH_FOOTER;
            footer2.BackgroundColor = Colors.COLOR_SEARCH_FOOTER;
            ConfigureTablet();
        }

        private void ConfigureTablet()
        {
            viewTablet.Hidden = !Utility.IsTablet();
            Font.SetCustomStyleFont(this.tabletTextDom, Font.DETAILS, UITextAlignment.Left);
            Font.SetCustomStyleFont(this.tabletTextCodFis, Font.DETAILS, UITextAlignment.Left);
            footer3.BackgroundColor = Colors.COLOR_SEARCH_FOOTER;
            footer4.BackgroundColor = Colors.COLOR_SEARCH_FOOTER;
            Font.SetCustomStyleFont(this.tabletLabelCod, Font.HEADER_TABLE, UITextAlignment.Left);
            Font.SetCustomStyleFont(this.tabletLabelDom, Font.HEADER_TABLE, UITextAlignment.Left);
            tabletLabelCod.Text = Utility.LanguageConvert("cod_fis");
            tabletLabelDom.Text = Utility.LanguageConvert("dom_cert");
            tabletTextDom.Delegate = this;
            tabletTextCodFis.Delegate = this;
            if (!string.IsNullOrEmpty(dominio))
                tabletTextDom.Text = dominio;
            if (!string.IsNullOrEmpty(cFiscale))
                tabletTextCodFis.Text = cFiscale.ToUpper();
        }

        [Export("textFieldShouldBeginEditing:")]
        public bool ShouldBeginEditing(UITextField textField)
        {
            if (textField == textDomi)
            Keyboard.CUSTOM_Y = 1;
            else if (textField == textCodFis)
                Keyboard.CUSTOM_Y = 1;
            if (textField == tabletTextDom)
                Keyboard.CUSTOM_Y = 1;
            else if (textField == tabletTextCodFis)
                Keyboard.CUSTOM_Y = 1;

            return true;
        }

        [Export("textFieldShouldReturn:")]
         public bool ShouldReturn(UITextField textField)
         {
            textField.EndEditing(true);
            TextCallback(textField);
            return true;
         }

        partial void onChanged(UITextField sender)
        {
            TextCallback(sender);
        }

        void TextCallback(UITextField textField) {
            if (textField == textDomi || textField == tabletTextDom && CallbackTextDom != null)
            {
                CallbackTextDom(textField.Text);
            }
            else if (textField == textCodFis || textField == tabletTextCodFis && CallbackTextCod != null)
            {
                CallbackTextCod(textField.Text);
            }
        }

        public void SetCodFis(String codFisc, Action<String> CallbackText)
        {
            cFiscale = codFisc;
            CallbackTextCod = CallbackText;
        }

        public void SetDominio(String domi, Action<String> CallbackText)
        {
            dominio = domi;
            CallbackTextDom = CallbackText;
        }

	}
}
