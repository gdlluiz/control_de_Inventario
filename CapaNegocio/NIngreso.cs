using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NIngreso
    {
        //agreo metodo insertar que hace referencia a insertar de 
        //CapaDatos
        public static string Insertar(int idtrabajador, int idproveedor, DateTime fecha,
           string tipoComprobante, string serie, string correlativo, decimal iva, string estado,
           DataTable dtDetalles)
        {
            DIngreso obj = new DIngreso();

            obj.IdTrabajador = idtrabajador;
            obj.IdProveedor = idproveedor;
            obj.Fecha = fecha;
            obj.TipoComprobante = tipoComprobante;
            obj.Serie = serie;
            obj.Correlativo = correlativo;
            obj.Iva = iva;
            obj.Estado = estado;
            List<DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
            foreach(DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                detalle.IdArticulo = Convert.ToInt32(row["idArticulo"].ToString());
                detalle.PrecioCompra = Convert.ToDecimal(row["precioCompra"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["precioVenta"].ToString());
                detalle.StockInicial = Convert.ToInt32(row["stockInicial"].ToString());
                detalle.StockActual = Convert.ToInt32(row["stockInicial"].ToString());
                detalle.FechaProduccion = Convert.ToDateTime(row["fechaProduccion"].ToString());
                detalle.FechaCaducidad = Convert.ToDateTime(row["fechaCaducidad"].ToString());
                detalles.Add(detalle);
            }

            return obj.Insertar(obj, detalles);
        }


        //metodo eliminar que refiere a Anular de CapaDatos
        public static string Anular(int idingreso)
        {
            DIngreso obj = new DIngreso();
            obj.IdIngreso = idingreso;
            return obj.Anular(obj);
        }
        //metodo Mostrar que refiere a Mostrar de CapaDatos
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();

        }
        //metodo Buscar que refiere a Mostrar de CapaDatos
        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DIngreso obj = new DIngreso();
            
            return obj.BuscarFechas(textobuscar, textobuscar2);

        }
        public static DataTable MostrarDetalle(string textobuscar)
        {
            DIngreso obj = new DIngreso();

            return obj.MostrarDetalle(textobuscar);

        }
    }
   
}
