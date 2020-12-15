using System;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

namespace DocsPaVO.amministrazione
{
	/// <summary>
	/// Definizione oggetto Unit� Organizzativa 
	/// relativo alla funzionalit� Organigramma in Amministrazione.
	/// </summary>
	public class OrgUO
	{
		public string IDCorrGlobale = string.Empty;

		public string Codice = string.Empty;
		
		public string CodiceRubrica = string.Empty;

		public string Descrizione = string.Empty;

		public string Livello = string.Empty;

		public string IDAmministrazione = string.Empty;

		public string CodiceRegistroInterop = string.Empty;

		public string Ruoli = string.Empty;

		public string SottoUo = string.Empty;	
		
		public string IDParent = string.Empty;

		public OrgDettagliGlobali DettagliUo = null;

        public string IDPeso = string.Empty;

        public string Classifica = string.Empty;

        /// <summary>
        /// Id del registro utilizzato per l'interoperabilit� semplificata. Se null, significa che 
        /// la UO non � interoperante
        /// </summary>
        public String IdRegistroInteroperabilitaSemplificata { get; set; }

        /// <summary>
        /// Id dell'RF utilizzato per l'interoperabilit� semplificata. 
        /// </summary>
        public String IdRfInteroperabilitaSemplificata { get; set; }

	}
}
