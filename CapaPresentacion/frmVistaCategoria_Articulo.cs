using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmVistaCategoria_Articulo : Form
    {
        public frmVistaCategoria_Articulo()
        {
            InitializeComponent();
        }
        //ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Mostrar

        private void Mostrar()
        {
            //hago referencia al metodo mostrar de NCategoria que este a su vez ahace referencia
            // al procedimiento almacenado spmostarCategoria en la BD
            this.dataListado.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas(); //obtengo el listado de data listado con sus metodos
            // hago el parse de int a string 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar Nombre
        private void BuscarNombre()
        {
            // le agrego el contenido en la textbox buscar
            this.dataListado.DataSource = NCategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas(); //obtengo el listado de data listado con sus metodos
            // hago el parse de int a string 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmVistaCategoria_Articulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmArticulo form = frmArticulo.getInstancia();
            string id, nom;
            id = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
            nom = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            form.setCategoria(id,nom);
            this.Hide();
        }
    }
}
