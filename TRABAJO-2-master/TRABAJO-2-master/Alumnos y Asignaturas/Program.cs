using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Alumnos_y_Asignaturas
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Cadena de conexión (ajusta según sea necesario)
            string connectionString = "Data Source=DESKTOP-M8G7LPH;Initial Catalog=Alumnos y Asignaturas;Integrated Security=True;";





            try
            {
                // Prueba la conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Conexión exitosa a la base de datos.", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}\nCódigo: {ex.Number}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del programa si la conexión falla
            }

            // Si la conexión es exitosa, inicia la aplicación
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AlumnosForm());
        }
    }
}
