// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using InformaticaTrentinaPCL.iOS.Helper;
using UIKit;

namespace InformaticaTrentinaPCL.iOS.ChooseInstance.Storyboard
{
	public partial class UITableViewCellChooseInstance : UITableViewCell
	{
		public UITableViewCellChooseInstance (IntPtr handle) : base (handle)
		{
		}

		public void SetContent(string labelText)
		{
			Font.SetCustomStyleFont(instanceLabel, Font.DETAILS);
			this.instanceLabel.Text = labelText;
		}
	}
}