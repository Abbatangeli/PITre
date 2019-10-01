using System;
using System.Collections;

namespace Amministrazione.Manager
{
	/// <summary>
	/// Classe per l'interazione con i servizi 
	/// per la gestione del titolario
	/// </summary>
	public class TitolarioManager
	{
		#region Public members

		public TitolarioManager()
		{
		}

		/// <summary>
		/// Reperimento di tutti i ruoli che hanno, tramite il registro,
		/// la visibilit� su un nodo di titolario.
		/// Se non viene fornito l'idRegistro, verranno ricercati i 
		/// ruoli in base a tutti i registri presenti nell'amministrazione richiesta.
		/// </summary>
		/// <param name="idAmministrazione"></param>
		/// <param name="idNodoTitolario"></param>
		/// <param name="idRegistro"></param>
		/// <returns></returns>
        public SAAdminTool.DocsPaWR.OrgRuoloTitolario[] GetRuoliInTitolario(string idNodoTitolario, string idRegistro, string codiceRicerca, string tipoRicerca)
		{
            SAAdminTool.DocsPaWR.DocsPaWebService ws = new SAAdminTool.DocsPaWR.DocsPaWebService();
            return ws.AmmGetRuoliInTitolario(idNodoTitolario, idRegistro, codiceRicerca, tipoRicerca);
		}

//		/// <summary>
//		/// Caricamento di tutti i ruoli che hanno la visibilit�
//		/// sul nodo di titolario (mediante il registro associato)
//		/// fornito in ingresso.
//		/// </summary>
//		/// <param name="nodoTitolario"></param>
//		public void FillListRuoliInTitolario(SAAdminTool.DocsPaWR.OrgNodoTitolario nodoTitolario)
//		{
//			DocsPaWR.DocsPaWebService ws=new SAAdminTool.DocsPaWR.DocsPaWebService();
//			ws.AmmFillListRuoliInTitolario(nodoTitolario);
//		}

		#endregion

		#region Private members

		#endregion
	}
}
