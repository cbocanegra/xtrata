using System;
using System.Collections.Generic;
using System.Text;

namespace Empleado.Entidad
{
    public class Categoria
    {
        private Int64 m_IdCategoria;

        public Int64 IdCategoria
        {
            get { return m_IdCategoria; }
            set { m_IdCategoria = value; }
        }

        private String m_Categoria;

        public String Categoria1
        {
            get { return m_Categoria; }
            set { m_Categoria = value; }
        }

        private String m_Descripcion;

        public String Descripcion
        {
            get { return m_Descripcion; }
            set { m_Descripcion = value; }
        }


    }
}
