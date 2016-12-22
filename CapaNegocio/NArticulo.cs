using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NArticulo
    {
        //agreo metodo insertar que hace referencia a insertar de la clase DArticulo
        public static string Insertar( string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo obj = new DArticulo();
            obj.Codigo = codigo;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            obj.Imagen = imagen;
            obj.IdCategoria = idcategoria;
            obj.IdPresentacion = idpresentacion;

            return obj.Insertar(obj);
        }
        //metodo editar que refiere a editar de la clase DArticulo
        public static string Editar(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo obj = new DArticulo();
            obj.IdArticulo = idarticulo;
            obj.Codigo = codigo;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            obj.Imagen = imagen;
            obj.IdCategoria = idcategoria;
            obj.IdPresentacion = idpresentacion;

            return obj.Editar(obj);
        }
        //metodo eliminar que refiere a Eliminar de la clase DArticulo
        public static string Eliminar(int idarticulo)
        {
            DArticulo obj = new DArticulo();
            obj.IdArticulo = idarticulo;
            return obj.Eliminar(obj);
        }
        //metodo Mostrar que refiere a Mostrar de la clase DArticulo
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();

        }
        //metodo Buscar que refiere a Mostrar de la clase DArticulo
        public static DataTable BuscarNombre(string textobuscar)
        {
            DArticulo obj = new DArticulo();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNombre(obj);

        }
    }

}
