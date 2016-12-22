using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DProveedor
    {
        // variables 
        private int _IdProveedor;
        private string _RazonSocial;
        private string _SectorComercial;
        private string _TipoDocumento;
        private string _NumDocumento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Url;
        private string _TextoBuscar;

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

        public string RazonSocial
        {
            get
            {
                return _RazonSocial;
            }

            set
            {
                _RazonSocial = value;
            }
        }

        public string SectorComercial
        {
            get
            {
                return _SectorComercial;
            }

            set
            {
                _SectorComercial = value;
            }
        }

        public string TipoDocumento
        {
            get
            {
                return _TipoDocumento;
            }

            set
            {
                _TipoDocumento = value;
            }
        }

        public string NumDocumento
        {
            get
            {
                return _NumDocumento;
            }

            set
            {
                _NumDocumento = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _Direccion;
            }

            set
            {
                _Direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _Telefono;
            }

            set
            {
                _Telefono = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        public string Url
        {
            get
            {
                return _Url;
            }

            set
            {
                _Url = value;
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
        //Constructores

        public DProveedor()
        {

        }

        public DProveedor(int idProveedor, string razonSocial, string sectorComercial, string tipoDocumento, string numDocumento,
            string direccion, string telefono, string email, string url, string textobuscar)
        {
            this.IdProveedor = idProveedor;
            this.RazonSocial = razonSocial;
            this.SectorComercial = sectorComercial;
            this.TipoDocumento = tipoDocumento;
            this.NumDocumento = numDocumento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Url = url;
            this.TextoBuscar = textobuscar;
        }

        //creo metodos para utilizar con esta clase

        //Metodo Insertar

        public string Insertar(DProveedor Proveedor)
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
                SqlCmd.CommandText = "spinsertar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idProveedor
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdProveedor);

                //Razon Social
                SqlParameter ParRazonSocial = new SqlParameter();
                ParRazonSocial.ParameterName = "@razon_social";
                ParRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParRazonSocial.Size = 150;
                ParRazonSocial.Value = Proveedor.RazonSocial;
                SqlCmd.Parameters.Add(ParRazonSocial);

                //sector comercial
                SqlParameter ParSectorComercial = new SqlParameter();
                ParSectorComercial.ParameterName = "@sector_comercial";
                ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParSectorComercial.Size = 50;
                ParSectorComercial.Value = Proveedor.SectorComercial;
                SqlCmd.Parameters.Add(ParSectorComercial);

                //tipoDocumento
                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipodocumento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Proveedor.TipoDocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                //numDocumento
                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@numdocumento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 13;
                ParNumDocumento.Value = Proveedor.NumDocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                //Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                //url
                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 100;
                ParUrl.Value = Proveedor.Url;
                SqlCmd.Parameters.Add(ParUrl);

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
        public string Editar(DProveedor Proveedor)

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
                SqlCmd.CommandText = "speditar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idCategoria
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.IdProveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);
                //Razon Social
                SqlParameter ParRazonSocial = new SqlParameter();
                ParRazonSocial.ParameterName = "@razon_social";
                ParRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParRazonSocial.Size = 150;
                ParRazonSocial.Value = Proveedor.RazonSocial;
                SqlCmd.Parameters.Add(ParRazonSocial);

                //sector comercial
                SqlParameter ParSectorComercial = new SqlParameter();
                ParSectorComercial.ParameterName = "@sector_comercial";
                ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParSectorComercial.Size = 50;
                ParSectorComercial.Value = Proveedor.SectorComercial;
                SqlCmd.Parameters.Add(ParSectorComercial);

                //tipoDocumento
                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipodocumento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Proveedor.TipoDocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                //numDocumento
                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@numdocumento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 13;
                ParNumDocumento.Value = Proveedor.NumDocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                //Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                //url
                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 100;
                ParUrl.Value = Proveedor.Url;
                SqlCmd.Parameters.Add(ParUrl);

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
        public string Eliminar(DProveedor Proveedor)
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
                SqlCmd.CommandText = "speliminar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //ingresar parametros
                //idCategoria
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.IdProveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);


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
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_proveedor";
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
        public DataTable BuscarRazonSocial(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_razon_social";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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

        public DataTable BuscarNumDocumento(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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
