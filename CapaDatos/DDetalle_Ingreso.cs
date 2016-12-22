using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Ingreso
    {
        private int _IdDetalleIngreso;
        private int _IdIngreso;
        private int _IdArticulo;
        private decimal _PrecioCompra;
        private decimal _PrecioVenta;
        private int _StockInicial;
        private int _StockActual;
        private DateTime _FechaProduccion;
        private DateTime _FechaCaducidad;

        public DateTime FechaCaducidad
        {
            get
            {
                return _FechaCaducidad;
            }

            set
            {
                _FechaCaducidad = value;
            }
        }

        public DateTime FechaProduccion
        {
            get
            {
                return _FechaProduccion;
            }

            set
            {
                _FechaProduccion = value;
            }
        }

        public int StockActual
        {
            get
            {
                return _StockActual;
            }

            set
            {
                _StockActual = value;
            }
        }

        public int StockInicial
        {
            get
            {
                return _StockInicial;
            }

            set
            {
                _StockInicial = value;
            }
        }

        public decimal PrecioVenta
        {
            get
            {
                return _PrecioVenta;
            }

            set
            {
                _PrecioVenta = value;
            }
        }

        public decimal PrecioCompra
        {
            get
            {
                return _PrecioCompra;
            }

            set
            {
                _PrecioCompra = value;
            }
        }

        public int IdArticulo
        {
            get
            {
                return _IdArticulo;
            }

            set
            {
                _IdArticulo = value;
            }
        }

        public int IdIngreso
        {
            get
            {
                return _IdIngreso;
            }

            set
            {
                _IdIngreso = value;
            }
        }

        public int IdDetalleIngreso
        {
            get
            {
                return _IdDetalleIngreso;
            }

            set
            {
                _IdDetalleIngreso = value;
            }

        }

        //Constructores

        public DDetalle_Ingreso()
        {

        }
        public DDetalle_Ingreso(int iddetalle_ingreso, int idingreso, int idarticulo, decimal precioCompra, 
            decimal precioVenta, int stockinicial, int stockactual, DateTime fechaProduccion, DateTime fechaCaducidad)
        {
            this.IdDetalleIngreso = iddetalle_ingreso;
            this.IdIngreso = idingreso;
            this.IdArticulo = idarticulo;
            this.PrecioCompra = precioCompra;
            this.PrecioVenta = precioVenta;
            this.StockInicial = StockInicial;
            this.StockActual = stockactual;
            this.FechaProduccion = fechaProduccion;
            this.FechaCaducidad = fechaCaducidad;
        }

        //metodo insertar
        // recibo por referencia la coneccion  y la transaccion
        public string Insertar(DDetalle_Ingreso DetalleIngreso, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            String resp = "";
            try
            {
              
                //Establesco comando que permite ejecutar sentencias en sqlServer
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idDetalleIngreso
                SqlParameter ParIdDetalleIngreso = new SqlParameter();
                ParIdDetalleIngreso.ParameterName = "@iddetalleingreso";
                ParIdDetalleIngreso.SqlDbType = SqlDbType.Int;
                ParIdDetalleIngreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdDetalleIngreso);

                //idIngreso
                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idingreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Value = DetalleIngreso.IdIngreso;
                SqlCmd.Parameters.Add(ParIdIngreso);

                //idArticulo
                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Value = DetalleIngreso.IdArticulo;
                SqlCmd.Parameters.Add(ParIdArticulo);


                //preciocompra
                SqlParameter ParPrecioCompra = new SqlParameter();
                ParPrecioCompra.ParameterName = "@preciocompra";
                ParPrecioCompra.SqlDbType = SqlDbType.Money;
                ParPrecioCompra.Value = DetalleIngreso.PrecioCompra;
                SqlCmd.Parameters.Add(ParPrecioCompra);

                //precio venta
                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precioventa";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = DetalleIngreso.PrecioVenta;
                SqlCmd.Parameters.Add(ParPrecioVenta);

                //stock inicial
                SqlParameter ParStockInicial = new SqlParameter();
                ParStockInicial.ParameterName = "@stockinicial";
                ParStockInicial.SqlDbType = SqlDbType.Int;
                ParStockInicial.Value = DetalleIngreso.StockInicial;
                SqlCmd.Parameters.Add(ParStockInicial);

                //stock Actual
                SqlParameter ParStockActual = new SqlParameter();
                ParStockActual.ParameterName = "@stockactual";
                ParStockActual.SqlDbType = SqlDbType.Int;
                ParStockActual.Value = DetalleIngreso.StockActual;
                SqlCmd.Parameters.Add(ParStockActual);


                //fecha produccion
                SqlParameter ParFechaProduccion = new SqlParameter();
                ParFechaProduccion.ParameterName = "@fechaproduccion";
                ParFechaProduccion.SqlDbType = SqlDbType.Date;
                ParFechaProduccion.Value = DetalleIngreso.FechaProduccion;
                SqlCmd.Parameters.Add(ParFechaProduccion);

                //fecha caducidad
                SqlParameter ParFechaCaducidad = new SqlParameter();
                ParFechaCaducidad.ParameterName = "@fechacaducidad";
                ParFechaCaducidad.SqlDbType = SqlDbType.Date;
                ParFechaCaducidad.Value = DetalleIngreso.FechaCaducidad;
                SqlCmd.Parameters.Add(ParFechaCaducidad);

                //ejecuta comando
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
          
            return resp;
        }
    }
}
