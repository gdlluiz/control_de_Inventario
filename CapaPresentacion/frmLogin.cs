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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            // muestro la hora en el lblTime
            lblHora.Text = DateTime.Now.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // mando a llamar el metodo Loging de NTrabajador y le paso lo ingresado por el usuario
            DataTable Datos = CapaNegocio.NTrabajador.Login(this.txtUsuario.Text,
                this.txtPassword.Text);

            //Evaluo si el usuario existe
            if(Datos.Rows.Count == 0)
            {
                MessageBox.Show("Ingrese un Usuario Valido", "Sistema de Ventas",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // creo el objeto de la clase frmPrincipal y le mando los datos del usuario
                frmPrincipal principal = new frmPrincipal();
                principal.IdTrabajador = Datos.Rows[0][0].ToString();
                principal.Apellidos = Datos.Rows[0][1].ToString();
                principal.Nombre = Datos.Rows[0][2].ToString();
                principal.Acceso = Datos.Rows[0][3].ToString();
                //Muestro el formulario principal
                principal.Show();
                // oculto este formulario
                this.Hide();

            }
        }
    }
}
