using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Mis Importaciones
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmCategoria : Form
    {
        //Variables que me indican si voy a Ingresar un nuevo articulo o Editar
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmCategoria()
        {
            InitializeComponent();
            //inicializo componentes

            //too tip: quien mostrara la ayuda al usuario
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre de la Categoria");
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
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdCategoria.Text = string.Empty;
        }

        //habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtIdCategoria.ReadOnly = !valor;
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



        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            //se alinea el formulario que salga n la parte superior izquierda
            this.Top = 0;
            this.Left = 0;
            //Mostrar items al iniciar formulario
            //llamo metodo Mostrar()
            this.Mostrar();
            // que las cajas de texto sean solo lectura
            this.Habilitar(false);
            //muestro botones  que se habiliten o no segun sea el caso
            this.Botones();

        }

        //Boton Buscar busque nombre
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        //contenido de textBuscar actualice el listado
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }
        //boton que agrega nueva categoria
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

        //boton para Guardar la categoria
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //creo variable para verificar si se inserto o modifico
                string respuesta = "";
                if (this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos.");
                    //mostrar errorIcon
                    errorIcono.SetError(txtNombre,"Ingrese un Nombre de Categoria");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        // nombre lo paso a mayusculas y con trim borro espacios en blanco.
                        respuesta = NCategoria.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim());
                    }
                    else
                    {
                        //convieto los ingresado en id categoria en entero
                        respuesta = NCategoria.Editar(Convert.ToInt32(this.txtIdCategoria.Text),
                            this.txtNombre.Text.Trim().ToUpper(),
                           this.txtDescripcion.Text.Trim());
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

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        //al dar double click en elemento de  dataListado pasarlo a mantenimiento para poder editar
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdCategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);

            // muesto contenido en el tapControl1
            this.tabControl1.SelectedIndex = 1;
        }
        // boton para editar categoria
        private void btnEditar_Click(object sender, EventArgs e)
        {
            //verifico que el textBox idCategoria no este vacio
            if (!this.txtIdCategoria.Text.Equals(""))
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
        // boton cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }
        // checkBox eliminar 
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
        // evento sobre el dataListado
        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Habilito para  cada elemento la columna eliminar con tipo checkbox para seleccionar cada uno por separado
            if(e.ColumnIndex==dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
        //boton Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // pide confirmacion de eliminar a usuario
                DialogResult Opcion;
                Opcion = MessageBox.Show("Decea Eliminar los Registros", "Sistema deVentas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(Opcion == DialogResult.OK)
                {
                    string codigo;
                    string respuesta = "";
                    // bucle que recorre todos los registros y verifica si estan seleccionados para borrar o no
                    foreach(DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            //obtengo llave primaria del registro marcado
                            codigo = Convert.ToString(row.Cells[1].Value);
                            //llamo al metodo eliminar y le paso la llave primaria
                            respuesta = NCategoria.Eliminar(Convert.ToInt32(codigo));
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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
