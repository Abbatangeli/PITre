using System;
using System.Collections.Generic;
using System.Text;
using DocsPaDocumentale.Interfaces;
using DocsPaVO.amministrazione;
using DocsPaVO.utente;
using OrganigrammaManagerETDOCS = DocsPaDocumentale_ETDOCS.Documentale.OrganigrammaManager;


namespace DocsPaDocumentale_GFD.Documentale
{
    /// <summary>
    /// Gestione dell'organigramma dell'amministrazione
    /// </summary>
    public class OrganigrammaManager : IOrganigrammaManager
    {
        #region Ctors, constants, variables

        /// <summary>
        /// 
        /// </summary>
        private OrganigrammaManagerETDOCS _orgManagerETDOCS = null;

        /// <summary>
        /// Credenziali utente
        /// </summary>
        private InfoUtente _infoUtente = null;

        public OrganigrammaManager(InfoUtente infoUtente)
        {
            this._infoUtente = infoUtente;

            this._orgManagerETDOCS = new OrganigrammaManagerETDOCS(this._infoUtente);
            
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Inserimento nuovo ruolo in amministrazione
        /// </summary>
        /// <param name="ruolo"></param>
        /// <returns></returns>
        public EsitoOperazione InserisciRuolo(OrgRuolo ruolo, bool computeAtipicita)
        {
            // Inserimento del ruolo nel documentale ETDOCS
            EsitoOperazione result = this.OrganigrammaManagerETDOCS.InserisciRuolo(ruolo, computeAtipicita);

            return result;
        }

        /// <summary>
        /// Modifica dei metadati di un ruolo
        /// </summary>
        /// <param name="ruolo"></param>
        /// <returns></returns>
        public EsitoOperazione ModificaRuolo(OrgRuolo ruolo)
        {
            // Modifica del ruolo nel documentale ETDOCS
            EsitoOperazione result = this.OrganigrammaManagerETDOCS.ModificaRuolo(ruolo);

            return result;
        }

        /// <summary>
        /// Informa lamministratore se il ruolo ha documenti associati(in questo caso 
        /// il ruolo pu� essere solo disabilitato)
        /// </summary>
        /// <param name="ruolo"></param>
        /// <returns></returns>
        public EsitoOperazione OnlyDisabledRole(OrgRuolo ruolo)
        {
            //documentale ETDOCS
            EsitoOperazione result = this.OrganigrammaManagerETDOCS.OnlyDisabledRole(ruolo);
            return result;
        }

        /// <summary>
        /// Cancellazione di un ruolo in amministrazione
        /// </summary>
        /// <param name="ruolo"></param>
        /// <returns></returns>
        public EsitoOperazione EliminaRuolo(OrgRuolo ruolo)
        {
            // Eliminazione del ruolo nel documentale ETDOCS
            EsitoOperazione result = this.OrganigrammaManagerETDOCS.EliminaRuolo(ruolo);

            
            return result;
        }

        /// <summary>
        /// Spostamento di un ruolo in amministrazione
        /// </summary>
        /// <param name="ruolo"></param>
        /// <returns></returns>
        public EsitoOperazione SpostaRuolo(OrgRuolo ruolo)
        {
            // Spostamento del ruolo nel documentale ETDOCS
            EsitoOperazione result = this.OrganigrammaManagerETDOCS.SpostaRuolo(ruolo);



            return result;
        }

        /// <summary>
        /// Impostazione di un ruolo come predefinito
        /// </summary>
        /// <param name="idPeople"></param>
        /// <param name="idGruppo"></param>
        /// <returns></returns>
        public EsitoOperazione ImpostaRuoloPreferito(string idPeople, string idGruppo)
        {
            // Operazione nel documentale ETDOCS
            return this.OrganigrammaManagerETDOCS.ImpostaRuoloPreferito(idPeople, idGruppo);
        }

        /// <summary>
        /// Inserimento di un nuovo utente in amministrazione
        /// </summary>
        /// <param name="utente"></param>
        /// <returns></returns>
        public EsitoOperazione InserisciUtente(OrgUtente utente)
        {
            // Inserimento utente nel documentale ETDOCS
            EsitoOperazione result = this.OrganigrammaManagerETDOCS.InserisciUtente(utente);

           
            return result;
        }

        /// <summary>
        /// Modifica dei dati di un utente in amministrazione
        /// </summary>
        /// <param name="utente"></param>
        /// <returns></returns>
        public EsitoOperazione ModificaUtente(OrgUtente utente)
        {
            // Modifica utente nel documentale ETDOCS
            EsitoOperazione result = this.OrganigrammaManagerETDOCS.ModificaUtente(utente);

            return result;
        }

        /// <summary>
        /// Elimina un utente in amministrazione
        /// </summary>
        /// <param name="utente"></param>
        /// <returns></returns>
        public EsitoOperazione EliminaUtente(OrgUtente utente)
        {
            // Eliminazione utente nel documentale ETDOCS
            EsitoOperazione result = this.OrganigrammaManagerETDOCS.EliminaUtente(utente);

            

            return result;
        }

        /// <summary>
        /// Inserimento di un utente in un ruolo
        /// </summary>
        /// <param name="idPeople"></param>
        /// <param name="idGruppo"></param>
        /// <returns></returns>
        public EsitoOperazione InserisciUtenteInRuolo(string idPeople, string idGruppo)
        {
            // Inserimento utente in un ruolo nel documentale ETDOCS
            EsitoOperazione result = this.OrganigrammaManagerETDOCS.InserisciUtenteInRuolo(idPeople, idGruppo);

            
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPeople"></param>
        /// <param name="idGruppo"></param>
        /// <returns></returns>
        public EsitoOperazione EliminaUtenteDaRuolo(string idPeople, string idGruppo)
        {
            // Eliminazione utente in un ruolo nel documentale ETDOCS
            EsitoOperazione result = this.OrganigrammaManagerETDOCS.EliminaUtenteDaRuolo(idPeople, idGruppo);

           
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="infoUtente"></param>
        /// <param name="copyVisibility"></param>
        /// <returns></returns>
        public EsitoOperazione CopyVisibility(DocsPaVO.utente.InfoUtente infoUtente, DocsPaVO.Security.CopyVisibility copyVisibility)
        {
            EsitoOperazione result = this.OrganigrammaManagerETDOCS.CopyVisibility(infoUtente, copyVisibility);

            return result;
        }

        public OrgRuolo HistoricizeRole(OrgRuolo role)
        {
            OrgRuolo retVal = this.OrganigrammaManagerETDOCS.HistoricizeRole(role);

            return retVal;
        }

        /// <summary>
        /// Metodo per l'estensione di visibilit� ai ruoli superiori di un ruolo
        /// </summary>
        /// <param name="idAmm">Id dell'amministrazione</param>
        /// <param name="idGroup">Id del gruppo di cui estendere la visibilit�</param>
        /// <param name="extendScope">Scope di estensione</param>
        /// <param name="copyIdToTempTable">True se bisogna copiare gli id id dei documenti e fascicoli in una tabella tamporanea per l'allineamento asincrono della visibilit�</param>
        /// <returns>Esito dell'operazione</returns>
        public EsitoOperazione ExtendVisibilityToHigherRoles(
            String idAmm,
            String idGroup,
            DocsPaVO.amministrazione.SaveChangesToRoleRequest.ExtendVisibilityOption extendScope)
        {
            // Invocazione dell'operazione su EtDocs
            return this.OrganigrammaManagerETDOCS.ExtendVisibilityToHigherRoles(idAmm, idGroup, extendScope);
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// 
        /// </summary>
        protected InfoUtente InfoUtente
        {
            get
            {
                return this._infoUtente;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected OrganigrammaManagerETDOCS OrganigrammaManagerETDOCS
        {
            get
            {
                return this._orgManagerETDOCS;
            }
        }

       

        #endregion


        public EsitoOperazione CalcolaAtipicita(OrgRuolo ruolo, string idTipoRuoloVecchio, string idVecchiaUo, bool calcolaSuiSottoposti)
        {
            return this.OrganigrammaManagerETDOCS.CalcolaAtipicita(ruolo, idTipoRuoloVecchio, idVecchiaUo, calcolaSuiSottoposti);
        }
    }
}
