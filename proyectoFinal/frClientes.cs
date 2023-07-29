using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidad;
using capaNegocio;

namespace capaPresentacion
{
    public partial class frClientes : Form
    {

        CNCliente cNCliente = new CNCliente();

        public frClientes()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarForm();

        }

        private void LimpiarForm()
        {
            txtId.Value = 0;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            picFoto.Image = null;
        }

        private void lnkFoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdFoto.FileName = string.Empty;
            

            if (ofdFoto.ShowDialog() == DialogResult.OK)
            {
                picFoto.Load(ofdFoto.FileName);
            }

            ofdFoto.FileName = string.Empty;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool Resultado;
            CECliente cECliente = new CECliente();
            cECliente.Id = (int)txtId.Value;
            cECliente.Nombre = txtNombre.Text;
            cECliente.Apellido = txtApellido.Text;
            cECliente.Foto = picFoto.ImageLocation;

            Resultado = cNCliente.ValidarDatos(cECliente);
            if (Resultado == false)
            {
                return;
            }

            if (cECliente.Id == 0)
            {
                cNCliente.CrearCliente(cECliente);
            }
            else
            {
                cNCliente.EditarCliente(cECliente);
            }
            

            CargarDatos();
            LimpiarForm();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Value == 0) return;

            if (MessageBox.Show("¿Deseas Eliminar el Registro?","Titulo",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CECliente cE = new CECliente();
                cE.Id = (int)txtId.Value;
                cNCliente.EliminarCliente(cE);
                CargarDatos();
                LimpiarForm();
            }

        }

        private void frClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            gridDatos.DataSource = cNCliente.ObtenerDatos().Tables["tbl"];
        }

        private void gridDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Value = (int)gridDatos.CurrentRow.Cells["id"].Value;
            txtNombre.Text = gridDatos.CurrentRow.Cells["nombre"].Value.ToString();
            txtApellido.Text = gridDatos.CurrentRow.Cells["apellido"].Value.ToString();
            picFoto.Load(gridDatos.CurrentRow.Cells["foto"].Value.ToString());


        }

        private void gridDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
