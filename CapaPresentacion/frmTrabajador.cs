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
    public partial class frmTrabajador : Form
    {
        private bool IsNuevo =false;
        private bool IsEditar =false;

        public frmTrabajador()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(txtNombre, "Ingresa Nombre del trabajador");
            this.ttMensaje.SetToolTip(txtApellidos, "Ingresa Apellidos del trabajador");
            this.ttMensaje.SetToolTip(txtUsuario, "Ingresa Usuario para el trabajador");
            this.ttMensaje.SetToolTip(txtPassword, "Ingresa password para del trabajador");
            this.ttMensaje.SetToolTip(cbAcceso, "seleccione el nivel de acceso del trabajador");
        }
        //Declaro metodos a utilizar

        //Mostrar Mensaje de Confirmacion
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario

        private void Limpiar()
        {
            this.txtPassword.Text = string.Empty;
            this.txtIdTrabajador.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtNumDocumento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
        }

        //habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.txtIdTrabajador.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbSexo.Enabled = valor;
            this.cbAcceso.Enabled = valor;
            this.txtNumDocumento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtPassword.ReadOnly = !valor;
        }

        //habilitar botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
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
            this.dataListado.DataSource = NTrabajador.Mostrar();
            this.OcultarColumnas(); //obtengo el listado de data listado con sus metodos
            // hago el parse de int a string 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar por Razon Social
        private void BuscarApellidos()
        {
            // le agrego el contenido en la textbox buscar
            this.dataListado.DataSource = NTrabajador.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas(); //obtengo el listado de data listado con sus metodos
            // hago el parse de int a string 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar por Numero de Documento
        private void BuscarNumDocumento()
        {
            // le agrego el contenido en la textbox buscar
            this.dataListado.DataSource = NTrabajador.BuscarNumDocumeto(this.txtBuscar.Text);
            this.OcultarColumnas(); //obtengo el listado de data listado con sus metodos
            // hago el parse de int a string 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void frmTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNumDocumento();
            }
            else if (cbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // pide confirmacion de eliminar a usuario
                DialogResult Opcion;
                Opcion = MessageBox.Show("Decea Eliminar los Registros", "Sistema deVentas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string codigo;
                    string respuesta = "";
                    // bucle que recorre todos los registros y verifica si estan seleccionados para borrar o no
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            //obtengo llave primaria del registro marcado
                            codigo = Convert.ToString(row.Cells[1].Value);
                            //llamo al metodo eliminar y le paso la llave primaria
                            respuesta = NTrabajador.Eliminar(Convert.ToInt32(codigo));
                            //confirmo eliminacion del registro
                            if (respuesta.Equals("OK"))
                            {
                                this.MensajeOK("Registro Eliminado");
                            }
                            else
                            {
                                MensajeError(respuesta);
                            }
                        }
                    }
                    //muestro listado actualizado
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Habilito para  cada elemento la columna eliminar con tipo checkbox para seleccionar cada uno por separado
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            // obtengo el valor de la tabla  Proveedor de la Base de Datos
            this.txtIdTrabajador.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idTrabajador"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value);
            this.cbSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);
            this.dtFechaNacimiento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["fechaNacimiento"].Value);
            this.txtNumDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["numeroDocumento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuario"].Value);
            this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["acceso"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["password"].Value);

            // muesto contenido en el tapControl1
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.txtIdTrabajador.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //creo variable para verificar si se inserto o modifico
                string respuesta = "";
                if (this.txtNombre.Text == string.Empty || this.txtApellidos.Text == string.Empty
                    || this.txtNumDocumento.Text == string.Empty ||this.txtDireccion.Text ==string.Empty
                    || this.txtUsuario.Text == string.Empty || this.txtPassword.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos.");
                    //mostrar errorIcon
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtApellidos, "Ingrese un Valor");
                    errorIcono.SetError(txtPassword, "Ingrese un Valor");
                    errorIcono.SetError(txtUsuario, "Ingrese un Valor");
                    errorIcono.SetError(txtNumDocumento, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        // nombre lo paso a mayusculas y con trim borro espacios en blanco.
                        respuesta = NTrabajador.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellidos.Text.Trim().ToUpper(),this.cbSexo.Text,
                            this.dtFechaNacimiento.Value,  this.txtNumDocumento.Text,
                            this.txtDireccion.Text, this.txtTelefono.Text, this.txtEmail.Text, 
                            this.txtUsuario.Text,this.cbAcceso.Text,this.txtPassword.Text);
                    }
                    else
                    {
                        //convieto los ingresado en id categoria en entero
                        respuesta = NTrabajador.Editar(Convert.ToInt32(this.txtIdTrabajador.Text),
                           this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellidos.Text.Trim().ToUpper(), this.cbSexo.Text,
                            this.dtFechaNacimiento.Value, this.txtNumDocumento.Text,
                            this.txtDireccion.Text, this.txtTelefono.Text, this.txtEmail.Text,
                            this.txtUsuario.Text, this.cbAcceso.Text, this.txtPassword.Text);
                    }
                    if (respuesta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se Inserto de forma correcta el Registro ");
                        }
                        else
                        {
                            this.MensajeOK("Se Actualizo de forma correcta el Registro ");
                        }
                    }
                    else
                    {
                        this.MensajeError(respuesta);
                    }
                    // despues de guarar  la entrada, limpio ,deshabilito edicion y muestro contenido
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //verifico que el textBox idCategoria no este vacio
            if (!this.txtIdTrabajador.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Selecciona el registro a Editar");
            }
        }
    }
}
