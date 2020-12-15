﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18408.
// 
#pragma warning disable 1591

namespace externalStamper {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="RemotePdfStamperSoap", Namespace="http://nttdata.com/2014/RPDFStampSvc")]
    public partial class RemotePdfStamper : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback RemotePdfStampOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public RemotePdfStamper() {
            this.Url = global::Properties.Settings.Default.DocsPaDigitalSignature_externalStamper_RemotePdfStamper;
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
        public event RemotePdfStampCompletedEventHandler RemotePdfStampCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://nttdata.com/2014/RPDFStampSvc/RemotePdfStamp", RequestNamespace="http://nttdata.com/2014/RPDFStampSvc", ResponseNamespace="http://nttdata.com/2014/RPDFStampSvc", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] RemotePdfStamp(int Page, int LeftX, int LeftY, int RightX, int RightY, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] PdfContent, string StampText) {
            object[] results = this.Invoke("RemotePdfStamp", new object[] {
                        Page,
                        LeftX,
                        LeftY,
                        RightX,
                        RightY,
                        PdfContent,
                        StampText});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public void RemotePdfStampAsync(int Page, int LeftX, int LeftY, int RightX, int RightY, byte[] PdfContent, string StampText) {
            this.RemotePdfStampAsync(Page, LeftX, LeftY, RightX, RightY, PdfContent, StampText, null);
        }
        
        /// <remarks/>
        public void RemotePdfStampAsync(int Page, int LeftX, int LeftY, int RightX, int RightY, byte[] PdfContent, string StampText, object userState) {
            if ((this.RemotePdfStampOperationCompleted == null)) {
                this.RemotePdfStampOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRemotePdfStampOperationCompleted);
            }
            this.InvokeAsync("RemotePdfStamp", new object[] {
                        Page,
                        LeftX,
                        LeftY,
                        RightX,
                        RightY,
                        PdfContent,
                        StampText}, this.RemotePdfStampOperationCompleted, userState);
        }
        
        private void OnRemotePdfStampOperationCompleted(object arg) {
            if ((this.RemotePdfStampCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RemotePdfStampCompleted(this, new RemotePdfStampCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void RemotePdfStampCompletedEventHandler(object sender, RemotePdfStampCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RemotePdfStampCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RemotePdfStampCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public byte[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591