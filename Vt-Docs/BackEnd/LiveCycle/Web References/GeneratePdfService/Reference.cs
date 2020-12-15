﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.1.
// 
#pragma warning disable 1591

namespace LiveCycle.GeneratePdfService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="GeneratePdfServiceSoapBinding", Namespace="http://adobe.com/idp/services")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ExportPDFResult))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CreatePDFResult))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(HtmlToPdfResult))]
    public partial class GeneratePDFServiceService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CreatePDFOperationCompleted;
        
        private System.Threading.SendOrPostCallback HtmlToPDFOperationCompleted;
        
        private System.Threading.SendOrPostCallback ExportPDFOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public GeneratePDFServiceService() {
            this.Url = global::LiveCycle.Properties.Settings.Default.LiveCycle_GeneratePdfService_GeneratePDFServiceService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event CreatePDFCompletedEventHandler CreatePDFCompleted;
        
        /// <remarks/>
        public event HtmlToPDFCompletedEventHandler HtmlToPDFCompleted;
        
        /// <remarks/>
        public event ExportPDFCompletedEventHandler ExportPDFCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("CreatePDF", RequestNamespace="http://adobe.com/idp/services", ResponseNamespace="http://adobe.com/idp/services", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("Result")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute("item", Namespace="http://xml.apache.org/xml-soap", IsNullable=false)]
        public mapItem[] CreatePDF(BLOB inputDocument, string fileName, string fileTypeSettings, string pdfSettings, string securitySettings, BLOB settingsDocument, BLOB xmpDocument) {
            object[] results = this.Invoke("CreatePDF", new object[] {
                        inputDocument,
                        fileName,
                        fileTypeSettings,
                        pdfSettings,
                        securitySettings,
                        settingsDocument,
                        xmpDocument});
            return ((mapItem[])(results[0]));
        }
        
        /// <remarks/>
        public void CreatePDFAsync(BLOB inputDocument, string fileName, string fileTypeSettings, string pdfSettings, string securitySettings, BLOB settingsDocument, BLOB xmpDocument) {
            this.CreatePDFAsync(inputDocument, fileName, fileTypeSettings, pdfSettings, securitySettings, settingsDocument, xmpDocument, null);
        }
        
        /// <remarks/>
        public void CreatePDFAsync(BLOB inputDocument, string fileName, string fileTypeSettings, string pdfSettings, string securitySettings, BLOB settingsDocument, BLOB xmpDocument, object userState) {
            if ((this.CreatePDFOperationCompleted == null)) {
                this.CreatePDFOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreatePDFOperationCompleted);
            }
            this.InvokeAsync("CreatePDF", new object[] {
                        inputDocument,
                        fileName,
                        fileTypeSettings,
                        pdfSettings,
                        securitySettings,
                        settingsDocument,
                        xmpDocument}, this.CreatePDFOperationCompleted, userState);
        }
        
        private void OnCreatePDFOperationCompleted(object arg) {
            if ((this.CreatePDFCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreatePDFCompleted(this, new CreatePDFCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("HtmlToPDF", RequestNamespace="http://adobe.com/idp/services", ResponseNamespace="http://adobe.com/idp/services", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("Result")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute("item", Namespace="http://xml.apache.org/xml-soap", IsNullable=false)]
        public mapItem[] HtmlToPDF(string inputURL, string fileTypeSettings, string securitySettings, BLOB settingsDocument, BLOB xmpDocument) {
            object[] results = this.Invoke("HtmlToPDF", new object[] {
                        inputURL,
                        fileTypeSettings,
                        securitySettings,
                        settingsDocument,
                        xmpDocument});
            return ((mapItem[])(results[0]));
        }
        
        /// <remarks/>
        public void HtmlToPDFAsync(string inputURL, string fileTypeSettings, string securitySettings, BLOB settingsDocument, BLOB xmpDocument) {
            this.HtmlToPDFAsync(inputURL, fileTypeSettings, securitySettings, settingsDocument, xmpDocument, null);
        }
        
        /// <remarks/>
        public void HtmlToPDFAsync(string inputURL, string fileTypeSettings, string securitySettings, BLOB settingsDocument, BLOB xmpDocument, object userState) {
            if ((this.HtmlToPDFOperationCompleted == null)) {
                this.HtmlToPDFOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHtmlToPDFOperationCompleted);
            }
            this.InvokeAsync("HtmlToPDF", new object[] {
                        inputURL,
                        fileTypeSettings,
                        securitySettings,
                        settingsDocument,
                        xmpDocument}, this.HtmlToPDFOperationCompleted, userState);
        }
        
        private void OnHtmlToPDFOperationCompleted(object arg) {
            if ((this.HtmlToPDFCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HtmlToPDFCompleted(this, new HtmlToPDFCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("ExportPDF", RequestNamespace="http://adobe.com/idp/services", ResponseNamespace="http://adobe.com/idp/services", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("Result")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute("item", Namespace="http://xml.apache.org/xml-soap", IsNullable=false)]
        public mapItem[] ExportPDF(BLOB inputDocument, string fileName, string formatType, BLOB settingsDocument) {
            object[] results = this.Invoke("ExportPDF", new object[] {
                        inputDocument,
                        fileName,
                        formatType,
                        settingsDocument});
            return ((mapItem[])(results[0]));
        }
        
        /// <remarks/>
        public void ExportPDFAsync(BLOB inputDocument, string fileName, string formatType, BLOB settingsDocument) {
            this.ExportPDFAsync(inputDocument, fileName, formatType, settingsDocument, null);
        }
        
        /// <remarks/>
        public void ExportPDFAsync(BLOB inputDocument, string fileName, string formatType, BLOB settingsDocument, object userState) {
            if ((this.ExportPDFOperationCompleted == null)) {
                this.ExportPDFOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExportPDFOperationCompleted);
            }
            this.InvokeAsync("ExportPDF", new object[] {
                        inputDocument,
                        fileName,
                        formatType,
                        settingsDocument}, this.ExportPDFOperationCompleted, userState);
        }
        
        private void OnExportPDFOperationCompleted(object arg) {
            if ((this.ExportPDFCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExportPDFCompleted(this, new ExportPDFCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adobe.com/idp/services")]
    public partial class BLOB {
        
        private string contentTypeField;
        
        private byte[] binaryDataField;
        
        private string attachmentIDField;
        
        private string remoteURLField;
        
        /// <remarks/>
        public string contentType {
            get {
                return this.contentTypeField;
            }
            set {
                this.contentTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] binaryData {
            get {
                return this.binaryDataField;
            }
            set {
                this.binaryDataField = value;
            }
        }
        
        /// <remarks/>
        public string attachmentID {
            get {
                return this.attachmentIDField;
            }
            set {
                this.attachmentIDField = value;
            }
        }
        
        /// <remarks/>
        public string remoteURL {
            get {
                return this.remoteURLField;
            }
            set {
                this.remoteURLField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adobe.com/idp/services")]
    public partial class ExportPDFResult {
        
        private BLOB convertedDocumentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public BLOB convertedDocument {
            get {
                return this.convertedDocumentField;
            }
            set {
                this.convertedDocumentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adobe.com/idp/services")]
    public partial class CreatePDFResult {
        
        private BLOB createdDocumentField;
        
        private BLOB logDocumentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public BLOB createdDocument {
            get {
                return this.createdDocumentField;
            }
            set {
                this.createdDocumentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public BLOB logDocument {
            get {
                return this.logDocumentField;
            }
            set {
                this.logDocumentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://adobe.com/idp/services")]
    public partial class HtmlToPdfResult {
        
        private BLOB createdDocumentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public BLOB createdDocument {
            get {
                return this.createdDocumentField;
            }
            set {
                this.createdDocumentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://xml.apache.org/xml-soap")]
    public partial class mapItem {
        
        private object keyField;
        
        private object valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public object key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public object value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void CreatePDFCompletedEventHandler(object sender, CreatePDFCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreatePDFCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreatePDFCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public mapItem[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((mapItem[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void HtmlToPDFCompletedEventHandler(object sender, HtmlToPDFCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HtmlToPDFCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HtmlToPDFCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public mapItem[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((mapItem[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ExportPDFCompletedEventHandler(object sender, ExportPDFCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExportPDFCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ExportPDFCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public mapItem[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((mapItem[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591