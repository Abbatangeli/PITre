﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace VtDocsWS.Services.Projects.GetProjectStateDiagram
{
    /// <summary>
    /// Oggetto contenente i dati di richiesta da fornire al servizio di "GetProjectStateDiagramRequest"
    /// </summary>
   [DataContract]
    public class GetProjectStateDiagramRequest : Request
    {
        /// <summary>
        /// Id del fascicolo
        /// </summary>
         [DataMember]
        public string IdProject
        {
            get;
            set;
        }

        /// <summary>
        /// Id del titolario
        /// </summary>
         [DataMember]
        public string ClassificationSchemeId
        {
            get;
            set;
        }

        /// <summary>
        /// Codice del fascicolo
        /// </summary>
         [DataMember]
        public string CodeProject
        {
            get;
            set;
        }
    }
}