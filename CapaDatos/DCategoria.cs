using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCategoria
    {
        //Declaro variables de tabla categoria
        private int _IdCategoria;
        private string _Nombre;
        private string _Descripcion;
        //declaro variable para hacer busqueda
        private string _TextoBuscar;

        //constructores

            //constructor vacio
        public DCategoria()
        {

        }
        //creo constructor con Paramentros

        // utilizo parametros en minuscula
        //para diferenciar de variables antes creadas
        public DCategoria(int idcategoria, string nombre, string descripcion, string textobuscar)
        {
            this.IdCategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }



        //refactorizo cada metodo 
        //para obtener getter and setter
        public int IdCategoria
        {
            get
            {
                return _IdCategoria;
            }

            set
            {
                _IdCategoria = value;
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
 
       
        //creo metodos para utilizar con esta clase

        //Metodo Insertar

        public string Insertar(DCategoria Categoria)
        {
            String  resp = "";
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
                SqlCmd.CommandText = "spinsertar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idCategoria
                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdcategoria);

                //Nombre
                SqlParameter Parnombre = new SqlParameter();
                Parnombre.ParameterName = "@nombre";
                Parnombre.SqlDbType = SqlDbType.VarChar;
                Parnombre.Size = 50;
                Parnombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(Parnombre);

                //Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Descripcion;
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
        public string Editar(DCategoria Categoria)

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
                SqlCmd.CommandText = "speditar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idCategoria
                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.IdCategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);

                //Nombre
                SqlParameter Parnombre = new SqlParameter();
                Parnombre.ParameterName = "@nombre";
                Parnombre.SqlDbType = SqlDbType.VarChar;
                Parnombre.Size = 50;
                Parnombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(Parnombre);

                //Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Descripcion;
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
        public string Eliminar(DCategoria Categoria)
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
                SqlCmd.CommandText = "speliminar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idCategoria
                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.IdCategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);

                
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
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
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
        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
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
