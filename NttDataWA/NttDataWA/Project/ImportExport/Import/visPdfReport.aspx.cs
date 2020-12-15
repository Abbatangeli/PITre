﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NttDataWA.Project.ImportExport.Import
{
    public partial class visPdfReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string templateFilePath = "";
            string fromType = (Session["fromImport"]!=null?Session["fromImport"].ToString():"");

            if (fromType != "")
            {
                if (fromType.ToLower().Equals("activex"))
                {
                    templateFilePath = Server.MapPath("formatPdfImportActiveX.xml");
                }
                else
                {
                    templateFilePath = Server.MapPath("formatPdfImport.xml");
                }
            }
            else
            {
                templateFilePath = Server.MapPath("formatPdfExport.xml");
            }

            NttDataWA.DocsPaWR.FileDocumento fileRep = new NttDataWA.DocsPaWR.FileDocumento();
            if ((Session["dsData"] != null) && (Session["dsData"].ToString() != ""))
            {
                fileRep = global::ProspettiRiepilogativi.Frontend.PdfReport.do_MakePdfReport(global::ProspettiRiepilogativi.Frontend.ReportDisponibili.ReportLogMassiveImport,
                    templateFilePath,
                    (DataSet)Session["dsData"], null);

                if (fileRep.length > 0)
                {
                    Response.ContentType = fileRep.contentType;
                    Response.AddHeader("content-disposition", "inline; filename=" + fileRep.name);
                    Response.AddHeader("content-length", fileRep.content.Length.ToString());
                    Response.BinaryWrite(fileRep.content);
                    Response.Flush();
                   // Response.End();

                }

            }
        }
    }
}
