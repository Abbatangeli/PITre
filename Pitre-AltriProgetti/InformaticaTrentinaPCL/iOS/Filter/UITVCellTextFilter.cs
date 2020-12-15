// This file has been autogenerated from a class added in the UI designer.

using System;
using Foundation;
using InformaticaTrentinaPCL.Filter.MVP;
using InformaticaTrentinaPCL.iOS.Role.Storyboard;
using UIKit;

namespace InformaticaTrentinaPCL.iOS.Filter
{
  public partial class UITVCellTextFilter : UITableViewCell, IUITextFieldDelegate
  {
    public UITVCellTextFilter(IntPtr handle) : base(handle)
    {
    }

    public CellTypeBody typeBody;
    public IFilterPresenter presenter;

    public void Update(StructureControllerFilter model)
    {
      textField.Placeholder = model.desc;
      if (!string.IsNullOrEmpty(model.text))
      {
        textField.Text = model.text;
      }
      this.typeBody = model.typeBody;
      this.presenter = model.presenter;
      textField.Delegate = this;
    }

    [Export("textField:shouldChangeCharactersInRange:replacementString:")]
    public bool ShouldChangeCharacters(UITextField textField, NSRange range, string replacementString)
    {
      NSString newString = ((NSString) textField.Text).Replace(range, (NSString) replacementString);
      textField.Text = newString;
      switch (typeBody)
      {
        case CellTypeBody.ID_Document:
          presenter.UpdateIdDocument(newString);
          break;
        case CellTypeBody.Num_Proto:
          presenter.UpdateNumberProtocol(newString);
          break;
        case CellTypeBody.Year_Proto:
          presenter.UpdateYearProtocol(newString);
          break;

        case CellTypeBody.Oggetto:
          presenter.UpdateOggetto(newString);
          break;
      }

      if (replacementString == "\n")
        textField.EndEditing(true);

      return false;
    }
  }
}