using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NProveedor
    {
        //agreo metodo insertar que hace referencia a insertar de 
        //DProveedor
        public static string Insertar(string razonProveedor, string sectorComercial, string tipoDocumento, string numDocumento,
            string direccion, string telefono, string email, string url)
        {
            DProveedor obj = new DProveedor();
            obj.RazonSocial = razonProveedor;
            obj.SectorComercial = sectorComercial;
            obj.TipoDocumento = tipoDocumento;
            obj.NumDocumento = numDocumento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Url = url;
            return obj.Insertar(obj);
        }
        //metodo editar que refiere a editar de DProveedor
        public static string Editar(int idProveedor, string razonProveedor, string sectorComercial, string tipoDocumento, 
            string numDocumento,string direccion, string telefono, string email, string url)
        {
            DProveedor obj = new DProveedor();
            obj.IdProveedor = idProveedor;
            obj.RazonSocial = razonProveedor;
            obj.SectorComercial = sectorComercial;
            obj.TipoDocumento = tipoDocumento;
            obj.NumDocumento = numDocumento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Url = url;
            return obj.Editar(obj);
        }


        //metodo eliminar que refiere a Eliminar de  DProveedor
        public static string Eliminar(int idProveedor)
        {
            DProveedor obj = new DProveedor();
            obj.IdProveedor = idProveedor;
            return obj.Eliminar(obj);
        }


        //metodo Mostrar que refiere a Mostrar de  DProveedor
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();

        }
        //metodo Buscar que refiere a Mostrar de  DProveedor
        public static DataTable BuscarRazonSocial(string textobuscar)
        {
            DProveedor obj = new DProveedor();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarRazonSocial(obj);

        }

        //metodo Buscar que refiere a Mostrar de  DProveedor
        public static DataTable BuscarNumDocumeto(string textobuscar)
        {
            DProveedor obj = new DProveedor();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNumDocumento(obj);

        }
    }
}
