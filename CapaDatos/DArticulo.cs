using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class DArticulo
    {
        //variables necesarias para la bd
        private int _IdArticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _IdCategoria;
        private int _IdPresentacion;
        private string _TextoBuscar;

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

        public string Codigo
        {
            get
            {
                return _Codigo;
            }

            set
            {
                _Codigo = value;
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

        public byte[] Imagen
        {
            get
            {
                return _Imagen;
            }

            set
            {
                _Imagen = value;
            }
        }

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
        public DArticulo()
        {

        }
        public DArticulo(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion, string textobuscar)
        {
            this.IdArticulo = idarticulo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.IdCategoria = idcategoria;
            this.IdPresentacion = idpresentacion;
            this.TextoBuscar = textobuscar;
        }

        //creo metodos para utilizar con esta clase

        //Metodo Insertar

        public string Insertar(DArticulo Articulo)
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
                SqlCmd.CommandText = "spinsertar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idCategoria
                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdArticulo);

                //Codigo
                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulo.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                //Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Imagen
                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                //idCategoria
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Articulo.IdCategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                //idPresentacion
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Articulo.IdPresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

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
        public string Editar(DArticulo Articulo)

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
                SqlCmd.CommandText = "speditar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idPresentacion
                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Value = Articulo.IdArticulo;
                SqlCmd.Parameters.Add(ParIdArticulo);


                //Codigo
                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulo.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                //Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Imagen
                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                //idCategoria
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Articulo.IdCategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                //idPresentacion
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Articulo.IdPresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);


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
        public string Eliminar(DArticulo Articulo)
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
                SqlCmd.CommandText = "speliminar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idCategoria
                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Value = Articulo.IdArticulo;
                SqlCmd.Parameters.Add(ParIdArticulo);


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
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_articulo";
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
        public DataTable BuscarNombre(DArticulo Articulo)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_articulo_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Articulo.TextoBuscar;
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
