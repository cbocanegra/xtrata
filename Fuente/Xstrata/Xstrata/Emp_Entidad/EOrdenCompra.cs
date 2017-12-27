using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emp_Entidad
{
    public class EOrdenCompra
    {
        private String _NMRODC;

        public String NMRODC
        {
            get { return _NMRODC; }
            set { _NMRODC = value; }
        }


        private String _CSRVNV;

        public String CSRVNV
        {
            get { return _CSRVNV; }
            set { _CSRVNV = value; }
        }

        private String _NOMVAR;

        public String NOMVAR
        {
            get { return _NOMVAR; }
            set { _NOMVAR = value; }
        }

        private String _VALMRC;

        public String VALMRC
        {
            get { return _VALMRC; }
            set { _VALMRC = value; }
        }

        private String _STPGCT;

        public String STPGCT
        {
            get { return _STPGCT; }
            set { _STPGCT = value; }
        }
    }
}
