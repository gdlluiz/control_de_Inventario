using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
     public class NCategoria
    {
        //agreo metodo insertar que hace referencia a insertar de 
        //CapaDatos
        public static string Insertar(string nombre, string descripcion)
        {
            DCategoria obj = new DCategoria();
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.Insertar(obj);
        }
        //metodo editar que refiere a editar de CapaDatos
        public static string Editar(int idcategoria,string nombre, string descripcion)
        {
            DCategoria obj = new DCategoria();
            obj.IdCategoria = idcategoria;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.Editar(obj);
        }
        //metodo eliminar que refiere a Eliminar de CapaDatos
        public static string Eliminar(int idcategoria)
        {
            DCategoria obj = new DCategoria();
            obj.IdCategoria = idcategoria;
            return obj.Eliminar(obj);
        }
        //metodo Mostrar que refiere a Mostrar de CapaDatos
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
            
        }
        //metodo Buscar que refiere a Mostrar de CapaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DCategoria obj = new DCategoria();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNombre(obj);

        }
    }
}
