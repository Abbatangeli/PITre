// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using InformaticaTrentinaPCL.Delega.MVP;
using InformaticaTrentinaPCL.Delega.Network;
using InformaticaTrentinaPCL.Interfaces;
using InformaticaTrentinaPCL.iOS.Helper;
using UIKit;

namespace InformaticaTrentinaPCL.iOS.Delega.Storyboard
{
	public partial class UITVCellPeopleFavorite : UITableViewCell
	{
        private Action ActionStart;
        private AbstractRecipient model;
        
		public UITVCellPeopleFavorite (IntPtr handle) : base (handle)
		{
		}

        partial void ActionButtonStart(Foundation.NSObject sender)
        {
            imageStart.Image = UIImage.FromBundle(!model.isPreferred() ? "start_full" : "start_empty");
            this.ActionStart();
        }

        public void Update(AbstractRecipient model,Action ActionButtonStart)
        {
            this.model = model;
            this.ActionStart = ActionButtonStart;
            image.Image = UIImage.FromBundle("imageUserDefault");
            label_title.Text = model.getTitle();
            desc.Text = model.getSubtitle();
            imageStart.Image = UIImage.FromBundle(model.isPreferred()?"start_full":"start_empty");
            Font.SetCustomStyleFont(label_title, Font.DOCUMENT_NAME_1, UITextAlignment.Left);
            Font.SetCustomStyleFont(desc, Font.DESCRIPION, UITextAlignment.Left);
        }
	}
}