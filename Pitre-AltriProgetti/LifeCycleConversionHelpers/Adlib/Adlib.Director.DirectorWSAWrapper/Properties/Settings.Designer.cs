﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Adlib.Director.DirectorWSAWrapper.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://asterix-att/Adlib/Services/ComponentManagement/ComponentManagementService." +
            "svc")]
        public string Adlib_Director_DirectorWSAWrapper_ComponentManagementService_ComponentManagementService {
            get {
                return ((string)(this["Adlib_Director_DirectorWSAWrapper_ComponentManagementService_ComponentManagementS" +
                    "ervice"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://asterix-att/Adlib/Services/UserManagement/UserManagementService.svc")]
        public string Adlib_Director_DirectorWSAWrapper_UserManagementService_UserManagementService {
            get {
                return ((string)(this["Adlib_Director_DirectorWSAWrapper_UserManagementService_UserManagementService"]));
            }
        }
    }
}
