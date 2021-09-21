using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TablasDinamicas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cargarTabla(null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dato = txtCampo.Text;
            cargarTabla(dato);
        }

        private void cargarTabla(String dato)
        {
            List<Productos> lista = new List<Productos>();
            CtrlProductos _ctrlProductos = new CtrlProductos();
            dataGridView1.DataSource = _ctrlProductos.consulta(dato);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            Productos _producto = new Productos();
            _producto.Codigo = int.Parse(txtCodigo.Text);
            _producto.Nombre = txtNombre.Text;
            _producto.Descripcion = txtDescripcion.Text;
            _producto.Precio_publico = double.Parse(txtPrecio_publico.Text);
            _producto.Existencias = int.Parse(txtExistencias.Text);

            CtrlProductos ctrl = new CtrlProductos();
            if(txtCodigo.Text != "")
            {
                _producto.Codigo = int.Parse(txtCodigo.Text);
                bandera = ctrl.actualizar(_producto);
            }
            else
            {
               bandera = ctrl.insertar(_producto);
            }

            if (bandera)
            {
                MessageBox.Show("Registro guardado");
                limpiar();
                cargarTabla(null);
            }
        }

        private void limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio_publico.Text = "";
            txtExistencias.Text = "";

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPrecio_publico.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtExistencias.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Seguro que desea eliminar el registro?", "Salir", MessageBoxButtons.YesNoCancel);

            if(resultado == DialogResult.Yes)
            {
                int codigo = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                CtrlProductos _ctrl = new CtrlProductos();
                _ctrl.eliminar(codigo);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

    }
}
