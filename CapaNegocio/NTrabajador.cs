using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
     public class NTrabajador
    {
        //agreo metodo insertar que hace referencia a insertar de 
        //DTrabajador
        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fechaNacimiento, string numDocumento,
            string direccion, string telefono, string email, string usuario, string acceso, string password)
        {
            DTrabajador obj = new DTrabajador();
            obj.Nombre = nombre;
            obj.Apellidos = apellidos;
            obj.Sexo = sexo;
            obj.FechaNacimiento = fechaNacimiento;
            obj.NumDocumento = numDocumento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Usuario = usuario;
            obj.Acceso = acceso;
            obj.Password = password;

            return obj.Insertar(obj);
        }
        //metodo editar que refiere a editar de DTrabajador
        public static string Editar(int idTrabajador, string nombre, string apellidos, string sexo, DateTime fechaNacimiento, 
            string numDocumento, string direccion, string telefono, string email, string usuario, string acceso, string password)
        {
            DTrabajador obj = new DTrabajador();
            obj.IdTrabajador = idTrabajador;
            obj.Nombre = nombre;
            obj.Apellidos = apellidos;
            obj.Sexo = sexo;
            obj.FechaNacimiento = fechaNacimiento;
            obj.NumDocumento = numDocumento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Usuario = usuario;
            obj.Acceso = acceso;
            obj.Password = password;
            return obj.Editar(obj);
        }


        //metodo eliminar que refiere a Eliminar de  DTrabajador
        public static string Eliminar(int idTrabajador)
        {
            DTrabajador obj = new DTrabajador();
            obj.IdTrabajador = idTrabajador;
            return obj.Eliminar(obj);
        }


        //metodo Mostrar que refiere a Mostrar de  DProveedor
        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();

        }
        //metodo Buscar que refiere a Mostrar de  DProveedor
        public static DataTable BuscarApellidos(string textobuscar)
        {
            DTrabajador obj = new DTrabajador();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarApellidos(obj);

        }

        //metodo Buscar que refiere a Mostrar de  DProveedor
        public static DataTable BuscarNumDocumeto(string textobuscar)
        {
            DTrabajador obj = new DTrabajador();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNumDocumento(obj);

        }

        public static DataTable Login(string usuario, string password)
        {
            DTrabajador obj = new DTrabajador();
            obj.Usuario = usuario;
            obj.Password = password;
            return obj.Login(obj);

        }
    }
}
