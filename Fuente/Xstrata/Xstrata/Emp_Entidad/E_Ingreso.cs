using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emp_Entidad
{
    public class E_Ingreso
    {

        private string m_Usuario;

        public string Usuario
        {
            get { return m_Usuario; }
            set { m_Usuario = value; }
        }

        private string m_Contrasena;

        public string Contrasena
        {
            get { return m_Contrasena; }
            set { m_Contrasena = value; }
        } 
    }
}
