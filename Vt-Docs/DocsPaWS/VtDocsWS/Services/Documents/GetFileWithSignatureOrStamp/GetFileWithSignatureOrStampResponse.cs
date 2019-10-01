﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace VtDocsWS.Services.Documents.GetFileWithSignatureOrStamp
{
    /// <summary>
    /// Oggetto contenente i dati di risposta restituiti dal servizio di "GetFileWithSignatureResponse"
    /// </summary>
   [DataContract]
    public class GetFileWithSignatureOrStampResponse : Response
    {
        /// <summary>
        /// Dettaglio del documento
        /// </summary>
         [DataMember]
        public Domain.File File
        {
            get;
            set;
        }
    }
}