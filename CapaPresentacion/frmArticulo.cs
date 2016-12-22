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
    public partial class frmArticulo : Form
    {
        //Variables que me indican si voy a Ingresar un nuevo articulo o Editar
        private bool IsNuevo = false;
        private bool IsEditar = false;

        //creo variables que mandaran elementos a otro formulario
        private static frmArticulo _Instancia;

        //metodo que crea la instancia

            public static frmArticulo getInstancia()
        {
            if(_Instancia == null)
            {
                _Instancia = new frmArticulo();
            }
            return _Instancia;
        }



        //metodo que cargara la categoria 

        public void setCategoria(string idcategoria, string nombre)
        {
            this.txtIdCategoria.Text = idcategoria;
            this.txtCategoria.Text = nombre;
        }

        public frmArticulo()
        {
            InitializeComponent();

            //too tip: quien mostrara la ayuda al usuario
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Articulo");
            this.ttMensaje.SetToolTip(this.pxImagen, "Selecciona la Imagen del Articulo");
            this.ttMensaje.SetToolTip(this.txtCategoria, "Selecciona la Categoria del Articulo");
            this.ttMensaje.SetToolTip(this.cbIdPresentacion, "Selecciona la Presentacion del Articulo");

            //oculto los controles
            this.txtIdCategoria.Visible = false;
            // pongo solo lectura el txtCategoria para que el usuario no pueda modificarlo
            this.txtCategoria.ReadOnly = true;
            //llamo a metodo que llena el combobox
            this.llenarComboPresentacion();
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
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdCategoria.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            this.txtIdArticulo.Text = string.Empty;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }

        //habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.btnBuscarCategoria.Enabled = valor;
            this.cbIdPresentacion.Enabled = valor;
            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;
            this.txtIdArticulo.ReadOnly = !valor;
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
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[8].Visible = false;
        }

        //Mostrar

        private void Mostrar()
        {
            //hago referencia al metodo mostrar de NArticulo que este a su vez ahace referencia
            // al procedimiento almacenado spmostarCategoria en la BD
            this.dataListado.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas(); //obtengo el listado de data listado con sus metodos
            // hago el parse de int a string 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar Nombre
        private void BuscarNombre()
        {
            // le agrego el contenido en la textbox buscar
            this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas(); //obtengo el listado de data listado con sus metodos
            // hago el parse de int a string 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo que llenara el combobox de presentacion
        private void llenarComboPresentacion()
        {
            cbIdPresentacion.DataSource = NPresentacion.Mostrar();
            cbIdPresentacion.ValueMember = "idpresentacion";
            cbIdPresentacion.DisplayMember = "nombre";

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pxImagen_Click(object sender, EventArgs e)
        {

        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            // asigna lo que el usuario seleccione
            DialogResult resultado = dialog.ShowDialog();

            // si el usuario eslige una imagen lo ajusta al tamano de la ventana
            if(resultado == DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //indico que se agregara un nuevo articulo
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            //mando el enfoque a txtNombre
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //creo variable para verificar si se inserto o modifico
                string respuesta = "";
                if (this.txtNombre.Text == string.Empty || this.txtIdCategoria.Text==string.Empty || this.txtCodigo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos.");
                    //mostrar errorIcon
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtCodigo, "Ingrese un Valor");
                    errorIcono.SetError(txtCategoria, "Ingrese un Valor");
                }
                else
                {
                    //creo buffer para la imagen del picturebox
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imagen = ms.GetBuffer();
                    if (this.IsNuevo)
                    {
                        // nombre lo paso a mayusculas y con trim borro espacios en blanco.
                        respuesta = NArticulo.Insertar(this.txtCodigo.Text,this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim(),imagen,Convert.ToInt32(this.txtIdCategoria.Text), 
                            Convert.ToInt32(this.cbIdPresentacion.SelectedValue ));
                    }
                    else
                    {
                        //convieto los ingresado en id categoria en entero
                        respuesta = NArticulo.Editar(Convert.ToInt32(this.txtIdArticulo.Text),
                            this.txtCodigo.Text, this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(this.txtIdCategoria.Text),
                            Convert.ToInt32(this.cbIdPresentacion.SelectedValue));
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
            //verifico que el textBox idPresentacion no este vacio
            if (!this.txtIdArticulo.Text.Equals(""))
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
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
            this.txtIdArticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idarticulo"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
            //almaceno la imagen en un buffer
            byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtIdCategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
            this.txtCategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["categoria"].Value);
            this.cbIdPresentacion.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["idpresentacion"].Value);
            // muesto contenido en el tapControl1
            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            //Habilitara poder eliminar registros en el contenedor dataListado
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
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
                            respuesta = NArticulo.Eliminar(Convert.ToInt32(codigo));
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

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            frmVistaCategoria_Articulo form = new frmVistaCategoria_Articulo();
            form.ShowDialog();
        }

        private void frmArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
