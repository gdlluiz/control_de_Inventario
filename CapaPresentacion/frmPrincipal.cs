using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 0;
        //variables quienes recibiran datos del login
        public string IdTrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoria categoria = new FrmCategoria();
            categoria.MdiParent = this;
            categoria.Show();
        }

        private void presentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPresentacion presentacion = new frmPresentacion();
            presentacion.MdiParent = this;
            presentacion.Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulo articulo = frmArticulo.getInstancia();
            articulo.MdiParent = this;
            articulo.Show();
           
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor proveedor = new frmProveedor();
            proveedor.MdiParent = this;
            proveedor.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            GestionUsuario();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrabajador trabajador = new frmTrabajador();
            trabajador.MdiParent = this;
            trabajador.Show();
        }

        //Controlo los accesos
        private void GestionUsuario()
        {
            if(Acceso == "Administrador")
            {
                //le habilito todo los menus
                this.MnuAlmacen.Enabled = true;
                this.MnuCompras.Enabled = true;
                this.MnuVentas.Enabled = true;
                this.MnuMantenimiento.Enabled = true;
                this.MnuConsultas.Enabled = true;
                this.MnuHerramientas.Enabled = true;
                this.TsCompras.Enabled = true;
                this.TsVentas.Enabled = true;
            }
            else if (Acceso == "Vendedor")
            {
                // habilito  accesos a todo los menus
                this.MnuAlmacen.Enabled = false;
                this.MnuCompras.Enabled = false;
                this.MnuVentas.Enabled = true;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = true;
                this.MnuHerramientas.Enabled = true;
                this.TsCompras.Enabled = false;
                this.TsVentas.Enabled = true;
            }
            else if (Acceso == "Almacenista")
            {
                //limito acceso todo los menus
                this.MnuAlmacen.Enabled = true;
                this.MnuCompras.Enabled = true;
                this.MnuVentas.Enabled = false;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = true;
                this.MnuHerramientas.Enabled = true;
                this.TsCompras.Enabled = true;
                this.TsVentas.Enabled = false;
            }
            else
            {
                if (Acceso == "Administrador")
                {
                    //limito acceso todo los menus
                    this.MnuAlmacen.Enabled = false;
                    this.MnuCompras.Enabled = false;
                    this.MnuVentas.Enabled = false;
                    this.MnuMantenimiento.Enabled = false;
                    this.MnuConsultas.Enabled = false;
                    this.MnuHerramientas.Enabled = false;
                    this.TsCompras.Enabled = false;
                    this.TsVentas.Enabled = false;
                }
            }
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngreso frm = frmIngreso.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.idTrabajador = Convert.ToInt32(this.IdTrabajador);
        }
    }
}
