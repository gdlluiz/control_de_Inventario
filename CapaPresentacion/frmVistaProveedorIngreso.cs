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
    public partial class frmVistaProveedorIngreso : Form
    {

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
            this.dataListado.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas(); //obtengo el listado de data listado con sus metodos
            // hago el parse de int a string 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar por Razon Social
        private void BuscarRazonSocial()
        {
            // le agrego el contenido en la textbox buscar
            this.dataListado.DataSource = NProveedor.BuscarRazonSocial(this.txtBuscar.Text);
            this.OcultarColumnas(); //obtengo el listado de data listado con sus metodos
            // hago el parse de int a string 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar por Numero de Documento
        private void BuscarNumDocumento()
        {
            // le agrego el contenido en la textbox buscar
            this.dataListado.DataSource = NProveedor.BuscarNumDocumeto(this.txtBuscar.Text);
            this.OcultarColumnas(); //obtengo el listado de data listado con sus metodos
            // hago el parse de int a string 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        public frmVistaProveedorIngreso()
        {
            InitializeComponent();
        }

        private void frmVistaProveedorIngreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Equals("Razon Social"))
            {
                this.BuscarRazonSocial();
            }
            else if (cbBuscar.Equals("Documento"))
            {
                this.BuscarNumDocumento();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmIngreso form = frmIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idProveedor"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["razonSocial"].Value);
            form.setProveedor(par1, par2);
            this.Hide();
        }
    }
}
