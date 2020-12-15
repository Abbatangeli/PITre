using System;
using System.Web;
using System.Collections;
using DocsPAWA;

namespace ProtocollazioneIngresso.Registro
{
	/// <summary>
	/// Classe per la gestione dei registri relativamente 
	/// al ruolo selezionato per l'utente corrente in docspa
	/// </summary>
	public class RegistroMng 
	{
		private System.Web.UI.Page _page=null;

		private const string FUNZ_PROTOCOLLA_GIALLO="DO_PROT_PROTOCOLLAG";

		public RegistroMng(System.Web.UI.Page page)
		{
			this._page=page;
		}

		/// <summary>
		/// Reperimento di tutti i registri disponibili per il ruolo corrente
		/// </summary>
		/// <returns></returns>
		public DocsPAWA.DocsPaWR.Registro[] GetRegistri()
		{
			ProtocollazioneIngresso.Login.LoginMng loginMng=new ProtocollazioneIngresso.Login.LoginMng(this._page);

			DocsPAWA.DocsPaWR.DocsPaWebService ws=new DocsPAWA.DocsPaWR.DocsPaWebService();
			return ws.UtenteGetRegistri(loginMng.GetInfoUtente().idCorrGlobali);
		}

		public DocsPAWA.DocsPaWR.Registro[] GetRegistriAperti()
		{	
			DocsPAWA.DocsPaWR.Registro[] registri=this.GetRegistri();
		
			ArrayList arrayList=new ArrayList();
			
			bool isUtenteAbilitatoProtGiallo=this.IsUtenteAbilitatoProtGiallo();

			foreach (DocsPAWA.DocsPaWR.Registro registro in registri)
			{
				string statoRegistro=this.GetStatoRegistro(registro);
				
				// Il registro viene considerato solo se verde 
				// o giallo (solo se l'utente � abilitato alla prot in giallo)
				if ((statoRegistro=="G" && isUtenteAbilitatoProtGiallo) || statoRegistro=="V")
					arrayList.Add(registro);
			}

			DocsPAWA.DocsPaWR.Registro[] retValue=new DocsPAWA.DocsPaWR.Registro[arrayList.Count];
			arrayList.CopyTo(retValue);
			return retValue;
		}

		/// <summary>
		/// Impostazione del registro corrente
		/// </summary>
		/// <param name="codRegistro"></param>
		public void SetRegistroCorrente(string idRegistro)
		{
			DocsPAWA.DocsPaWR.Registro registro=this.GetRegistro(idRegistro);
			this._page.Session["ProtocollazioneIngresso.RegistroCorrente"]=registro;
			_page.Session["userRegistro"] = registro;
		}

		/// <summary>
		/// Restituzione del registro corrente della protocollazione in ingresso
		/// </summary>
		/// <returns></returns>
		public static DocsPAWA.DocsPaWR.Registro GetRegistroInSessione()
		{
			return HttpContext.Current.Session["ProtocollazioneIngresso.RegistroCorrente"] as DocsPAWA.DocsPaWR.Registro;
		}

		/// <summary>
		/// Restituzione del registro corrente della protocollazione in ingresso
		/// </summary>
		/// <returns></returns>
		public DocsPAWA.DocsPaWR.Registro GetRegistroCorrente()
		{
			return (DocsPAWA.DocsPaWR.Registro) 
				this._page.Session["ProtocollazioneIngresso.RegistroCorrente"];
		}

		/// <summary>
		/// Reperimento dello stato del registro
		/// </summary>
		/// <param name="registro"></param>
		/// <returns></returns>
		public string GetStatoRegistroCorrente()
		{
			// R = Rosso -  CHIUSO
			// V = Verde -  APERTO
			// G = Giallo - APERTO IN GIALLO
			return this.GetStatoRegistro(this.GetRegistroCorrente());
		}

		/// <summary>
		/// Modifica dello stato del registro
		/// </summary>
		/// <param name="registro"></param>
		public void CambiaStatoRegistroCorrente()
		{	
			DocsPAWA.DocsPaWR.DocsPaWebService ws=new DocsPAWA.DocsPaWR.DocsPaWebService();

			ProtocollazioneIngresso.Login.LoginMng loginMng=new ProtocollazioneIngresso.Login.LoginMng(this._page);
			DocsPAWA.DocsPaWR.Registro registro=ws.RegistriCambiaStato(loginMng.GetInfoUtente(),this.GetRegistroCorrente());
			
			this.SetRegistroCorrente(registro);
		}

		public void ReleaseRegistroCorrente()
		{
			this._page.Session.Remove("ProtocollazioneIngresso.RegistroCorrente");
		}
		
		public void SetRegistroCorrente(DocsPAWA.DocsPaWR.Registro registro)
		{
			this._page.Session["ProtocollazioneIngresso.RegistroCorrente"]=registro;
				_page.Session["userRegistro"] = registro;
		    
		}

		private DocsPAWA.DocsPaWR.Registro GetRegistro(string idRegistro)
		{
			DocsPAWA.DocsPaWR.Registro retValue=null;
			DocsPAWA.DocsPaWR.Registro[] registri=this.GetRegistri();
			
			foreach (DocsPAWA.DocsPaWR.Registro registro in registri)
			{
				if (registro.systemId.Equals(idRegistro))
				{
					retValue=registro;
					break;
				}
			}

			return retValue;
		}

		private string GetStatoRegistro(DocsPAWA.DocsPaWR.Registro registro)
		{
			return DocsPAWA.UserManager.getStatoRegistro(registro);
		}

		/// <summary>
		/// Verifica se l'utente corrente � abilitato alla protocollazione in giallo
		/// </summary>
		/// <returns></returns>
		private bool IsUtenteAbilitatoProtGiallo()
		{
			bool retValue=false;
			
			ProtocollazioneIngresso.Login.LoginMng loginMng=new ProtocollazioneIngresso.Login.LoginMng(this._page);
			DocsPAWA.DocsPaWR.Ruolo ruolo=loginMng.GetRuolo();

			foreach (DocsPAWA.DocsPaWR.Funzione funzione in ruolo.funzioni)
			{
				if (funzione.codice==FUNZ_PROTOCOLLA_GIALLO)
				{
					retValue=true;
					break;
				}
			}
			
			return retValue;
		}
	}
}
