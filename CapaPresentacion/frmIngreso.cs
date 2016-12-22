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
    public partial class frmIngreso : Form
    {
        public int idTrabajador;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;
        private static frmIngreso _instacia;


        // Metodo que crea instancia del formulario 
        public static frmIngreso GetInstancia()
        {
            if (_instacia == null)
            {
                _instacia = new frmIngreso();
            }
            return _instacia;
        }

        public void setProveedor(string idProveedor, string nombre)
        {
            this.txtIdProveedor.Text = idProveedor;
            this.txtProveedor.Text = nombre;
        }

        public void setArticulo(string idArticulo, string nombre)
        {
            this.txtIdArticulo.Text = idArticulo;
            this.txtArticulo.Text = nombre;
        }




          public frmIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProveedor, "Seleccione el Proveedor");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese la serie del Comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese el numeor de comprobante");
            this.ttMensaje.SetToolTip(this.txtStock, "Ingrese la cantidad de compra");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Ingrese el numeor de comprobanteArticulo de Compra");
            this.txtIdProveedor.Visible = false;
            this.txtIdArticulo.Visible = false;
            this.txtIdProveedor.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
        }


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
            this.txtIdIngreso.Text = string.Empty;
            this.txtIdProveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIVA.Text = string.Empty;
            this.lblTotalInversion.Text = "0.0";
            this.txtIVA.Text = "16";
            this.crearTabla();
        }

        private void limpiarDetalle()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
        }
        //habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtIdIngreso.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIVA.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbTipoComprobante.Enabled = valor;
            this.txtStock.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.dtFechaProduccion.Enabled = valor;
            this.dtFechaCaducidad.Enabled = valor;
            //botones

            this.btnBuscarArticulo.Enabled = valor;
            this.btnBuscarProveedor.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
            
        }

        //habilitar botones
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
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
            //hago referencia al metodo mostrar de NArticulo que este a su vez ahace referencia
            // al procedimiento almacenado spmostarCategoria en la BD
            this.dataListado.DataSource = NIngreso.Mostrar();
            this.OcultarColumnas(); //obtengo el listado de data listado con sus metodos
            // hago el parse de int a string 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar Nombre
        private void BuscarFechas()
        {
            // le agrego el contenido en la textbox buscar
            this.dataListado.DataSource = NIngreso.BuscarFechas(this.dtFecha1.Value.ToString("MM/dd/yyyy"),
                this.dtFecha2.Value.ToString("MM/dd/yyyy"));
            this.OcultarColumnas(); //obtengo el listado de data listado con sus metodos
            // hago el parse de int a string 
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void MostrarDetalle()
        {
            // le agrego el contenido en la textbox buscar
            this.dataListadoDetalle.DataSource = NIngreso.MostrarDetalle(this.txtIdIngreso.Text);
           
        }

        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("idArticulo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("precioCompra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("precioVenta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("stockInicial", System.Type.GetType("System.Int32"));
          
            this.dtDetalle.Columns.Add("fechaProduccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("fechaCaducidad", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("Subtotal", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("IVA", System.Type.GetType("System.Decimal"));

            //Relaciono DataGridView con DataTable

            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtCorrelativo_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();

        }

        private void frmIngreso_DoubleClick(object sender, EventArgs e)
        {

        }

        private void frmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instacia = null;
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            frmVistaProveedorIngreso vista = new frmVistaProveedorIngreso();
            vista.ShowDialog();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            frmVistaArticuloIngreso vista = new frmVistaArticuloIngreso();
            vista.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                // pide confirmacion de eliminar a usuario
                DialogResult Opcion;
                Opcion = MessageBox.Show("Decea Anular los Registros", "Sistema deVentas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                            respuesta = NIngreso.Anular(Convert.ToInt32(codigo));
                            //confirmo eliminacion del registro
                            if (respuesta.Equals("OK"))
                            {
                                this.MensajeOK("Registro Anulado Correctamente");
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
            if (chkAnular.Checked)
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //indico que se agregara un nuevo articulo
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            //mando el enfoque a txtNombre
            this.txtSerie.Focus();
            this.limpiarDetalle();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.limpiarDetalle();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //creo variable para verificar si se inserto o modifico
                string respuesta = "";
                if (this.txtIdProveedor.Text == string.Empty || this.txtSerie.Text == string.Empty
                    || this.txtCorrelativo.Text == string.Empty || this.txtIVA.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos.");
                    //mostrar errorIcon
                    errorIcono.SetError(txtIdProveedor, "Ingrese un Valor");
                    errorIcono.SetError(txtSerie, "Ingrese un Valor");
                    errorIcono.SetError(txtCorrelativo, "Ingrese un Valor");
                    errorIcono.SetError(txtIVA, "Ingrese un Valor");
                }
                else
                {
                   
                    if (this.IsNuevo)
                    {
                        // nombre lo paso a mayusculas y con trim borro espacios en blanco.
                        respuesta = NIngreso.Insertar(idTrabajador,Convert.ToInt32(this.txtIdProveedor.Text),
                            dtFecha.Value, cbTipoComprobante.Text,
                            txtSerie.Text,txtCorrelativo.Text, 
                            Convert.ToDecimal(txtIVA.Text),"Emitido",dtDetalle);
                    }

                    if (respuesta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se Inserto de forma correcta el Registro ");
                        }
                      
                    }
                    else
                    {
                        this.MensajeError(respuesta);
                    }
                    // despues de guarar  la entrada, limpio ,deshabilito edicion y muestro contenido
                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (this.txtIdArticulo.Text == string.Empty || this.txtStock.Text == string.Empty
                    || this.txtPrecioCompra.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos.");
                    //mostrar errorIcon
                    errorIcono.SetError(txtIdArticulo, "Ingrese un Valor");
                    errorIcono.SetError(txtStock, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecioCompra, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un Valor");
                }
                else
                {

                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idArticulo"]) == Convert.ToInt32(this.txtIdArticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya existe un articulo con ese nombre en detalle");
                        }
                    }
                    if (registrar)
                    {
                        decimal subtotal = (Convert.ToInt32(this.txtStock.Text)) * (Convert.ToInt32(this.txtPrecioCompra.Text));
                        totalPagado = totalPagado + subtotal;
                        this.lblTotalInversion.Text = totalPagado.ToString("#0.00#");
                        //agregar detalle al datalistadoDetalle

                        DataRow row = this.dtDetalle.NewRow();
                        row["idArticulo"] = Convert.ToInt32(this.txtIdArticulo.Text);
                        row["articulo"] =this.txtArticulo.Text;
                        row["precioCompra"] = Convert.ToDecimal(this.txtPrecioCompra.Text);
                        row["precioVenta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["stockInicial"] = Convert.ToInt32(this.txtStock.Text);
                        row["fechaProduccion"] = dtFechaProduccion.Value;
                        row["fechaCaducidad"] = dtFechaCaducidad.Value;
                        row["Subtotal"] = subtotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //Disminuir el total invertido
                this.totalPagado = this.totalPagado - Convert.ToInt32(row["Subtotal"].ToString());
                this.lblTotalInversion.Text = totalPagado.ToString("#0.00#");

                //remuevo fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");

            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdIngreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idIngreso"].Value);
            this.txtProveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["proveedor"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.cbTipoComprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipoComprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["correlativo"].Value);
            this.lblTotalInversion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);
            this.txtIVA.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["IVA"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }
    }
}
