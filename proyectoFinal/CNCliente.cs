using System;
using System.Windows.Forms;
using capaEntidad;
using capaDatos;
using System.Data;

namespace capaNegocio
{
    public class CNCliente
    {
        CDCliente cDCliente = new CDCliente();
        public bool ValidarDatos(CECliente cliente)
        {

            bool Resultado = true;

            if (cliente.Nombre == string.Empty)
            {
                Resultado = false;
                MessageBox.Show("El nombre es Obligatorio");
            }

            if (cliente.Apellido == string.Empty)
            {
                Resultado = false;
                MessageBox.Show("El apellido es Obligatorio");
            }


            if (cliente.Foto == null)
            {
                Resultado = false;
                MessageBox.Show("La Foto es Obligatoria");
            }

            return Resultado;

        }

        public void PruebaMySql()
        {
            cDCliente.PruebaConexion();
        }

        public void CrearCliente(CECliente cE)
        {
            cDCliente.Crear(cE);
        }

        public void EditarCliente(CECliente cE)
        {
            cDCliente.Editar(cE);
        }

        public void EliminarCliente(CECliente cE)
        {
            cDCliente.Eliminar(cE);
        }

        public DataSet ObtenerDatos()
        {
            return cDCliente.Listar();
        }

    }
}
