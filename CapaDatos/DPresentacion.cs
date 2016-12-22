using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//agrego librerias
using System.Data;
//para poder conectarme a la bd
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPresentacion
    {
        private int _IdPresentacion;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;

        public int IdPresentacion
        {
            get
            {
                return _IdPresentacion;
            }

            set
            {
                _IdPresentacion = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }

            set
            {
                _TextoBuscar = value;
            }
        }
        //declaro constructores

        public DPresentacion()
        {

        }
        public DPresentacion(int idpresentacion, string nombre, string descripcion, string textobuscar)
        {
            this.IdPresentacion = idpresentacion;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }

        // Metodos 


        //creo metodos para utilizar con esta clase

        //Metodo Insertar

        public string Insertar(DPresentacion Presentacion)
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
                // hago instancia a procedimiento spinsertar_presentacion  en la BD
                SqlCmd.CommandText = "spinsertar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idCategoria
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                //Nombre
                SqlParameter Parnombre = new SqlParameter();
                Parnombre.ParameterName = "@nombre";
                Parnombre.SqlDbType = SqlDbType.VarChar;
                Parnombre.Size = 50;
                Parnombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(Parnombre);

                //Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Presentacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //ejecuta comando
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingreso el Registro";

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

        //Metodo Editar
        public string Editar(DPresentacion Presentacion)

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
                SqlCmd.CommandText = "speditar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idPresentacion
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Presentacion.IdPresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                //Nombre
                SqlParameter Parnombre = new SqlParameter();
                Parnombre.ParameterName = "@nombre";
                Parnombre.SqlDbType = SqlDbType.NVarChar;
                Parnombre.Size = 50;
                Parnombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(Parnombre);

                //Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 255;
                ParDescripcion.Value = Presentacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //ejecuta comando
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el Registro";

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

        //Metodo Eliminar
        public string Eliminar(DPresentacion Presentacion)
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
                SqlCmd.CommandText = "speliminar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idCategoria
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Presentacion.IdPresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);


                //ejecuta comando
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el Registro";

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
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_presentacion";
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
        public DataTable BuscarNombre(DPresentacion Presentacion)
        {
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_presentacion_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Presentacion.TextoBuscar;
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
