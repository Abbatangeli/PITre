﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.269.
// 
#pragma warning disable 1591

namespace RubricaComune.Proxy.Utenti {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="UtentiServicesSoap", Namespace="http://valueteam.com/rubrica")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SecurityCredentials))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CriterioRicerca[]))]
    public partial class UtentiServices : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private SecurityCreadentialsSoapHeader securityCreadentialsSoapHeaderValueField;
        
        private System.Threading.SendOrPostCallback ValidateCredentialsOperationCompleted;
        
        private System.Threading.SendOrPostCallback ChangePasswordOperationCompleted;
        
        private System.Threading.SendOrPostCallback SearchOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetOperationCompleted;
        
        private System.Threading.SendOrPostCallback InsertOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public UtentiServices() {
            this.Url = "http://localhost/Rubrica/UtentiServices.asmx";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public SecurityCreadentialsSoapHeader SecurityCreadentialsSoapHeaderValue {
            get {
                return this.securityCreadentialsSoapHeaderValueField;
            }
            set {
                this.securityCreadentialsSoapHeaderValueField = value;
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
        public event ValidateCredentialsCompletedEventHandler ValidateCredentialsCompleted;
        
        /// <remarks/>
        public event ChangePasswordCompletedEventHandler ChangePasswordCompleted;
        
        /// <remarks/>
        public event SearchCompletedEventHandler SearchCompleted;
        
        /// <remarks/>
        public event GetCompletedEventHandler GetCompleted;
        
        /// <remarks/>
        public event InsertCompletedEventHandler InsertCompleted;
        
        /// <remarks/>
        public event UpdateCompletedEventHandler UpdateCompleted;
        
        /// <remarks/>
        public event DeleteCompletedEventHandler DeleteCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityCreadentialsSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://valueteam.com/rubrica/ValidateCredentials", RequestNamespace="http://valueteam.com/rubrica", ResponseNamespace="http://valueteam.com/rubrica", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public SecurityCredentialsResult ValidateCredentials() {
            object[] results = this.Invoke("ValidateCredentials", new object[0]);
            return ((SecurityCredentialsResult)(results[0]));
        }
        
        /// <remarks/>
        public void ValidateCredentialsAsync() {
            this.ValidateCredentialsAsync(null);
        }
        
        /// <remarks/>
        public void ValidateCredentialsAsync(object userState) {
            if ((this.ValidateCredentialsOperationCompleted == null)) {
                this.ValidateCredentialsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnValidateCredentialsOperationCompleted);
            }
            this.InvokeAsync("ValidateCredentials", new object[0], this.ValidateCredentialsOperationCompleted, userState);
        }
        
        private void OnValidateCredentialsOperationCompleted(object arg) {
            if ((this.ValidateCredentialsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ValidateCredentialsCompleted(this, new ValidateCredentialsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityCreadentialsSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://valueteam.com/rubrica/ChangePassword", RequestNamespace="http://valueteam.com/rubrica", ResponseNamespace="http://valueteam.com/rubrica", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ChangePassword(ChangePwdSecurityCredentials credentials) {
            this.Invoke("ChangePassword", new object[] {
                        credentials});
        }
        
        /// <remarks/>
        public void ChangePasswordAsync(ChangePwdSecurityCredentials credentials) {
            this.ChangePasswordAsync(credentials, null);
        }
        
        /// <remarks/>
        public void ChangePasswordAsync(ChangePwdSecurityCredentials credentials, object userState) {
            if ((this.ChangePasswordOperationCompleted == null)) {
                this.ChangePasswordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnChangePasswordOperationCompleted);
            }
            this.InvokeAsync("ChangePassword", new object[] {
                        credentials}, this.ChangePasswordOperationCompleted, userState);
        }
        
        private void OnChangePasswordOperationCompleted(object arg) {
            if ((this.ChangePasswordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ChangePasswordCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityCreadentialsSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://valueteam.com/rubrica/Search", RequestNamespace="http://valueteam.com/rubrica", ResponseNamespace="http://valueteam.com/rubrica", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Utente[] Search(ref OpzioniRicerca opzioniRicerca) {
            object[] results = this.Invoke("Search", new object[] {
                        opzioniRicerca});
            opzioniRicerca = ((OpzioniRicerca)(results[1]));
            return ((Utente[])(results[0]));
        }
        
        /// <remarks/>
        public void SearchAsync(OpzioniRicerca opzioniRicerca) {
            this.SearchAsync(opzioniRicerca, null);
        }
        
        /// <remarks/>
        public void SearchAsync(OpzioniRicerca opzioniRicerca, object userState) {
            if ((this.SearchOperationCompleted == null)) {
                this.SearchOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchOperationCompleted);
            }
            this.InvokeAsync("Search", new object[] {
                        opzioniRicerca}, this.SearchOperationCompleted, userState);
        }
        
        private void OnSearchOperationCompleted(object arg) {
            if ((this.SearchCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SearchCompleted(this, new SearchCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityCreadentialsSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://valueteam.com/rubrica/Get", RequestNamespace="http://valueteam.com/rubrica", ResponseNamespace="http://valueteam.com/rubrica", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Utente Get(int id) {
            object[] results = this.Invoke("Get", new object[] {
                        id});
            return ((Utente)(results[0]));
        }
        
        /// <remarks/>
        public void GetAsync(int id) {
            this.GetAsync(id, null);
        }
        
        /// <remarks/>
        public void GetAsync(int id, object userState) {
            if ((this.GetOperationCompleted == null)) {
                this.GetOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOperationCompleted);
            }
            this.InvokeAsync("Get", new object[] {
                        id}, this.GetOperationCompleted, userState);
        }
        
        private void OnGetOperationCompleted(object arg) {
            if ((this.GetCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCompleted(this, new GetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityCreadentialsSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://valueteam.com/rubrica/Insert", RequestNamespace="http://valueteam.com/rubrica", ResponseNamespace="http://valueteam.com/rubrica", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Utente Insert(Utente utente) {
            object[] results = this.Invoke("Insert", new object[] {
                        utente});
            return ((Utente)(results[0]));
        }
        
        /// <remarks/>
        public void InsertAsync(Utente utente) {
            this.InsertAsync(utente, null);
        }
        
        /// <remarks/>
        public void InsertAsync(Utente utente, object userState) {
            if ((this.InsertOperationCompleted == null)) {
                this.InsertOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertOperationCompleted);
            }
            this.InvokeAsync("Insert", new object[] {
                        utente}, this.InsertOperationCompleted, userState);
        }
        
        private void OnInsertOperationCompleted(object arg) {
            if ((this.InsertCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertCompleted(this, new InsertCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityCreadentialsSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://valueteam.com/rubrica/Update", RequestNamespace="http://valueteam.com/rubrica", ResponseNamespace="http://valueteam.com/rubrica", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Utente Update(Utente utente) {
            object[] results = this.Invoke("Update", new object[] {
                        utente});
            return ((Utente)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateAsync(Utente utente) {
            this.UpdateAsync(utente, null);
        }
        
        /// <remarks/>
        public void UpdateAsync(Utente utente, object userState) {
            if ((this.UpdateOperationCompleted == null)) {
                this.UpdateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateOperationCompleted);
            }
            this.InvokeAsync("Update", new object[] {
                        utente}, this.UpdateOperationCompleted, userState);
        }
        
        private void OnUpdateOperationCompleted(object arg) {
            if ((this.UpdateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateCompleted(this, new UpdateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityCreadentialsSoapHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://valueteam.com/rubrica/Delete", RequestNamespace="http://valueteam.com/rubrica", ResponseNamespace="http://valueteam.com/rubrica", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Delete(Utente utente) {
            this.Invoke("Delete", new object[] {
                        utente});
        }
        
        /// <remarks/>
        public void DeleteAsync(Utente utente) {
            this.DeleteAsync(utente, null);
        }
        
        /// <remarks/>
        public void DeleteAsync(Utente utente, object userState) {
            if ((this.DeleteOperationCompleted == null)) {
                this.DeleteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteOperationCompleted);
            }
            this.InvokeAsync("Delete", new object[] {
                        utente}, this.DeleteOperationCompleted, userState);
        }
        
        private void OnDeleteOperationCompleted(object arg) {
            if ((this.DeleteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://valueteam.com/rubrica", IsNullable=false)]
    public partial class SecurityCreadentialsSoapHeader : System.Web.Services.Protocols.SoapHeader {
        
        private string userNameField;
        
        private string passwordField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
        
        /// <remarks/>
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class Utente {
        
        private int idField;
        
        private string nomeField;
        
        private string passwordField;
        
        private bool amministratoreField;
        
        private System.DateTime dataCreazioneField;
        
        private System.DateTime dataUltimaModificaField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Nome {
            get {
                return this.nomeField;
            }
            set {
                this.nomeField = value;
            }
        }
        
        /// <remarks/>
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        public bool Amministratore {
            get {
                return this.amministratoreField;
            }
            set {
                this.amministratoreField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DataCreazione {
            get {
                return this.dataCreazioneField;
            }
            set {
                this.dataCreazioneField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DataUltimaModifica {
            get {
                return this.dataUltimaModificaField;
            }
            set {
                this.dataUltimaModificaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class CriterioOrdinamento {
        
        private string nomeField;
        
        private TipiOrdinamentoEnum tipoField;
        
        /// <remarks/>
        public string Nome {
            get {
                return this.nomeField;
            }
            set {
                this.nomeField = value;
            }
        }
        
        /// <remarks/>
        public TipiOrdinamentoEnum Tipo {
            get {
                return this.tipoField;
            }
            set {
                this.tipoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public enum TipiOrdinamentoEnum {
        
        /// <remarks/>
        Asc,
        
        /// <remarks/>
        Desc,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class CriteriOrdinamento {
        
        private CriterioOrdinamento[] criteriField;
        
        /// <remarks/>
        public CriterioOrdinamento[] Criteri {
            get {
                return this.criteriField;
            }
            set {
                this.criteriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class CriteriPaginazione {
        
        private int paginaField;
        
        private int oggettiPerPaginaField;
        
        private int totalePagineField;
        
        private int totaleOggettiField;
        
        /// <remarks/>
        public int Pagina {
            get {
                return this.paginaField;
            }
            set {
                this.paginaField = value;
            }
        }
        
        /// <remarks/>
        public int OggettiPerPagina {
            get {
                return this.oggettiPerPaginaField;
            }
            set {
                this.oggettiPerPaginaField = value;
            }
        }
        
        /// <remarks/>
        public int TotalePagine {
            get {
                return this.totalePagineField;
            }
            set {
                this.totalePagineField = value;
            }
        }
        
        /// <remarks/>
        public int TotaleOggetti {
            get {
                return this.totaleOggettiField;
            }
            set {
                this.totaleOggettiField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class CriterioRicerca {
        
        private TipiRicercaParolaEnum tipoRicercaField;
        
        private string nomeField;
        
        private object valoreField;
        
        /// <remarks/>
        public TipiRicercaParolaEnum TipoRicerca {
            get {
                return this.tipoRicercaField;
            }
            set {
                this.tipoRicercaField = value;
            }
        }
        
        /// <remarks/>
        public string Nome {
            get {
                return this.nomeField;
            }
            set {
                this.nomeField = value;
            }
        }
        
        /// <remarks/>
        public object Valore {
            get {
                return this.valoreField;
            }
            set {
                this.valoreField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public enum TipiRicercaParolaEnum {
        
        /// <remarks/>
        ParolaIntera,
        
        /// <remarks/>
        ParteDellaParola,
        
        /// <remarks/>
        ParolaIniziaCon,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class CriteriRicerca {
        
        private CriterioRicerca[] criteriField;
        
        /// <remarks/>
        public CriterioRicerca[] Criteri {
            get {
                return this.criteriField;
            }
            set {
                this.criteriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class OpzioniRicerca {
        
        private CriteriRicerca criteriRicercaField;
        
        private CriteriPaginazione criteriPaginazioneField;
        
        private CriteriOrdinamento criteriOrdinamentoField;
        
        /// <remarks/>
        public CriteriRicerca CriteriRicerca {
            get {
                return this.criteriRicercaField;
            }
            set {
                this.criteriRicercaField = value;
            }
        }
        
        /// <remarks/>
        public CriteriPaginazione CriteriPaginazione {
            get {
                return this.criteriPaginazioneField;
            }
            set {
                this.criteriPaginazioneField = value;
            }
        }
        
        /// <remarks/>
        public CriteriOrdinamento CriteriOrdinamento {
            get {
                return this.criteriOrdinamentoField;
            }
            set {
                this.criteriOrdinamentoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ChangePwdSecurityCredentials))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class SecurityCredentials {
        
        private string userNameField;
        
        private string passwordField;
        
        /// <remarks/>
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
        
        /// <remarks/>
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class ChangePwdSecurityCredentials : SecurityCredentials {
        
        private string newPasswordField;
        
        /// <remarks/>
        public string NewPassword {
            get {
                return this.newPasswordField;
            }
            set {
                this.newPasswordField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.233")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://valueteam.com/rubrica")]
    public partial class SecurityCredentialsResult {
        
        private string userNameField;
        
        private bool amministratoreField;
        
        /// <remarks/>
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
        
        /// <remarks/>
        public bool Amministratore {
            get {
                return this.amministratoreField;
            }
            set {
                this.amministratoreField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ValidateCredentialsCompletedEventHandler(object sender, ValidateCredentialsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ValidateCredentialsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ValidateCredentialsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public SecurityCredentialsResult Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((SecurityCredentialsResult)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ChangePasswordCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SearchCompletedEventHandler(object sender, SearchCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SearchCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SearchCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Utente[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Utente[])(this.results[0]));
            }
        }
        
        /// <remarks/>
        public OpzioniRicerca opzioniRicerca {
            get {
                this.RaiseExceptionIfNecessary();
                return ((OpzioniRicerca)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetCompletedEventHandler(object sender, GetCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Utente Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Utente)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void InsertCompletedEventHandler(object sender, InsertCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class InsertCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal InsertCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Utente Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Utente)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void UpdateCompletedEventHandler(object sender, UpdateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Utente Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Utente)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void DeleteCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591