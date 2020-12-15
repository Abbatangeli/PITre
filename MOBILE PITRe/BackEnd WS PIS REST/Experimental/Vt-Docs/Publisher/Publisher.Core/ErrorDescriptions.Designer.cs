﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Publisher {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ErrorDescriptions {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorDescriptions() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Publisher.ErrorDescriptions", typeof(ErrorDescriptions).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Il tipo mapper &apos;{0}&apos; non è valido.
        /// </summary>
        internal static string INVALID_MAPPER_OBJECT_TYPE {
            get {
                return ResourceManager.GetString("INVALID_MAPPER_OBJECT_TYPE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tipo oggetto &apos;{0}&apos; non valido o non gestito dalla pubblicazione.
        /// </summary>
        internal static string INVALID_OBJECT_TYPE {
            get {
                return ResourceManager.GetString("INVALID_OBJECT_TYPE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errore nel mapping dell&apos;oggetto da pubblicare con Id &apos;{0}&apos;, Tipo &apos;{1}&apos;. Motivo: {2}.
        /// </summary>
        internal static string MAP_OBJECT_ERROR {
            get {
                return ResourceManager.GetString("MAP_OBJECT_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operazione non consentita.
        /// </summary>
        internal static string OPERATION_NOT_ALLOWED {
            get {
                return ResourceManager.GetString("OPERATION_NOT_ALLOWED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operazione non consentita, il servizio è attualmente in stato Attivo.
        /// </summary>
        internal static string OPERATION_NOT_ALLOWED_PER_SERVICE_STARTED {
            get {
                return ResourceManager.GetString("OPERATION_NOT_ALLOWED_PER_SERVICE_STARTED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operazione non consentita, il servizio è attualmente in stato Fermo.
        /// </summary>
        internal static string OPERATION_NOT_ALLOWED_PER_SERVICE_STOPPED {
            get {
                return ResourceManager.GetString("OPERATION_NOT_ALLOWED_PER_SERVICE_STOPPED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Canale di pubblicazione &apos;{0}&apos; non trovato.
        /// </summary>
        internal static string PUBLISH_CHANNEL_NOT_FOUND {
            get {
                return ResourceManager.GetString("PUBLISH_CHANNEL_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ruolo &apos;{0}&apos; non trovato.
        /// </summary>
        internal static string ROLE_NOT_FOUND {
            get {
                return ResourceManager.GetString("ROLE_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La procedura non ha prodotto la modifica o cancellazione di alcun dato.
        /// </summary>
        internal static string SP_EXECUTE_NO_ROWS {
            get {
                return ResourceManager.GetString("SP_EXECUTE_NO_ROWS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errore nell&apos;esecuzione della procedura &apos;{0}&apos;: {1}.
        /// </summary>
        internal static string SP_EXECUTION_ERROR {
            get {
                return ResourceManager.GetString("SP_EXECUTION_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non è stato possibile avviare il canale di pubblicazione sul server &apos;{0}&apos;: {1}.
        /// </summary>
        internal static string START_CHANNEL_ON_REMOTE_SERVER_ERROR {
            get {
                return ResourceManager.GetString("START_CHANNEL_ON_REMOTE_SERVER_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non è stato possibile fermare il canale di pubblicazione sul server &apos;{0}&apos;: {1}.
        /// </summary>
        internal static string STOP_CHANNEL_ON_REMOTE_SERVER_ERROR {
            get {
                return ResourceManager.GetString("STOP_CHANNEL_ON_REMOTE_SERVER_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Non è stato possibile completare l&apos;operazione richiesta. Motivo: {0}.
        /// </summary>
        internal static string UNHANDLED_ERROR {
            get {
                return ResourceManager.GetString("UNHANDLED_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Utente &apos;{0}&apos; non trovato.
        /// </summary>
        internal static string USER_NOT_FOUND {
            get {
                return ResourceManager.GetString("USER_NOT_FOUND", resourceCulture);
            }
        }
    }
}