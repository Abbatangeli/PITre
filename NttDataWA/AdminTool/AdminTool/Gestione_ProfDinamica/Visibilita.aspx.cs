using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Linq;
using System.Collections.Generic;

namespace SAAdminTool.AdminTool.Gestione_ProfDinamica
{
    public partial class SessionVisibilita : System.Web.UI.Page
    {
        #region Session
        public void SetSessionListaRuoliSel(ArrayList listaRuoliSelezionati)
        {
            RemoveSessionListaRuoliSel();
            Session.Add("LISTA_RUOLI_SEL", listaRuoliSelezionati);
        }

        public ArrayList GetSessionListaRuoliSel()
        {
            return (ArrayList)Session["LISTA_RUOLI_SEL"];
        }

        public void RemoveSessionListaRuoliSel()
        {
            Session.Remove("LISTA_RUOLI_SEL");
        }

        public void SetSessionListaRuoli(ArrayList listaRuoli)
        {
            RemoveSessionListaRuoli();
            Session.Add("LISTA_RUOLI", listaRuoli);
        }

        public ArrayList GetSessionListaRuoli()
        {
            return (ArrayList)Session["LISTA_RUOLI"];
        }

        public void RemoveSessionListaRuoli()
        {
            Session.Remove("LISTA_RUOLI");
        }

        public void SetSessionHashTableRuoli(Hashtable hashTableRuoli)
        {
            RemoveSessionHashTableRuoli();
            Session.Add("HASHTABLE_LISTA_RUOLI", hashTableRuoli);
        }

        public Hashtable GetSessionHashTableRuoli()
        {
            return (Hashtable)Session["HASHTABLE_LISTA_RUOLI"];
        }

        public void RemoveSessionHashTableRuoli()
        {
            Session.Remove("HASHTABLE_LISTA_RUOLI");
        }
        
        public void setSessionIdRuolo(string idRuolo)
        {
            removeSessionIdRuolo();
            Session.Add("ID_RUOLO_SEL", idRuolo);
        }

        public void removeSessionIdRuolo()
        {
            Session.Remove("ID_RUOLO_SEL");                
        }

        public string getSessionIdRuolo()
        {
            return (string)Session["ID_RUOLO_SEL"];
        }
        #endregion Session
    }

    public partial class Visibilita : System.Web.UI.Page
    {
        private ArrayList listaRuoli;
        private ArrayList listaRuoliSelezionati;
        private Hashtable HTruoli;
        private ArrayList listaCampi;
        private ArrayList listaDirittiCampiSelezionati;
        
        private string idAmministrazione;
        private DocsPaWR.Templates template;
        SessionVisibilita sessionObj = new SessionVisibilita();

        #region Class RuoliHT
        public class RuoliHT
        {
            private string cod;
            private string descr;
            private string ins;
            private string ric;

            public RuoliHT()
            {
            }

            public RuoliHT(string cod, string descr, string ins, string ric)
            {
                this.cod = cod;
                this.descr = descr;
                this.ins = ins;
                this.ric = ric;
            }

            public string Cod { get { return cod; } }
            public string Descr { get { return descr; } }
            public string Ins { get { return ins; } }
            public string Ric { get { return ric; } }
        }
        #endregion Class RuoliHT

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.MaintainScrollPositionOnPostBack = true;

            template = (SAAdminTool.DocsPaWR.Templates)Session["templateSelPerVisibilita"];
            DocsPaWR.OggettoCustom[] elencoOggetti = (DocsPaWR.OggettoCustom[])template.ELENCO_OGGETTI.ToArray();
            DocsPaWR.OggettoCustom[] listaCampiSelezionati = elencoOggetti.Where(oggetto => !oggetto.TIPO.DESCRIZIONE_TIPO.ToUpper().Equals("SEPARATORE")).ToArray();
            listaCampi = new ArrayList(listaCampiSelezionati);
            
            if (template != null)
                lbl_titolo.Text = "TIPOLOGIA DOCUMENTO : " + template.DESCRIZIONE;

            if (!IsPostBack)
            {
                //Session.Add("reloadHT", false);
                //this.Inizialize();
                this.sessionObj.RemoveSessionListaRuoliSel();
                this.sessionObj.RemoveSessionListaRuoli();
                this.sessionObj.RemoveSessionHashTableRuoli();
                this.sessionObj.removeSessionIdRuolo();
            }
            else
            {
                impostaSelezioneRuoli();
            }
        }

        private void Inizialize()
        {                       
            string[] amministrazione = ((string)Session["AMMDATASET"]).Split('@');
            string codiceAmministrazione = amministrazione[0];
            idAmministrazione = Utils.getIdAmmByCod(codiceAmministrazione, this);

            listaRuoli = new ArrayList(ProfilazioneDocManager.getRuoliByAmm(idAmministrazione, "", "", this));
            sessionObj.SetSessionListaRuoli(listaRuoli);

            listaRuoliSelezionati = new ArrayList(ProfilazioneDocManager.getRuoliTipoDoc(template.ID_TIPO_ATTO, this));
            sessionObj.SetSessionListaRuoliSel(listaRuoliSelezionati);

            //bool reloadHT = (Boolean)Session["reloadHT"];
            //if (!reloadHT)
                caricaHTRuoli();
           
            caricaDgVisibilitaRuoli();

            impostaSelezioneRuoliAssociati();            
        }

        private void caricaHTRuoli()
        {
            listaRuoliSelezionati = sessionObj.GetSessionListaRuoliSel();
            listaRuoli = sessionObj.GetSessionListaRuoli();

            this.HTruoli = new Hashtable();
            RuoliHT r = new RuoliHT();
            bool ruoloSel;
            for (int i = 0; i < listaRuoli.Count; i++)
            {
                DocsPaWR.Ruolo ruolo = (SAAdminTool.DocsPaWR.Ruolo)listaRuoli[i];

                ruoloSel = false;
                if (listaRuoliSelezionati.Count != 0)
                {
                    for (int j = 0; j < listaRuoliSelezionati.Count; j++)
                    {
                        DocsPaWR.AssDocFascRuoli obj = (DocsPaWR.AssDocFascRuoli)listaRuoliSelezionati[j];
                        //Verifico che l'ID_GRUPPO non si a zero altrimenti la visibilit� � di tutti i ruoli
                        //Verifica necessaria per gestire la vecchia tipologia che non prevedeva la visibilit� per ruoli
                        if (obj.ID_GRUPPO == "0")
                        {
                            ruoloSel = true;
                            r = new RuoliHT(ruolo.codice, ruolo.descrizione, "1", "1");
                            this.HTruoli.Add(ruolo.idGruppo, r);
                            return;
                        }
                        
                        //In questo caso invece imposta le checkbox rispetto ai diritti del ruolo
                        if (ruolo.idGruppo == obj.ID_GRUPPO)
                        {
                            ruoloSel = true;
                            if (obj.DIRITTI_TIPOLOGIA == "0")
                            {
                                r = new RuoliHT(ruolo.codice, ruolo.descrizione, "0", "0");
                            }
                            if (obj.DIRITTI_TIPOLOGIA == "1")
                            {
                                r = new RuoliHT(ruolo.codice, ruolo.descrizione, "0", "1");
                            }
                            if (obj.DIRITTI_TIPOLOGIA == "2")
                            {
                                r = new RuoliHT(ruolo.codice, ruolo.descrizione, "1", "1");
                            }
                            this.HTruoli.Add(ruolo.idGruppo, r);
                        }
                    }

                }
                if (!ruoloSel)
                {
                    r = new RuoliHT(ruolo.codice,ruolo.descrizione, "0", "0");
                    this.HTruoli.Add(ruolo.idGruppo, r);
                }

            }
            sessionObj.SetSessionHashTableRuoli(HTruoli);
        }

        private void caricaDgVisibilitaRuoli()
        {
            listaRuoli = sessionObj.GetSessionListaRuoli();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID_GRUPPO");
            dt.Columns.Add("CODICE RUOLO");
            dt.Columns.Add("DESCRIZIONE RUOLO");
            for (int i = 0; i < listaRuoli.Count; i++)
            {
                DocsPaWR.Ruolo ruolo = (SAAdminTool.DocsPaWR.Ruolo)listaRuoli[i];
                DataRow rw = dt.NewRow();
                rw[0] = ruolo.idGruppo;
                rw[1] = ruolo.codice;
                rw[2] = ruolo.descrizione;
                dt.Rows.Add(rw);
            }
            dt.AcceptChanges();
            dg_Ruoli.DataSource = dt;
            dg_Ruoli.DataBind();

            if (dg_Ruoli.Items.Count == 0)
            {
                dg_Ruoli.Visible = false;
                lbl_ricercaRuoli.Text = "Nessun ruolo per questa ricerca!";
            }
            else
            {
                dg_Ruoli.Visible = true;
                lbl_ricercaRuoli.Text = "";
            }
        }

        private void caricaDgVisibilitaCampi()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_CAMPO");
            dt.Columns.Add("DESCRIZIONE");
            for (int i = 0; i < listaCampi.Count; i++)
            {
                DocsPaWR.OggettoCustom oggettoCustom = (SAAdminTool.DocsPaWR.OggettoCustom)listaCampi[i];
                DataRow rw = dt.NewRow();
                rw[0] = oggettoCustom.SYSTEM_ID;
                rw[1] = oggettoCustom.DESCRIZIONE;
                dt.Rows.Add(rw);
            }
            dt.AcceptChanges();
            dg_Campi.DataSource = dt;
            dg_Campi.DataBind();

            if (Utils.isEnableRepertori(template.ID_AMMINISTRAZIONE))
                dg_Campi.Columns[4].Visible = true;
            else
                dg_Campi.Columns[4].Visible = false;            
        }

        private void impostaSelezioneRuoli()
        {
            RuoliHT r = new RuoliHT();
            HTruoli = sessionObj.GetSessionHashTableRuoli();
            for (int j = 0; j < dg_Ruoli.Items.Count; j++)
            {
                if (HTruoli.Count != 0)
                {
                    if (HTruoli.ContainsKey(dg_Ruoli.Items[j].Cells[0].Text))
                    {
                        //if (((CheckBox)dg_Ruoli.Items[j].Cells[2].Controls[1]).Checked)
                        if (((CheckBox)dg_Ruoli.Items[j].Cells[3].Controls[1]).Checked)
                        {
                            r = new RuoliHT(dg_Ruoli.Items[j].Cells[1].Text, dg_Ruoli.Items[j].Cells[2].Text, "1", "1");
                            ((CheckBox)dg_Ruoli.Items[j].Cells[4].Controls[1]).Checked = true;
                            ((CheckBox)dg_Ruoli.Items[j].Cells[4].Controls[1]).Enabled = false;

                            //r = new RuoliHT(dg_Ruoli.Items[j].Cells[1].Text, "1", "1");
                            //((CheckBox)dg_Ruoli.Items[j].Cells[3].Controls[1]).Checked = true;
                            //((CheckBox)dg_Ruoli.Items[j].Cells[3].Controls[1]).Enabled = false;
                        }
                        //if (!((CheckBox)dg_Ruoli.Items[j].Cells[2].Controls[1]).Checked)
                        if (!((CheckBox)dg_Ruoli.Items[j].Cells[3].Controls[1]).Checked)
                        {
                            string ric = "0";
                            if (((CheckBox)dg_Ruoli.Items[j].Cells[4].Controls[1]).Checked)
                                ric = "1";
                            r = new RuoliHT(dg_Ruoli.Items[j].Cells[1].Text, dg_Ruoli.Items[j].Cells[2].Text, "0", ric);
                            ((CheckBox)dg_Ruoli.Items[j].Cells[4].Controls[1]).Enabled = true;

                            //string ric = "0";
                            //if (((CheckBox)dg_Ruoli.Items[j].Cells[3].Controls[1]).Checked)
                            //    ric = "1";
                            //r = new RuoliHT(dg_Ruoli.Items[j].Cells[1].Text, "0", ric);
                            //((CheckBox)dg_Ruoli.Items[j].Cells[3].Controls[1]).Enabled = true;
                        }

                      
                    }
                }
                HTruoli.Remove(dg_Ruoli.Items[j].Cells[0].Text);
                HTruoli.Add(dg_Ruoli.Items[j].Cells[0].Text, r);
            }
            sessionObj.SetSessionHashTableRuoli(HTruoli);
        }

        private void salvaSelezioneCampi()
        {
            if (dg_Campi.Items.Count > 0 && !string.IsNullOrEmpty(sessionObj.getSessionIdRuolo()) )
            {
                ArrayList listaDirittiCampiSelezionati = new ArrayList();
                for (int i = 0; i < listaCampi.Count; i++)
                {
                    DocsPaWR.AssDocFascRuoli assDocFascRuoli = new SAAdminTool.DocsPaWR.AssDocFascRuoli();
                    assDocFascRuoli.ID_TIPO_DOC_FASC = template.SYSTEM_ID.ToString();
                    assDocFascRuoli.ID_OGGETTO_CUSTOM = ((DocsPaWR.OggettoCustom) listaCampi[i]).SYSTEM_ID.ToString();
                    assDocFascRuoli.ID_GRUPPO = sessionObj.getSessionIdRuolo();
                        
                    if (((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Checked && ((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Checked)
                    {
                        assDocFascRuoli.INS_MOD_OGG_CUSTOM = "1";
                        assDocFascRuoli.VIS_OGG_CUSTOM = "1";                        
                    }

                    if (!((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Checked && !((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Checked)
                    {
                        assDocFascRuoli.INS_MOD_OGG_CUSTOM = "0";
                        assDocFascRuoli.VIS_OGG_CUSTOM = "0";                        
                    }

                    if (((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Checked && !((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Checked)
                    {
                        assDocFascRuoli.INS_MOD_OGG_CUSTOM = "0";
                        assDocFascRuoli.VIS_OGG_CUSTOM = "1";                        
                    }

                    if (Utils.isEnableRepertori(template.ID_AMMINISTRAZIONE) && ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Checked)
                        assDocFascRuoli.ANNULLA_REPERTORIO = "1";
                    else
                        assDocFascRuoli.ANNULLA_REPERTORIO = "0";

                    listaDirittiCampiSelezionati.Add(assDocFascRuoli);                    
                }
                
                //Salvo la selezione dei diritti sui campi scelta dall'utente
                ProfilazioneDocManager.salvaDirittiCampiTipologiaDoc(listaDirittiCampiSelezionati, this);                
            }
        }

        private void impostaSelezioneRuoliAssociati()
        {
            HTruoli = sessionObj.GetSessionHashTableRuoli();
            
            for (int i = 0; i < dg_Ruoli.Items.Count; i++)
            {
                if (HTruoli.Count != 0)
                {
                    if (HTruoli.ContainsKey(dg_Ruoli.Items[i].Cells[0].Text))
                    {
                        RuoliHT r;
                        r = (RuoliHT)HTruoli[dg_Ruoli.Items[i].Cells[0].Text];
                        if (r.Ins == "1" && r.Ric == "1")
                        {
                            ((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Checked = true;
                            ((CheckBox)dg_Ruoli.Items[i].Cells[4].Controls[1]).Checked = true;
                            ((CheckBox)dg_Ruoli.Items[i].Cells[4].Controls[1]).Enabled = false;

                            //((CheckBox)dg_Ruoli.Items[i].Cells[2].Controls[1]).Checked = true;
                            //((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Checked = true;
                            //((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Enabled = false;
                        }
                        //In questo caso invece imposta le checkbox rispetto ai diritti del ruolo
                        if (r.Ins == "0" && r.Ric == "0")
                        {
                            ((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Checked = false;
                            ((CheckBox)dg_Ruoli.Items[i].Cells[4].Controls[1]).Enabled = true;
                            ((CheckBox)dg_Ruoli.Items[i].Cells[4].Controls[1]).Checked = false;

                            //((CheckBox)dg_Ruoli.Items[i].Cells[2].Controls[1]).Checked = false;
                            //((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Enabled = true;
                            //((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Checked = false;
                        }
                        if (r.Ins == "0" && r.Ric == "1")
                        {
                            ((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Checked = false;
                            ((CheckBox)dg_Ruoli.Items[i].Cells[4].Controls[1]).Enabled = true;
                            ((CheckBox)dg_Ruoli.Items[i].Cells[4].Controls[1]).Checked = true;

                            //((CheckBox)dg_Ruoli.Items[i].Cells[2].Controls[1]).Checked = false;
                            //((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Enabled = true;
                            //((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Checked = true;
                        }
                    }
                }
            }
        }

        private void impostaSelezioneCampiAssociati()
        {
            for (int i = 0; i < listaCampi.Count; i++)
            {
                DocsPaWR.OggettoCustom oggettoCustom = (DocsPaWR.OggettoCustom)listaCampi[i];
                var query = from DocsPaWR.AssDocFascRuoli assDocFasc in listaDirittiCampiSelezionati where assDocFasc.ID_OGGETTO_CUSTOM == oggettoCustom.SYSTEM_ID.ToString() select assDocFasc;

                foreach (DocsPaWR.AssDocFascRuoli assDocFasc in query)
                {
                    if (assDocFasc.VIS_OGG_CUSTOM == "1" && assDocFasc.INS_MOD_OGG_CUSTOM == "1")
                    {
                        ((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Checked = true;
                        ((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Enabled = true;
                        ((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Checked = true;
                        ((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Enabled = false;

                        if (Utils.isEnableRepertori(template.ID_AMMINISTRAZIONE) && oggettoCustom.REPERTORIO.Equals("1"))
                        {
                            ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Visible = true;
                            ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Enabled = true;
                            if (!String.IsNullOrEmpty(assDocFasc.ANNULLA_REPERTORIO) && assDocFasc.ANNULLA_REPERTORIO.Equals("1"))
                                ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Checked = true;
                            else
                                ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Checked = false;
                        }
                        else
                        {
                            ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Visible = false;
                        }
                    }

                    if (assDocFasc.VIS_OGG_CUSTOM == "0" && assDocFasc.INS_MOD_OGG_CUSTOM == "0")
                    {
                        ((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Checked = false;
                        ((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Enabled = true;
                        ((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Checked = false;
                        ((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Enabled = true;

                        if (Utils.isEnableRepertori(template.ID_AMMINISTRAZIONE) && oggettoCustom.REPERTORIO.Equals("1"))
                        {
                            ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Visible = true;
                            ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Enabled = false;
                            ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Checked = false;
                        }
                        else
                        {
                            ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Visible = false;
                        }

                    }

                    if (assDocFasc.VIS_OGG_CUSTOM == "1" && assDocFasc.INS_MOD_OGG_CUSTOM == "0")
                    {
                        ((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Checked = false;
                        ((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Enabled = true;
                        ((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Checked = true;
                        ((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Enabled = true;

                        if (Utils.isEnableRepertori(template.ID_AMMINISTRAZIONE) && oggettoCustom.REPERTORIO.Equals("1"))
                        {
                            ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Visible = true;
                            ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Enabled = true;
                            if (!String.IsNullOrEmpty(assDocFasc.ANNULLA_REPERTORIO) && assDocFasc.ANNULLA_REPERTORIO.Equals("1"))
                                ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Checked = true;
                            else
                                ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Checked = false;
                        }
                        else
                        {
                            ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Visible = false;
                        }
                    }                   
                }
            }
        }

        protected void btn_conferma_Click(object sender, EventArgs e)
        {
            if (!checkCriterioRicerca())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SelezionareCriterioRicerca", "alert('Selezionare un criterio di ricerca.');", true);
                return;
            }

            ArrayList assDocRuoli = new ArrayList();
            HTruoli = sessionObj.GetSessionHashTableRuoli();

            if (HTruoli != null)
            {
                foreach (string codice in HTruoli.Keys)
                {
                    RuoliHT r;
                    r = (RuoliHT)HTruoli[codice];
                    DocsPaWR.AssDocFascRuoli obj = new SAAdminTool.DocsPaWR.AssDocFascRuoli();
                    obj.ID_TIPO_DOC_FASC = template.SYSTEM_ID.ToString();
                    obj.ID_GRUPPO = codice;

                    if (r.Ins == "1" && r.Ric == "1")
                    {
                        obj.DIRITTI_TIPOLOGIA = "2";
                    }
                    //In questo caso invece imposta le checkbox rispetto ai diritti del ruolo
                    if (r.Ins == "0" && r.Ric == "0")
                    {
                        obj.DIRITTI_TIPOLOGIA = "0";
                    }
                    if (r.Ins == "0" && r.Ric == "1")
                    {
                        obj.DIRITTI_TIPOLOGIA = "1";
                    }
                    assDocRuoli.Add(obj);
                }
                DocsPaWR.AssDocFascRuoli[] assDocRuoli_1 = new SAAdminTool.DocsPaWR.AssDocFascRuoli[assDocRuoli.Count];
                assDocRuoli.CopyTo(assDocRuoli_1);
                ProfilazioneDocManager.salvaAssociazioneDocRuoli(assDocRuoli_1, this);
                salvaSelezioneCampi();
            }

            //sessionObj.RemoveSessionListaRuoli();
            //sessionObj.RemoveSessionListaRuoliSel();
            //sessionObj.RemoveSessionHashTableRuoli();

            //resetPanelCampi();
            
            //Session.Remove("reloadHT");
            //ClientScript.RegisterStartupScript(this.GetType(), "chiusura", "<script>window.close();</script>");
        }

        protected void btn_find_Click(object sender, System.EventArgs e)
        {
            if (!checkCriterioRicerca())
            {
                ClientScript.RegisterStartupScript(this.GetType(), "SelezionareCriterioRicerca", "alert('Selezionare un criterio di ricerca.');", true);
                return;
            }
                

            if (this.ddl_ricTipo.SelectedItem.Value.Equals("T"))
            {
                //Session["reloadHT"] = true;
                this.Inizialize();
            }
            else
            {
                string[] amministrazione = ((string)Session["AMMDATASET"]).Split('@');
                string codiceAmministrazione = amministrazione[0];
                idAmministrazione = Utils.getIdAmmByCod(codiceAmministrazione, this);

                listaRuoli = new ArrayList(ProfilazioneDocManager.getRuoliByAmm(idAmministrazione, txt_ricerca.Text, ddl_ricTipo.SelectedItem.Value, this));
                sessionObj.SetSessionListaRuoli(listaRuoli);

                listaRuoliSelezionati = new ArrayList(ProfilazioneDocManager.getRuoliTipoDoc(template.ID_TIPO_ATTO, this));
                sessionObj.SetSessionListaRuoliSel(listaRuoliSelezionati);

                caricaHTRuoli();
                caricaDgVisibilitaRuoli();
                impostaSelezioneRuoliAssociati();
                impostaSelezioneRuoli();
            }

            resetPanelCampi();
            caricaHTRuoli();
        }
        
        protected void dg_Ruoli_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            int elSelezionato = e.Item.ItemIndex;
            
            listaRuoli = sessionObj.GetSessionListaRuoli();
            DocsPaWR.Ruolo ruolo = (DocsPaWR.Ruolo)listaRuoli[elSelezionato];
            
            switch (e.CommandName)
            {
                case "VisibilitaCampi":
                    dg_Campi.SelectedIndex = -1;
                    dg_Ruoli.SelectedIndex = elSelezionato;
                    lbl_ruolo.Text = "RUOLO : " + ruolo.descrizione;
                    
                    //Salvo la selezione dei diritti sui campi prima di cambiare la selezione del ruolo
                    salvaSelezioneCampi();

                    listaDirittiCampiSelezionati = ProfilazioneDocManager.getDirittiCampiTipologiaDoc(ruolo.idGruppo, template.SYSTEM_ID.ToString(), this);
                    sessionObj.setSessionIdRuolo(ruolo.idGruppo);

                    caricaDgVisibilitaCampi();
                    impostaSelezioneCampiAssociati();
                    if(listaCampi != null && listaCampi.Count > 0)
                        panel_listaCampi.Visible = true;
                    break;
            }
        }

        protected void cb_insListaCampi_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            DataGridItem item = (DataGridItem)cb.NamingContainer;
            int rigaSelezionata = item.ItemIndex;

            if (((CheckBox)dg_Campi.Items[rigaSelezionata].Cells[2].Controls[1]).Checked)
            {
                ((CheckBox)dg_Campi.Items[rigaSelezionata].Cells[3].Controls[1]).Checked = true;
                ((CheckBox)dg_Campi.Items[rigaSelezionata].Cells[3].Controls[1]).Enabled = false;
            }
            else
            {
                ((CheckBox)dg_Campi.Items[rigaSelezionata].Cells[3].Controls[1]).Enabled = true;
            }

            if (Utils.isEnableRepertori(template.ID_AMMINISTRAZIONE))
            {
                if (((CheckBox)dg_Campi.Items[rigaSelezionata].Cells[3].Controls[1]).Checked)
                {
                    ((CheckBox)dg_Campi.Items[rigaSelezionata].Cells[4].Controls[1]).Enabled = true;
                }
                else
                {
                    ((CheckBox)dg_Campi.Items[rigaSelezionata].Cells[4].Controls[1]).Checked = false;
                    ((CheckBox)dg_Campi.Items[rigaSelezionata].Cells[4].Controls[1]).Enabled = false;
                }
            }
        }

        protected void resetPanelCampi()
        {
            salvaSelezioneCampi();
            sessionObj.removeSessionIdRuolo();
            dg_Ruoli.SelectedIndex = -1;
            dg_Campi.SelectedIndex = -1;
            panel_listaCampi.Visible = false;
        }

        protected void btn_estendiARuoli_Click(object sender, EventArgs e)
        {
            if (dg_Campi.Items.Count > 0 && !string.IsNullOrEmpty(sessionObj.getSessionIdRuolo()))
            {
                ArrayList listaDirittiCampiSelezionati = new ArrayList();
                for (int i = 0; i < listaCampi.Count; i++)
                {
                    DocsPaWR.AssDocFascRuoli assDocFascRuoli = new SAAdminTool.DocsPaWR.AssDocFascRuoli();
                    assDocFascRuoli.ID_TIPO_DOC_FASC = template.SYSTEM_ID.ToString();
                    assDocFascRuoli.ID_OGGETTO_CUSTOM = ((DocsPaWR.OggettoCustom)listaCampi[i]).SYSTEM_ID.ToString();
                    //assDocFascRuoli.ID_GRUPPO = sessionObj.getSessionIdRuolo();

                    if (((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Checked && ((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Checked)
                    {
                        assDocFascRuoli.INS_MOD_OGG_CUSTOM = "1";
                        assDocFascRuoli.VIS_OGG_CUSTOM = "1";                       
                    }

                    if (!((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Checked && !((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Checked)
                    {
                        assDocFascRuoli.INS_MOD_OGG_CUSTOM = "0";
                        assDocFascRuoli.VIS_OGG_CUSTOM = "0";                       
                    }

                    if (((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Checked && !((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Checked)
                    {
                        assDocFascRuoli.INS_MOD_OGG_CUSTOM = "0";
                        assDocFascRuoli.VIS_OGG_CUSTOM = "1";                        
                    }

                    if (((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Checked)
                        assDocFascRuoli.ANNULLA_REPERTORIO = "1";
                    else
                        assDocFascRuoli.ANNULLA_REPERTORIO = "0";

                    listaDirittiCampiSelezionati.Add(assDocFascRuoli);
                }

                listaRuoli = sessionObj.GetSessionListaRuoli();
                if(listaRuoli!=null && listaRuoli.Count > 0 && listaDirittiCampiSelezionati != null && listaDirittiCampiSelezionati.Count > 0)
                    ProfilazioneDocManager.estendiDirittiCampiARuoliDoc(listaDirittiCampiSelezionati, listaRuoli);      
                
            }     
        }

        protected void ddl_ricTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.ddl_ricTipo.Items.FindByValue("SEL").Enabled = false;

            if (this.ddl_ricTipo.SelectedItem.Value.Equals("T"))
            {
                txt_ricerca.Text = string.Empty;
                txt_ricerca.BackColor = System.Drawing.Color.Gainsboro;
                txt_ricerca.ReadOnly = true;              
            }
            else
            {
                txt_ricerca.BackColor = System.Drawing.Color.White;
                txt_ricerca.ReadOnly = false;              
            }
        }

        protected void CheckAllCreazioneTipologia_CheckedChanged(object sender, EventArgs e)
        {
            if (dg_Ruoli != null && dg_Ruoli.Items.Count > 0)
            {
                System.Web.UI.Control Header = dg_Ruoli.Controls[0].Controls[0];
                ((CheckBox)Header.FindControl("CheckAllRicercaTipologia")).Checked = true;

                if (((System.Web.UI.WebControls.CheckBox)sender).Checked)
                {
                    for (int i = 0; i < dg_Ruoli.Items.Count; i++)
                    {
                        ((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Checked = true;
                        ((CheckBox)dg_Ruoli.Items[i].Cells[4].Controls[1]).Checked = true;
                        ((CheckBox)dg_Ruoli.Items[i].Cells[4].Controls[1]).Enabled = false;

                        //((CheckBox)dg_Ruoli.Items[i].Cells[2].Controls[1]).Checked = true;
                        //((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Checked = true;
                        //((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Enabled = false;
                    }
                }
                if (!((System.Web.UI.WebControls.CheckBox)sender).Checked)
                {
                    for (int i = 0; i < dg_Ruoli.Items.Count; i++)
                    {
                        ((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Checked = false;
                        ((CheckBox)dg_Ruoli.Items[i].Cells[4].Controls[1]).Enabled = true;

                        //((CheckBox)dg_Ruoli.Items[i].Cells[2].Controls[1]).Checked = false;
                        //((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Enabled = true;
                    }
                }
            }
        }

        protected void CheckAllRicercaTipologia_CheckedChanged(object sender, EventArgs e)
        {
            if (dg_Ruoli != null && dg_Ruoli.Items.Count > 0)
            {
                if (((System.Web.UI.WebControls.CheckBox)sender).Checked)
                {
                    for (int i = 0; i < dg_Ruoli.Items.Count; i++)
                    {
                        ((CheckBox)dg_Ruoli.Items[i].Cells[4].Controls[1]).Checked = true;

                        //((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Checked = true;
                    }
                }
                if (!((System.Web.UI.WebControls.CheckBox)sender).Checked)
                {
                    for (int i = 0; i < dg_Ruoli.Items.Count; i++)
                    {
                        if(!((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Checked)
                            ((CheckBox)dg_Ruoli.Items[i].Cells[4].Controls[1]).Checked = false;

                        //if(!((CheckBox)dg_Ruoli.Items[i].Cells[2].Controls[1]).Checked)
                        //    ((CheckBox)dg_Ruoli.Items[i].Cells[3].Controls[1]).Checked = false;
                    }
                }
            }
        }

        protected void CheckAllModificaCampi_CheckedChanged(object sender, EventArgs e)
        {
            if (dg_Campi != null && dg_Campi.Items.Count > 0)
            {
                System.Web.UI.Control Header = dg_Campi.Controls[0].Controls[0];
                ((CheckBox)Header.FindControl("CheckAllVisibilitaCampi")).Checked = true;

                if (((System.Web.UI.WebControls.CheckBox)sender).Checked)
                {
                    for (int i = 0; i < dg_Campi.Items.Count; i++)
                    {
                        ((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Checked = true;
                        ((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Checked = true;
                        ((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Enabled = false;
                        if (Utils.isEnableRepertori(template.ID_AMMINISTRAZIONE))
                            ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Enabled = true;
                    }
                }
                if (!((System.Web.UI.WebControls.CheckBox)sender).Checked)
                {
                    for (int i = 0; i < dg_Campi.Items.Count; i++)
                    {
                        ((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Checked = false;
                        ((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Enabled = true;
                        if (Utils.isEnableRepertori(template.ID_AMMINISTRAZIONE))
                            ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Enabled = true;
                    }
                }
            }
        }

        protected void CheckAllVisibilitaCampi_CheckedChanged(object sender, EventArgs e)
        {
            if (dg_Campi != null && dg_Campi.Items.Count > 0)
            {
                if (((System.Web.UI.WebControls.CheckBox)sender).Checked)
                {
                    for (int i = 0; i < dg_Campi.Items.Count; i++)
                    {
                        ((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Checked = true;
                        if(Utils.isEnableRepertori(template.ID_AMMINISTRAZIONE))
                            ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Enabled = true;
                    }   
                }
                if (!((System.Web.UI.WebControls.CheckBox)sender).Checked)
                {
                    for (int i = 0; i < dg_Campi.Items.Count; i++)
                    {
                        if (!((CheckBox)dg_Campi.Items[i].Cells[2].Controls[1]).Checked)
                        {
                            ((CheckBox)dg_Campi.Items[i].Cells[3].Controls[1]).Checked = false;
                            if (Utils.isEnableRepertori(template.ID_AMMINISTRAZIONE))
                            {
                                ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Checked = false;
                                ((CheckBox)dg_Campi.Items[i].Cells[4].Controls[1]).Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        protected void btn_estendiACampi_Click(object sender, EventArgs e)
        {
            resetPanelCampi();
            btn_conferma_Click(sender, e);
            if (checkCriterioRicerca())
            {
                ArrayList listaRuoliDaEstendereVis = new ArrayList();
                listaRuoliSelezionati = sessionObj.GetSessionListaRuoli();
                ArrayList listaRuoliTipologiaDoc = new ArrayList(ProfilazioneDocManager.getRuoliTipoDoc(template.ID_TIPO_ATTO, this));

                if (listaRuoliSelezionati != null && listaRuoliTipologiaDoc != null)
                {
                    foreach (DocsPaWR.Ruolo ruolo in listaRuoliSelezionati)
                    {
                        foreach (DocsPaWR.AssDocFascRuoli assDocsFascRuoli in listaRuoliTipologiaDoc)
                        {
                            if (ruolo.idGruppo == assDocsFascRuoli.ID_GRUPPO)
                                listaRuoliDaEstendereVis.Add(assDocsFascRuoli);
                        }
                    }

                    if (listaRuoliDaEstendereVis != null && listaRuoliDaEstendereVis.Count > 0 && listaCampi != null && listaCampi.Count > 0)
                    {
                        ProfilazioneDocManager.estendiDirittiRuoloACampiDoc(listaRuoliDaEstendereVis, listaCampi);
                    }
                }
            }
            
            //listaRuoliSelezionati = new ArrayList(ProfilazioneDocManager.getRuoliTipoDoc(template.ID_TIPO_ATTO, this));
            //sessionObj.SetSessionListaRuoliSel(listaRuoliSelezionati);
            //listaRuoliSelezionati = sessionObj.GetSessionListaRuoliSel();
            //if (listaRuoliSelezionati != null && listaRuoliSelezionati.Count > 0 && listaCampi != null && listaCampi.Count > 0)
            //{
            //    ProfilazioneDocManager.estendiDirittiRuoloACampiDoc(listaRuoliSelezionati, listaCampi);                
            //}                        
        }

        protected void dg_Campi_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            int elSelezionato = e.Item.ItemIndex;
            DocsPaWR.OggettoCustom oggettoCustom = (DocsPaWR.OggettoCustom)listaCampi[elSelezionato];

            switch (e.CommandName)
            {
                case "VisibilitaRuoliCampo":
                    dg_Campi.SelectedIndex = elSelezionato;

                    //Salvo la selezione dei diritti sui campi prima di cambiare la selezione del ruolo
                    salvaSelezioneCampi();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "VisRuoliFromOggettoCustom", "window.showModalDialog('DirittiRuoloOggettoCustomDoc.aspx?idTemplate=" + template.SYSTEM_ID.ToString() + "&idOggettoCustom="+oggettoCustom.SYSTEM_ID.ToString()+"','','dialogWidth:800px;dialogHeight:400px;status:no;resizable:no;scroll:no;center:yes;help:no;close:no;');", true);
                    break;
            }
        }

        protected bool checkCriterioRicerca()
        {
            bool result = true;
            if (this.ddl_ricTipo.SelectedValue.Equals("SEL"))
                result = false;

            return result;
        }        
    }
}
