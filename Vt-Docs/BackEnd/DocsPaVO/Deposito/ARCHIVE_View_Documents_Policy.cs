﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocsPaVO.Deposito
{
    public partial class ARCHIVE_View_Documents_Policy
    {
        #region Fields

        private String _Registro;
        private String _Titolario;
        private String _Classetitolario;
        private String _Tipologia;
        private Int32? _AnnoCreazione;
        private Int32? _Totale;
        private Int32 _CountDistinct;

        #endregion

        #region Properties

        public virtual String Registro
        {

            get
            {
                return _Registro;
            }

            set
            {
                _Registro = value;
            }
        }

        public virtual String Titolario
        {

            get
            {
                return _Titolario;
            }

            set
            {
                _Titolario = value;
            }
        }

        public virtual String Classetitolario
        {

            get
            {
                return _Classetitolario;
            }

            set
            {
                _Classetitolario = value;
            }
        }

        public virtual String Tipologia
        {

            get
            {
                return _Tipologia;
            }

            set
            {
                _Tipologia = value;
            }
        }

        public virtual Int32? AnnoCreazione
        {

            get
            {
                return _AnnoCreazione;
            }

            set
            {
                _AnnoCreazione = value;
            }
        }

        public virtual Int32? Totale
        {

            get
            {
                return _Totale;
            }

            set
            {
                _Totale = value;
            }
        }

        public virtual Int32 CountDistinct
        {

            get
            {
                return _CountDistinct;
            }

            set
            {
                _CountDistinct = value;
            }
        }

        #endregion

        #region Default Constructor

        public ARCHIVE_View_Documents_Policy()
        {
        }

        #endregion

        #region Constructors

        public ARCHIVE_View_Documents_Policy(String registro, String titolario, String classetitolario, String tipologia, Int32? annoCreazione, Int32? totale, Int32 countDistinct)
        {
            Registro = registro;
            Titolario = titolario;
            Classetitolario = classetitolario;
            Tipologia = tipologia;
            AnnoCreazione = annoCreazione;
            Totale = totale;
            CountDistinct = countDistinct;
        }

        #endregion

    }
}
