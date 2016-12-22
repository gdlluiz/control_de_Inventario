using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DIngreso
    {
        private int _IdIngreso;
        private int _IdTrabajador;
        private int _IdProveedor;
        private DateTime _Fecha;
        private string _TipoComprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Iva;
        private string _Estado;

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

        public int IdTrabajador
        {
            get
            {
                return _IdTrabajador;
            }

            set
            {
                _IdTrabajador = value;
            }
        }

        public int IdProveedor
        {
            get
            {
                return _IdProveedor;
            }

            set
            {
                _IdProveedor = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        public string TipoComprobante
        {
            get
            {
                return _TipoComprobante;
            }

            set
            {
                _TipoComprobante = value;
            }
        }

        public string Serie
        {
            get
            {
                return _Serie;
            }

            set
            {
                _Serie = value;
            }
        }

        public string Correlativo
        {
            get
            {
                return _Correlativo;
            }

            set
            {
                _Correlativo = value;
            }
        }

        public decimal Iva
        {
            get
            {
                return _Iva;
            }

            set
            {
                _Iva = value;
            }
        }

        public string Estado
        {
            get
            {
                return _Estado;
            }

            set
            {
                _Estado = value;
            }
        }

        // Constructores

        public DIngreso()
        {

        }

        public DIngreso(int idngreso, int idtrabajador, int idproveedor, DateTime fecha,
            string tipoComprobante, string serie, string correlativo, decimal iva, string estado)
        {
            this.IdIngreso = idngreso;
            this.IdTrabajador = idtrabajador;
            this.IdProveedor = idproveedor;
            this.Fecha = fecha;
            this.TipoComprobante = tipoComprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Iva = iva;
            this.Estado = estado;
        }

        //Metodos

        //Metodo Insertar

        public string Insertar(DIngreso Ingreso, List<DDetalle_Ingreso> Detalle)
        {
            String resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //establesco cadena de conexion
                SqlCon.ConnectionString = Conexion.Cn;
                //abro conexion para poder establecer comunicacion con la BD
                SqlCon.Open();
                //establezco transaccion
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                //Establesco comando que permite ejecutar sentencias en sqlServer
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idIngreso
                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idingreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdIngreso);

                //idtrabajador
                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Ingreso.IdTrabajador;
                SqlCmd.Parameters.Add(ParIdTrabajador);


                //idproveedor
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Ingreso.IdProveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);

                //fecha
                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Ingreso.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                //tipo comprobante
                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@tipocomprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 20;
                ParTipoComprobante.Value = Ingreso.TipoComprobante;
                SqlCmd.Parameters.Add(ParTipoComprobante);

                //serie
                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Ingreso.Serie;
                SqlCmd.Parameters.Add(ParSerie);

                //correlativo
                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParTipoComprobante.Value = Ingreso.Correlativo;
                SqlCmd.Parameters.Add(ParCorrelativo);

                //iva
                SqlParameter ParIva = new SqlParameter();
                ParIva.ParameterName = "@iva";
                ParIva.SqlDbType = SqlDbType.Decimal;
                ParIva.Precision = 4;
                ParIva.Scale = 2;
                ParIva.Value = Ingreso.Iva;
                SqlCmd.Parameters.Add(ParIva);


                //estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Precision = 4;
                ParEstado.Value = Ingreso.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //ejecuta comando
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";
                if (resp.Equals("OK"))
                {
                    //obtener el codigo de ingreso generado
                    this.IdIngreso = Convert.ToInt32(SqlCmd.Parameters["@idingreso"].Value);
                    foreach (DDetalle_Ingreso det in Detalle)
                    {
                        det.IdIngreso = this.IdIngreso;
                        //llamo al metodo insertar
                        resp = det.Insertar(det, ref SqlCon, ref SqlTra);
                        if (!resp.Equals("OK"))
                        {
                            break;
                        }
                    }
                }
                if (resp.Equals("OK"))
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            //cierro conexion
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return resp;
        }

        //Anular
        public string Anular(DIngreso Ingreso)
        {
            String resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //establesco cadena de conexion
                SqlCon.ConnectionString = Conexion.Cn;
                //abro conexion para poder establecer comunicacion con la BD
                SqlCon.Open();
                //Establesco comando que permite ejecutar sentencias en sqlServer
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spanular_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idCategoria
                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idingreso ";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Value = Ingreso.IdIngreso;
                SqlCmd.Parameters.Add(ParIdIngreso);


                //ejecuta comando
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Anulo el Registro";

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            //cierro conexion
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                {
                    SqlCon.Close();
                }
            }
            return resp;
        }



        //Metodo Mostrar
        //este metodo sera  DataTable porqe mostrara un listado de tablas
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Metodo BuscarNombre
        public DataTable BuscarFechas(string TextoBuscar, string TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_ingreso_fecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textobuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 20;
                ParTextoBuscar2.Value = TextoBuscar2;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }


        //Metodo BuscarNombre
        public DataTable MostrarDetalle(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalle_ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

    }
}
