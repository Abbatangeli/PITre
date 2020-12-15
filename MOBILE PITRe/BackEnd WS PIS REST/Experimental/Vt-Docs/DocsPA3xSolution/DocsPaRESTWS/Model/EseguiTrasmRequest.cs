﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocsPaRESTWS.Model
{
    public class EseguiTrasmRequest
    {
        public string IdModelloTrasm
        {
            get;
            set;
        }

        public string IdDoc
        {
            get;
            set;
        }

        public string IdFasc
        {
            get;
            set;
        }

        public string IdCorrGlobali
        {
            get;
            set;
        }

        public string Note
        {
            get;
            set;
        }

        public string Path
        {
            get;
            set;
        }
    }
}