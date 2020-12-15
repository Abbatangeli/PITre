﻿using Android.OS;
using InformaticaTrentinaPCL.Droid.Core;
using InformaticaTrentinaPCL.Droid.Utils;
using InformaticaTrentinaPCL.Filter;
using InformaticaTrentinaPCL.Home.MVPD;
using InformaticaTrentinaPCL.Search;
using InformaticaTrentinaPCL.Search.MVP;
using InformaticaTrentinaPCL.Utils;
using Newtonsoft.Json;

namespace InformaticaTrentinaPCL.Droid.Search
{
    public class SearchNativePresenter : SearchPresenter, IAndroidPresenter
    {
        
        public AbstractDocumentListItem AbstractDocumentToShare { set; get; }

        public SearchNativePresenter(ISearchView view, INativeFactory nativeFactory) : base(view, nativeFactory)
        {
        }

        public Bundle GetStateToSave()
        {
            Bundle bundle = new Bundle();
            bundle.PutString(Key.FILTER, JsonConvert.SerializeObject(currentFilterModel));
            bundle.PutString(Key.DOCUMENT_TO_SHARE, JsonConvert.SerializeObject(AbstractDocumentToShare));
            return bundle;
        }

        public void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            if (savedInstanceState != null)   
            {
                if (savedInstanceState.ContainsKey(Key.FILTER))
                {
                    string savedFilter = savedInstanceState.GetString(Key.FILTER);
                    if (!string.IsNullOrEmpty(savedFilter) && !savedFilter.Equals("null"))
                    {
                        SetFilterModel(JsonConvert.DeserializeObject<FilterModel>(savedFilter));
                    } 
                }
                
                if (savedInstanceState.ContainsKey(Key.DOCUMENT_TO_SHARE))
                {
                    string savedDocument = savedInstanceState.GetString(Key.DOCUMENT_TO_SHARE);
                    if (!string.IsNullOrEmpty(savedDocument) && !savedDocument.Equals("null"))
                    {
                        AbstractDocumentToShare = AbstractDocumentListItemHelper.DeserializeAbstractDocumentListItem(savedDocument);
                    } 
                }
            }
        }
        
        class Key{
            internal static string FILTER = "FILTER";
            internal static string DOCUMENT_TO_SHARE = "DOCUMENT_TO_SHARE";
        }
    }
}