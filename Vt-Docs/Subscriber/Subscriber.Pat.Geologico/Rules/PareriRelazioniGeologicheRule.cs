﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Subscriber.Pat.Geologico.Rules
{
    /// <summary>
    /// 
    /// </summary>
    public class PareriRelazioniGeologicheRule : ServizioGeologicoBaseRule
    {
        #region Public Members

        /// <summary>
        /// Reperimento del nome della regola
        /// </summary>
        public override string RuleName
        {
            get
            {
                return RULE_NAME;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string[] GetSubRules()
        {
            return new string[0];
        }

        #endregion

        #region Private Members

        /// <summary>
        /// 
        /// </summary>
        protected static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(SondeGeotermicheRule));

        /// <summary>
        /// Nome della regola
        /// </summary>
        private const string RULE_NAME = "PARERI_E_RELAZIONI_GEOLOGICHE_RULE";

        /// <summary>
        /// Nome del tipo fascicolo in PITRE
        /// </summary>
        private const string TEMPLATE_NAME = "Pareri e Relazioni Geologiche";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string GetTemplateName()
        {
            return TEMPLATE_NAME;
        }

        #endregion
    }
}
