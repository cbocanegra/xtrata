using System;
using System.Collections.Generic;
using System.Text;

namespace Empleado.Entidad
{
    public class Empleado
    {

        private Int64 m_IdProducto;

        public Int64 IdProducto
        {
            get { return m_IdProducto; }
            set { m_IdProducto = value; }
        }



        private Int64 m_IdCategoria;

        public Int64 IdCategoria
        {
            get { return m_IdCategoria; }
            set { m_IdCategoria = value; }
        }

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
        private String m_UnidadMedida;

        public String UnidadMedida
        {
            get { return m_UnidadMedida; }
            set { m_UnidadMedida = value; }
        }

        private Double m_PrecioProveedor;

        public Double PrecioProveedor
        {
            get { return m_PrecioProveedor; }
            set { m_PrecioProveedor = value; }
        }


        private Double m_StockActual;

        public Double StockActual
        {
            get { return m_StockActual; }
            set { m_StockActual = value; }
        }

        private Double m_StockMinimo;

        public Double StockMinimo
        {
            get { return m_StockMinimo; }
            set { m_StockMinimo = value; }
        }


        private String m_Descripcion;

        public String Descripcion
        {
            get { return m_Descripcion; }
            set { m_Descripcion = value; }
        }


    }

}
