using System;
using MySql.Data.MySqlClient;
using capaEntidad;
using System.Windows.Forms;
using System.Data;

namespace capaDatos
{
    public class CDAlumnos
    {
        string CadenaConexion = "Server=localhost;User=root;Port=3306;database=uni"; // Base de datos llamada "uni"

        public void PruebaConexion()
        {

            try
            {
                new MySqlConnection(CadenaConexion).Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Conectarse: " + ex.Message);
                return;
            }

            new MySqlConnection(CadenaConexion).Close();
            MessageBox.Show("Conectado!");
        }

        public void Crear(CEAlumnos cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "INSERT INTO `alumnos` (`nombre`, `apellido`, `carrera`, `matricula`, `imagen`) VALUES ('" + cE.Nombre + "', '" + cE.Apellido + "', '" + cE.Carrera + "', '" + cE.Matricula + "', '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Imagen) + "');";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Creado!");
        }

        public void Editar(CEAlumnos cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "UPDATE `alumnos` SET `nombre`='" + cE.Nombre + "', `apellido`='" + cE.Apellido + "', `carrera`='" + cE.Carrera + "', `matricula`='" + cE.Matricula + "', `imagen`='" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Imagen) + "' WHERE `id`=" + cE.Id + ";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Actualizado!");
        }

        public void Eliminar(CEAlumnos cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "DELETE FROM `alumnos` WHERE `id`=" + cE.Id + ";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Eliminado!");
        }

        public DataSet Listar()
        {
            MySqlConnection mySqlConnection = new(CadenaConexion);
            mySqlConnection.Open();
            string Query = "SELECT * FROM `alumnos` LIMIT 1000;";
            MySqlDataAdapter Adaptador;
            DataSet dataSet = new DataSet();

            Adaptador = new MySqlDataAdapter(Query, mySqlConnection);
            Adaptador.Fill(dataSet, "tbl");

            return dataSet;
        }
    }
}
