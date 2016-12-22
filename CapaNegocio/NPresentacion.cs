using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//hago comunicacion con capaDatos para poder compartir datos
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPresentacion
    {
        //agreo metodo insertar que hace referencia a insertar de la clase DPresentacion
        public static string Insertar(string nombre, string descripcion)
        {
            DPresentacion obj = new DPresentacion();
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.Insertar(obj);
        }
        //metodo editar que refiere a editar de la clase DPresentacion
        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            DPresentacion obj = new DPresentacion();
            obj.IdPresentacion = idpresentacion;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.Editar(obj);
        }
        //metodo eliminar que refiere a Eliminar de la clase DPresentacion
        public static string Eliminar(int idpresentacion)
        {
            DPresentacion obj = new DPresentacion();
            obj.IdPresentacion = idpresentacion;
            return obj.Eliminar(obj);
        }
        //metodo Mostrar que refiere a Mostrar de la clase DPresentacion
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();

        }
        //metodo Buscar que refiere a Mostrar de la clase DPresentacion
        public static DataTable BuscarNombre(string textobuscar)
        {
            DPresentacion obj = new DPresentacion();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNombre(obj);

        }
    }
}
