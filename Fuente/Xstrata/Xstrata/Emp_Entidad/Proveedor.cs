using System;
using System.Collections.Generic;
using System.Text;

namespace Empleado.Entidad
{
    public class Proveedor
    {

        private Int64 m_IdProveedor;

        public Int64 IdProveedor
        {
            get { return m_IdProveedor; }
            set { m_IdProveedor = value; }
        }



        private String m_Nombre;

        public String Nombre
        {
            get { return m_Nombre; }
            set { m_Nombre = value; }
        }


        private String m_Representante;

        public String Representante
        {
            get { return m_Representante; }
            set { m_Representante = value; }
        }


        private String m_Direccion;

        public String Direccion
        {
            get { return m_Direccion; }
            set { m_Direccion = value; }
        }

        private String m_Ciudad;

        public String Ciudad
        {
            get { return m_Ciudad; }
            set { m_Ciudad = value; }
        }


        private String m_Departamento;

        public String Departamento
        {
            get { return m_Departamento; }
            set { m_Departamento = value; }
        }

    }
}
