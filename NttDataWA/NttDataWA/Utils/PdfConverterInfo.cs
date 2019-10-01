﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NttDataWA.DocsPaWR;

namespace NttDataWA
{
    /// <summary>
    /// Classe necessaria per il reperimento delle informazioni
    /// riguardanti la conversione pdf inline di documenti,
    /// implementata nel server di backend
    /// </summary>
    public sealed class PdfConverterInfo
    {
        private static DocsPaWebService _ws = new DocsPaWebService();

        /// <summary>
        /// Tipologie di file convertibili in pdf
        /// </summary>
        private static string[] _convertibleFileTypes = null;

        /// <summary>
        /// Verifica se è attiva o meno la conversione in pdf inline di documenti
        /// </summary>
        /// <returns></returns>
        public static bool ConvertPdfInlineActive()
        {
            try
            {
                return _ws.ConvertPdfInlineActive();
            }
            catch (System.Exception ex)
            {
                UIManager.AdministrationManager.DiagnosticError(ex);
                return false;
            }
        }

        /// <summary>
        /// Verifica se il file richiesto può essere convertito in formato pdf 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool CanConvertFileToPdf(string fileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    bool retValue = false;

                    string[] fileTypes = GetConvertiblePdfFileTypes();

                    if (fileTypes != null)
                    {
                        FileInfo fileInfo = new FileInfo(fileName);
                        string fileExt = fileInfo.Extension.Replace(".", "").ToLower();

                        foreach (string fileType in fileTypes)
                        {
                            retValue = (fileType.Equals("*") || fileType.ToLower().Equals(fileExt));

                            if (retValue)
                                break;
                        }
                    }

                    return _ws.CanConvertFileToPdf(fileName);
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                UIManager.AdministrationManager.DiagnosticError(ex);
                return false;
            }
        }

        /// <summary>
        /// Verifica se la conversione inline di documenti in pdf supporta ocr
        /// </summary>
        /// <returns></returns>
        public static bool ConvertPdfWidthOcrSupported()
        {
            try
            {
                return _ws.ConvertPdfWidthOcrSupported();
            }
            catch (System.Exception ex)
            {
                UIManager.AdministrationManager.DiagnosticError(ex);
                return false;
            }
        }

        /// <summary>
        /// Reperimento di tutte le tipolgie predefinite di file 
        /// per cui è possibile effettuare la conversione in pdf 
        /// </summary>
        /// <returns></returns>
        public static string[] GetConvertiblePdfFileTypes()
        {
            try
            {
                if (_convertibleFileTypes == null)
                    _convertibleFileTypes = _ws.GetConvertiblePdfFileTypes();

                return _convertibleFileTypes;
            }
            catch (System.Exception ex)
            {
                UIManager.AdministrationManager.DiagnosticError(ex);
                return null;
            }
        }

        /// <summary>
        /// Verifica se è richiesta, lato frontend, la visualizzazione
        /// del documento in formato pdf (convertito inline)
        /// </summary>
        public static bool ShowDocumentAsPdfFormat
        {            
            get
            {
                try
                {
                    bool showAsPdfFormat;
                    if (bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["SHOW_DOCUMENT_AS_PDF_FORMAT"], out showAsPdfFormat))
                        return showAsPdfFormat;
                    else
                        return false;
                }
                catch (System.Exception ex)
                {
                    UIManager.AdministrationManager.DiagnosticError(ex);
                    return false;
                }
            }
        }
    }
}
