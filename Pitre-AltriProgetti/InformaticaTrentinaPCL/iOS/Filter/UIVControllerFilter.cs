﻿// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using InformaticaTrentinaPCL.Filter;
using InformaticaTrentinaPCL.Filter.MVP;
using InformaticaTrentinaPCL.Home;
using InformaticaTrentinaPCL.iOS.Helper;
using InformaticaTrentinaPCL.iOS.Login.Session;
using InformaticaTrentinaPCL.iOS.Role.Storyboard;
using UIKit;
using UICode.iOS;
using InformaticaTrentinaPCL.Utils;
using InformaticaTrentinaPCL.Home.MVPD;
using InformaticaTrentinaPCL.Home.Network;

namespace InformaticaTrentinaPCL.iOS.Filter
{
    public class StructureControllerFilter
    {
        public string descTitle;
        public CellType cellType;
        public CellTypeBody typeBody;
        public bool IsEnable = false;
        public string desc;
        public NSDate date;
        public int diff = 0;
        public IFilterPresenter presenter;
        public string text { get; set; }


        public StructureControllerFilter(CellType cellType, CellTypeBody typeBody, string desc, IFilterPresenter presenter = null)
        {
            this.descTitle = "";
            this.cellType = cellType;
            this.typeBody = typeBody;
            this.desc = desc;
            this.presenter = presenter;

        }

        public StructureControllerFilter(CellType cellType, CellTypeBody typeBody, string desc,IFilterPresenter presenter , string search_title)
        {
            this.descTitle = search_title;
            this.cellType = cellType;
            this.typeBody = typeBody;
            this.desc = desc;
            this.presenter = presenter;
        }
    }

    public partial class UIVControllerFilter : UIViewController, IUITableViewDelegate, IUITableViewDataSource,IFilterView
    {
        List<StructureControllerFilter> list = new List<StructureControllerFilter>();
        StructureControllerFilter fascicoli = null;
        StructureControllerFilter documenti = null;
        StructureControllerFilter union = null;
        StructureControllerFilter dateInit = null;
        StructureControllerFilter dateTheEnd = null;
        private NSDate dateDa = null;
        private NSDate dateA = null;
        private FilterPresenter filterPresenter;
        public Action<FilterModel> CallbackFinish;
        public SectionType sectionType { get; set; }
        private Keyboard keyboard;

        public UIVControllerFilter(IntPtr handle) : base(handle)
        {
        }

        public void InitPresenter(FilterModel filterModel)
        {
            filterPresenter = new FilterPresenter(this,IosNativeFactory.Instance() , filterModel, sectionType);
        }

        public void AddHeaderFilterFor(FilterModel filterModel)
        {
            list.Add(new StructureControllerFilter(CellType.Header, CellTypeBody.Title, Utility.LanguageConvert("FILTRA PER"),filterPresenter));
            fascicoli = new StructureControllerFilter(CellType.Row, CellTypeBody.Enable, Utility.LanguageConvert("Fascicoli"), filterPresenter);
            fascicoli.IsEnable = filterModel == null ? false : (filterModel.documentType == TypeDocument.FASCICOLO);
            documenti = new StructureControllerFilter(CellType.Row, CellTypeBody.Enable, Utility.LanguageConvert("Documenti"), filterPresenter);
            documenti.IsEnable = filterModel == null ? false : (filterModel.documentType == TypeDocument.DOCUMENTO);
            union = new StructureControllerFilter(CellType.Row, CellTypeBody.Enable, Utility.LanguageConvert("Entrambi"), filterPresenter);
            union.IsEnable = filterModel == null ? true : (filterModel.documentType == TypeDocument.ALL);
            list.Add(fascicoli);
            list.Add(documenti);
            list.Add(union);
        }

        public void AddPeriodFilterFor()
        {
            StructureControllerFilter now = new StructureControllerFilter(CellType.Row, CellTypeBody.Title, Utility.LanguageConvert("Oggi"), filterPresenter);
            now.diff = 0;
            StructureControllerFilter now7 = new StructureControllerFilter(CellType.Row, CellTypeBody.Title, Utility.LanguageConvert("Ultimi 7 giorni"), filterPresenter);
            now7.diff = 7;
            StructureControllerFilter now30 = new StructureControllerFilter(CellType.Row, CellTypeBody.Title, Utility.LanguageConvert("Ultimi 30 giorni"), filterPresenter);
            now30.diff = 30;
            list.Add(new StructureControllerFilter(CellType.Header, CellTypeBody.Title, Utility.LanguageConvert("PERIODO"), filterPresenter));
            list.Add(now);
            list.Add(now7);
            list.Add(now30);
        }


        private void AddDocument(FilterModel filterModel)
        {
            var title = LocalizedString.FILTERS_SECTION_DOCUMENT_TITLE.Get();
            var documentId = LocalizedString.FILTERS_DOCUMENT_ID.Get();
            StructureControllerFilter titolo = new StructureControllerFilter(CellType.Header, CellTypeBody.Title, title, filterPresenter);
            StructureControllerFilter Id_Documento = new StructureControllerFilter(CellType.Row, CellTypeBody.ID_Document, documentId, filterPresenter);
            Id_Documento.text = !string.IsNullOrEmpty(filterModel.idDocument) ? filterModel.idDocument : string.Empty;
            StructureControllerFilter dateInitDocument = new StructureControllerFilter(CellType.Row, CellTypeBody.DateDA, Utility.LanguageConvert("Da"), filterPresenter , "Seleziona data documento - fascicolo");
           
            dateInitDocument.date = filterModel.fromDate != null ? ConvertDate(filterModel.fromDate) : new NSDate();          
            StructureControllerFilter dateTheEndDocument = new StructureControllerFilter(CellType.Row, CellTypeBody.DateA, Utility.LanguageConvert("A"), filterPresenter);
            dateTheEndDocument.date = filterModel.endDate != null ? ConvertDate(filterModel.endDate) : new NSDate();

          /*  UILabel test  =   new UILabel()
            {
                Text = "Hello, this is a string",
                Font = UIFont.FromName("Papyrus", 20f),
                TextColor = UIColor.Magenta,
                TextAlignment = UITextAlignment.Center
            }; */

          //  list.Add(test);
            list.Add(titolo);
            list.Add(Id_Documento);
            list.Add(dateInitDocument);
            list.Add(dateTheEndDocument);
        }

        private void AddProtocol(FilterModel filterModel)
        {
            var title = LocalizedString.FILTERS_SECTION_PROTOCOL_TITLE.Get();
            var protocol = LocalizedString.FILTERS_PROTOCOL_NUMBER.Get();
            var year = LocalizedString.FILTERS_SECTION_YEAR_PROTOCOL.Get();
            StructureControllerFilter titolo = new StructureControllerFilter(CellType.Header, CellTypeBody.Title, title, filterPresenter);
            StructureControllerFilter NumberProtocol = new StructureControllerFilter(CellType.Row, CellTypeBody.Num_Proto, protocol, filterPresenter);
            NumberProtocol.text = !string.IsNullOrEmpty(filterModel.NumProto) ? filterModel.NumProto : string.Empty;
            StructureControllerFilter yearProtol = new StructureControllerFilter(CellType.Row, CellTypeBody.Year_Proto,year, filterPresenter);
            yearProtol.text = !string.IsNullOrEmpty(filterModel.yearProto) ? filterModel.yearProto : string.Empty;
            StructureControllerFilter dateInitProtocol = new StructureControllerFilter(CellType.Row, CellTypeBody.DateDaProtocol, Utility.LanguageConvert("Da"), filterPresenter, "Seleziona data protocollo");
            dateInitProtocol.date = filterModel.fromDateProtocol != null ? ConvertDate(filterModel.fromDateProtocol) : new NSDate(); 
            StructureControllerFilter dateTheEndProtocol = new StructureControllerFilter(CellType.Row, CellTypeBody.DateAProtocol, Utility.LanguageConvert("A"), filterPresenter);
            dateTheEndProtocol.date = filterModel.endDateProtocol != null ? ConvertDate(filterModel.endDateProtocol) : new NSDate(); 

            list.Add(titolo);
            list.Add(NumberProtocol);
            list.Add(yearProtol);
            list.Add(dateInitProtocol);
            list.Add(dateTheEndProtocol);
        }

        private void AddOggetto(FilterModel filterModel)
        {
            StructureControllerFilter oggetto = new StructureControllerFilter(CellType.Row, CellTypeBody.Oggetto, LocalizedString.OGGETTO.Get(), filterPresenter);
            oggetto.text = !string.IsNullOrEmpty(filterModel.oggetto) ? filterModel.oggetto : string.Empty;
            list.Add(oggetto);           
        }

        private NSDate ConvertDate(DateTime dateTime)
        {
            return dateTime.IsSet() ? dateTime.DateTimeToNSDate() : null;
        }

        public void AddDateFilterFor(FilterModel filterModel)
        {
            list.Add(new StructureControllerFilter(CellType.Header, CellTypeBody.Title, Utility.LanguageConvert("SELEZIONA DATE"), filterPresenter));
            dateInit = new StructureControllerFilter(CellType.Row, CellTypeBody.DateDA, Utility.LanguageConvert("Da"), filterPresenter);
            dateInit.date = filterModel == null ? null : ConvertDate(filterModel.fromDate);

            dateTheEnd = new StructureControllerFilter(CellType.Row, CellTypeBody.DateA, Utility.LanguageConvert("A"), filterPresenter);
            dateTheEnd.date = filterModel == null ? null : ConvertDate(filterModel.endDate);

            list.Add(dateInit);
            list.Add(dateTheEnd);
        }

        public void configureTable()
        {
            tableView.Delegate = this;
            tableView.DataSource = this;
            tableView.RowHeight = UITableView.AutomaticDimension;
            tableView.EstimatedRowHeight = 100;
        }

        public void configureStyle()
        {
            tilteController.Text = Utility.LanguageConvert("title_filter_docu_dossier");
            Font.SetCustomStyleFont(tilteController, Font.PAGE_TITLE);
            tilteController.TextColor = UIColor.Black;
            EnableButton(false);
            buttondone.SetTitle(Utility.LanguageConvert("button_done").ToUpper(), UIControlState.Normal);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad(); 
            filterPresenter.OnViewReady();
            configureStyle();
            configureTable();
            ConfigureKeyboardNotification();
        }

        public void ConfigureKeyboardNotification()
        {
            if (Utility.IsTablet()) return;

            keyboard = new Keyboard();

            keyboard.KeyboardListenerWillDidShow((obj) => {

                this.View.Frame = new CoreGraphics.CGRect(0, -70, this.View.Frame.Width, this.View.Frame.Height);

            });

            keyboard.KeyboardListenerWillDidHide((obj) => {

                this.View.Frame = new CoreGraphics.CGRect(0, 0, this.View.Frame.Width, this.View.Frame.Height);

            });
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            ConfigureTablet();
        }

        public void ConfigureTablet()
        {
            this.marginLeft.Constant = StyleTablet.WidthCommonPresentation(this.View);
            this.marginRight.Constant = StyleTablet.WidthCommonPresentation(this.View);
            this.marginDown.Constant = StyleTablet.MarginBottonDefault();
            this.marginUp.Constant = StyleTablet.TOP_FROM_NAVIGATION;
            this.trailingButton.Constant = StyleTablet.LEFT_MARGIN_BUTTON_DEFAULT;
            this.leadingButton.Constant = StyleTablet.LEFT_MARGIN_BUTTON_DEFAULT;

            if (UIApplication.SharedApplication.StatusBarOrientation.IsLandscape())
            {
                this.marginDown.Constant = StyleTablet.MarginBottonDefault()-20;
                this.marginUp.Constant = StyleTablet.TOP_FROM_NAVIGATION-30;
            }


        }

        public void EnableButton(bool enabled)
        {
            buttondone.Enabled = enabled;
            Utility.ButtonStyleDefault(buttondone,
                                       enabled ? Colors.COLOR_BUTTON_DEFAULT : Colors.COLOR_BUTTON_DISABLED_DEFAULT,
                                       UIColor.LightGray,
                                       UIColor.White);
        }

        public void RadioButtonRefresh(StructureControllerFilter structFilter)
        {
            if (structFilter == fascicoli && documenti != null && documenti != null && union != null)
            {
                filterPresenter.UpdateType(TypeDocument.FASCICOLO);
                fascicoli.IsEnable = true;
                documenti.IsEnable = false;
                union.IsEnable = false;
            }
            else if (structFilter == documenti && documenti != null && documenti != null && union != null)
            {
                filterPresenter.UpdateType(TypeDocument.DOCUMENTO);
                documenti.IsEnable = true;
                fascicoli.IsEnable = false;
                union.IsEnable = false;
            }
            else if (structFilter == union && documenti != null && documenti != null && union != null )
            {
                filterPresenter.UpdateType(TypeDocument.ALL);
                union.IsEnable = true;
                documenti.IsEnable = false;
                fascicoli.IsEnable = false;
            }

            tableView.ReloadData();
        }


        [Export("tableView:didSelectRowAtIndexPath:")]
        public virtual void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var structure = list[indexPath.Row];
            dateDa = null;
            dateA = null;
            if (structure.typeBody == CellTypeBody.Title)
            {
                //int diff = structure.diff;  // day
                //diff = diff * 24 * 60 * 60; // second 
                //dateDa = (NSDate.Now).AddSeconds(-diff);
                //dateA = (NSDate.Now);
                //dateInit.date = dateDa;
                //dateTheEnd.date = dateA;
                //filterPresenter.UpdateStartDate(dateDa.NSDateToDateTime());
                //filterPresenter.UpdateEndDate(dateA.NSDateToDateTime());
                tableView.ReloadData();
            }
            else if (structure.typeBody == CellTypeBody.Enable)
            {
                RadioButtonRefresh(structure);
            }

            RadioButtonRefresh(dateInit);  // serve solo per il reset
        }


        public UITableViewCell CreateCellText(StructureControllerFilter filterstruct)
        {
            UITVCellTextFilter cell = (UITVCellTextFilter)tableView.DequeueReusableCell("UITVCellTextFilter");
            cell.Update(filterstruct);
            return cell;
        }

        public UITableViewCell CreateCellDate(StructureControllerFilter filterstruct)
        {
            UITVCellSelectedData cell = (UITVCellSelectedData)tableView.DequeueReusableCell("UITVCellSelectedData");
            cell.Update(filterstruct, this);
            return cell;
        }

        public UITableViewCell CreateCellEnable(StructureControllerFilter filterstruct)
        {
            UITVCellEnableFilter cell = (UITVCellEnableFilter)tableView.DequeueReusableCell("UITVCellEnableFilter");
            cell.Update(filterstruct, RadioButtonRefresh);
            return cell;
        }

        public UITableViewCell CreateCellTitle(string desc, CellType type)
        {
            UITVCellTitleFilter cell = (UITVCellTitleFilter)tableView.DequeueReusableCell("UITVCellTitleFilter");
            cell.Update(desc, type);
            return cell;
        }


        partial void ActionButtonClose(Foundation.NSObject sender)
        {
            DismissViewController(true, null);
        }

        partial void ActionButtonDone(Foundation.NSObject sender)
        {
            this.filterPresenter.OnConfirmButton();
        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var structure = list[indexPath.Row];

            if (structure.typeBody == CellTypeBody.Enable)
                return CreateCellEnable(structure);
            else if (structure.typeBody == CellTypeBody.DateA || structure.typeBody == CellTypeBody.DateDA || structure.typeBody == CellTypeBody.DateDaProtocol || structure.typeBody == CellTypeBody.DateAProtocol)
                return CreateCellDate(structure);
            else if (structure.typeBody == CellTypeBody.ID_Document || structure.typeBody == CellTypeBody.Num_Proto || structure.typeBody == CellTypeBody.Year_Proto || structure.typeBody == CellTypeBody.Oggetto)
                return CreateCellText(structure);

            return CreateCellTitle(structure.desc, structure.cellType);
        }

        public nint RowsInSection(UITableView tableView, nint section)
        {
            return list.Count;
        }

        /// <summary>
        /// Ons the new filter.   confemra mi entra qui
        /// </summary>
        /// <param name="filterModel">Filter model.</param>
        public void OnNewFilter(FilterModel filterModel)
        {
            CallbackFinish(filterModel);
            DismissViewController(true,null);
        }

        /// <summary>
        /// Updates the filter view.
        /// </summary>
        /// <param name="filterModel">Filter model.</param>
        public void UpdateFilterView(FilterModel filterModel)
        {
            list.Clear();
            if (sectionType != SectionType.SIGN)
            {
                AddHeaderFilterFor(filterModel);
            }
            // AddPeriodFilterFor(); al momento non ci sarà piu
            // AddDateFilterFor(filterModel); al momento non ci sarà piu
            AddDocument(filterModel);
            if (sectionType != SectionType.SIGN)
            {
                AddProtocol(filterModel);
            }
            else
            {
                AddOggetto(filterModel);
            }
            tableView?.ReloadData();
        }

        public void OnFilterError(string error)
        {
            ShowErrorHelper.Show(this, false, error);
        }
    }
}