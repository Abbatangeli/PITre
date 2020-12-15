using System;
using System.Collections.Generic;
using System.Text;
using Emc.Documentum.FS.Runtime.Context;

namespace DocsPaDocumentale_DOCUMENTUM.DctmServices
{
    /// <summary>
    /// Classe di utilit� per il reperimento dell'oggetto ServiceContext corrente
    /// </summary>
    public sealed class DctmServiceContextHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IServiceContext GetCurrent()
        {
            ContextFactory contextFactory = ContextFactory.Instance;
            
            return contextFactory.GetContext();
        }
    }
}
