﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DocsPaIntegrationImpl.ExternalWR {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PuntualSearchInfoWS", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class PuntualSearchInfoWS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodiceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Codice {
            get {
                return this.CodiceField;
            }
            set {
                if ((object.ReferenceEquals(this.CodiceField, value) != true)) {
                    this.CodiceField = value;
                    this.RaisePropertyChanged("Codice");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PuntualSearchOutputWS", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class PuntualSearchOutputWS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DocsPaIntegrationImpl.ExternalWR.SearchOutputRowWS RowField;
        
        private DocsPaIntegrationImpl.ExternalWR.SearchOutputCode CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public DocsPaIntegrationImpl.ExternalWR.SearchOutputRowWS Row {
            get {
                return this.RowField;
            }
            set {
                if ((object.ReferenceEquals(this.RowField, value) != true)) {
                    this.RowField = value;
                    this.RaisePropertyChanged("Row");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public DocsPaIntegrationImpl.ExternalWR.SearchOutputCode Code {
            get {
                return this.CodeField;
            }
            set {
                if ((this.CodeField.Equals(value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SearchOutputRowWS", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class SearchOutputRowWS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodiceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescrizioneField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Codice {
            get {
                return this.CodiceField;
            }
            set {
                if ((object.ReferenceEquals(this.CodiceField, value) != true)) {
                    this.CodiceField = value;
                    this.RaisePropertyChanged("Codice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Descrizione {
            get {
                return this.DescrizioneField;
            }
            set {
                if ((object.ReferenceEquals(this.DescrizioneField, value) != true)) {
                    this.DescrizioneField = value;
                    this.RaisePropertyChanged("Descrizione");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SearchOutputCode", Namespace="http://tempuri.org/")]
    public enum SearchOutputCode : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        OK = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        KO = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SearchInfoWS", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class SearchInfoWS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodiceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescrizioneField;
        
        private int PageSizeField;
        
        private int RequestedPageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Codice {
            get {
                return this.CodiceField;
            }
            set {
                if ((object.ReferenceEquals(this.CodiceField, value) != true)) {
                    this.CodiceField = value;
                    this.RaisePropertyChanged("Codice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Descrizione {
            get {
                return this.DescrizioneField;
            }
            set {
                if ((object.ReferenceEquals(this.DescrizioneField, value) != true)) {
                    this.DescrizioneField = value;
                    this.RaisePropertyChanged("Descrizione");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int PageSize {
            get {
                return this.PageSizeField;
            }
            set {
                if ((this.PageSizeField.Equals(value) != true)) {
                    this.PageSizeField = value;
                    this.RaisePropertyChanged("PageSize");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int RequestedPage {
            get {
                return this.RequestedPageField;
            }
            set {
                if ((this.RequestedPageField.Equals(value) != true)) {
                    this.RequestedPageField = value;
                    this.RaisePropertyChanged("RequestedPage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SearchOutputWS", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class SearchOutputWS : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int NumTotResultsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DocsPaIntegrationImpl.ExternalWR.SearchOutputRowWS[] RowsField;
        
        private DocsPaIntegrationImpl.ExternalWR.SearchOutputCode CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int NumTotResults {
            get {
                return this.NumTotResultsField;
            }
            set {
                if ((this.NumTotResultsField.Equals(value) != true)) {
                    this.NumTotResultsField = value;
                    this.RaisePropertyChanged("NumTotResults");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public DocsPaIntegrationImpl.ExternalWR.SearchOutputRowWS[] Rows {
            get {
                return this.RowsField;
            }
            set {
                if ((object.ReferenceEquals(this.RowsField, value) != true)) {
                    this.RowsField = value;
                    this.RaisePropertyChanged("Rows");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public DocsPaIntegrationImpl.ExternalWR.SearchOutputCode Code {
            get {
                return this.CodeField;
            }
            set {
                if ((this.CodeField.Equals(value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ExternalWR.ExternalWSSoap")]
    public interface ExternalWSSoap {
        
        // CODEGEN: Generating message contract since element name searchInfo from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PuntualSearch", ReplyAction="*")]
        DocsPaIntegrationImpl.ExternalWR.PuntualSearchResponse PuntualSearch(DocsPaIntegrationImpl.ExternalWR.PuntualSearchRequest request);
        
        // CODEGEN: Generating message contract since element name searchInfo from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Search", ReplyAction="*")]
        DocsPaIntegrationImpl.ExternalWR.SearchResponse Search(DocsPaIntegrationImpl.ExternalWR.SearchRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PuntualSearchRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PuntualSearch", Namespace="http://tempuri.org/", Order=0)]
        public DocsPaIntegrationImpl.ExternalWR.PuntualSearchRequestBody Body;
        
        public PuntualSearchRequest() {
        }
        
        public PuntualSearchRequest(DocsPaIntegrationImpl.ExternalWR.PuntualSearchRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class PuntualSearchRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public DocsPaIntegrationImpl.ExternalWR.PuntualSearchInfoWS searchInfo;
        
        public PuntualSearchRequestBody() {
        }
        
        public PuntualSearchRequestBody(DocsPaIntegrationImpl.ExternalWR.PuntualSearchInfoWS searchInfo) {
            this.searchInfo = searchInfo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class PuntualSearchResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="PuntualSearchResponse", Namespace="http://tempuri.org/", Order=0)]
        public DocsPaIntegrationImpl.ExternalWR.PuntualSearchResponseBody Body;
        
        public PuntualSearchResponse() {
        }
        
        public PuntualSearchResponse(DocsPaIntegrationImpl.ExternalWR.PuntualSearchResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class PuntualSearchResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public DocsPaIntegrationImpl.ExternalWR.PuntualSearchOutputWS PuntualSearchResult;
        
        public PuntualSearchResponseBody() {
        }
        
        public PuntualSearchResponseBody(DocsPaIntegrationImpl.ExternalWR.PuntualSearchOutputWS PuntualSearchResult) {
            this.PuntualSearchResult = PuntualSearchResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SearchRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Search", Namespace="http://tempuri.org/", Order=0)]
        public DocsPaIntegrationImpl.ExternalWR.SearchRequestBody Body;
        
        public SearchRequest() {
        }
        
        public SearchRequest(DocsPaIntegrationImpl.ExternalWR.SearchRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SearchRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public DocsPaIntegrationImpl.ExternalWR.SearchInfoWS searchInfo;
        
        public SearchRequestBody() {
        }
        
        public SearchRequestBody(DocsPaIntegrationImpl.ExternalWR.SearchInfoWS searchInfo) {
            this.searchInfo = searchInfo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SearchResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="SearchResponse", Namespace="http://tempuri.org/", Order=0)]
        public DocsPaIntegrationImpl.ExternalWR.SearchResponseBody Body;
        
        public SearchResponse() {
        }
        
        public SearchResponse(DocsPaIntegrationImpl.ExternalWR.SearchResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class SearchResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public DocsPaIntegrationImpl.ExternalWR.SearchOutputWS SearchResult;
        
        public SearchResponseBody() {
        }
        
        public SearchResponseBody(DocsPaIntegrationImpl.ExternalWR.SearchOutputWS SearchResult) {
            this.SearchResult = SearchResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ExternalWSSoapChannel : DocsPaIntegrationImpl.ExternalWR.ExternalWSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ExternalWSSoapClient : System.ServiceModel.ClientBase<DocsPaIntegrationImpl.ExternalWR.ExternalWSSoap>, DocsPaIntegrationImpl.ExternalWR.ExternalWSSoap {
        
        public ExternalWSSoapClient() {
        }
        
        public ExternalWSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ExternalWSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExternalWSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExternalWSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DocsPaIntegrationImpl.ExternalWR.PuntualSearchResponse DocsPaIntegrationImpl.ExternalWR.ExternalWSSoap.PuntualSearch(DocsPaIntegrationImpl.ExternalWR.PuntualSearchRequest request) {
            return base.Channel.PuntualSearch(request);
        }
        
        public DocsPaIntegrationImpl.ExternalWR.PuntualSearchOutputWS PuntualSearch(DocsPaIntegrationImpl.ExternalWR.PuntualSearchInfoWS searchInfo) {
            DocsPaIntegrationImpl.ExternalWR.PuntualSearchRequest inValue = new DocsPaIntegrationImpl.ExternalWR.PuntualSearchRequest();
            inValue.Body = new DocsPaIntegrationImpl.ExternalWR.PuntualSearchRequestBody();
            inValue.Body.searchInfo = searchInfo;
            DocsPaIntegrationImpl.ExternalWR.PuntualSearchResponse retVal = ((DocsPaIntegrationImpl.ExternalWR.ExternalWSSoap)(this)).PuntualSearch(inValue);
            return retVal.Body.PuntualSearchResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DocsPaIntegrationImpl.ExternalWR.SearchResponse DocsPaIntegrationImpl.ExternalWR.ExternalWSSoap.Search(DocsPaIntegrationImpl.ExternalWR.SearchRequest request) {
            return base.Channel.Search(request);
        }
        
        public DocsPaIntegrationImpl.ExternalWR.SearchOutputWS Search(DocsPaIntegrationImpl.ExternalWR.SearchInfoWS searchInfo) {
            DocsPaIntegrationImpl.ExternalWR.SearchRequest inValue = new DocsPaIntegrationImpl.ExternalWR.SearchRequest();
            inValue.Body = new DocsPaIntegrationImpl.ExternalWR.SearchRequestBody();
            inValue.Body.searchInfo = searchInfo;
            DocsPaIntegrationImpl.ExternalWR.SearchResponse retVal = ((DocsPaIntegrationImpl.ExternalWR.ExternalWSSoap)(this)).Search(inValue);
            return retVal.Body.SearchResult;
        }
    }
}
