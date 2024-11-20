using Alumnos_y_Asignaturas.AlumnosAsignaturaWS;
using AlumnosBLL;
using AlumnosBOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Alumnos_y_Asignaturas
{
    public partial class AlumnosForm : Form
    {
        string IDGlobal = "";
        public AlumnosForm()
        {
            InitializeComponent();
        }

        void ListarAlumnos()
        {
            try
            {
                List<Alumno> list = AlumnosBLL.AlumnosBL.SeleccionarAlumnos();
                Console.WriteLine("Cantidad de alumnos obtenidos: " + (list?.Count ?? 0));

                if (list != null && list.Count > 0)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = list;
                    dataGridView1.Refresh();
                }
                else
                {
                    Console.WriteLine("La lista de alumnos está vacía o es nula.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en ListarAlumnos: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AsignaturaForm asi = new AsignaturaForm();
            asi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BoxNombre.Text) ||
                string.IsNullOrWhiteSpace(BoxApellidoPat.Text) ||
                string.IsNullOrWhiteSpace(BoxApellidoMat.Text) ||
                string.IsNullOrWhiteSpace(BoxEmail.Text))
            {
                MessageBox.Show("Todos los campos de texto deben estar completos.");
                return;
            }

            if (!IsValidEmail(BoxEmail.Text))
            {
                MessageBox.Show("Por favor, introduce un correo electrónico válido.");
                return;
            }

            if (!int.TryParse(BoxNumMatricula.Text, out int numeroMatricula))
            {
                MessageBox.Show("Por favor, introduce un número válido para la matrícula.");
                return;
            }

            if (string.IsNullOrEmpty(IDGlobal))
            {
                Alumno alum = new Alumno
                {
                    Nombre = BoxNombre.Text,
                    ApellidoPAt = BoxApellidoPat.Text,
                    ApellidoMat = BoxApellidoMat.Text,
                    Email = BoxEmail.Text,
                    NumeroMatricula = BoxNumMatricula.Text
                };

                AlumnosBLL.AlumnosBL alumnosBL = new AlumnosBLL.AlumnosBL();
                string fallas;

                if (alumnosBL.DatosRepetidos(alum) == 0)
                {
                    if (AlumnosBLL.AlumnosBL.Insertar(alum, out fallas))
                    {
                        MessageBox.Show("Registro insertado correctamente.");
                        LimpiarCampos();
                        ListarAlumnos();
                    }
                    else
                    {
                        MessageBox.Show($"Error al insertar el registro: {fallas}");
                    }
                }
                else
                {
                    MessageBox.Show("Los datos ingresados ya están registrados.");
                }
            }
            else
            {
                if (int.TryParse(IDGlobal, out int Id))
                {
                    Alumno alumno = AlumnosBLL.AlumnosBL.SeleccionarUnAlumno(Id);
                    alumno.Nombre = BoxNombre.Text;
                    alumno.ApellidoPAt = BoxApellidoPat.Text;
                    alumno.ApellidoMat = BoxApellidoMat.Text;
                    alumno.Email = BoxEmail.Text;
                    alumno.NumeroMatricula = numeroMatricula.ToString();
                    AlumnosAsignaturaWS.MiWS ws = new AlumnosAsignaturaWS.MiWS();
                    ws.GuardarAlum(BoxNombre.Text, BoxApellidoPat.Text, BoxApellidoMat.Text, BoxEmail.Text,numeroMatricula);
                

                    string falla;
                    if (AlumnosBLL.AlumnosBL.Modificar(alumno, out falla))
                    {
                        MessageBox.Show("Datos modificados correctamente.");
                        IDGlobal = "";
                        LimpiarCampos();
                        ListarAlumnos();
                    }
                    else
                    {
                        MessageBox.Show($"Error al modificar los datos: {falla}");
                    }
                }
                else
                {
                    MessageBox.Show("ID inválido. No se puede modificar.");
                }
            }

        }

        private void LimpiarCampos()
        {
            BoxNombre.Text = "";
            BoxApellidoPat.Text = "";
            BoxApellidoMat.Text = "";
            BoxEmail.Text = "";
            BoxNumMatricula.Text = "";
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void AlumnosForm_Load(object sender, EventArgs e)
        {
            try
            {
                
                this.alumnosTableAdapter.Connection.ConnectionString = "Data Source=DESKTOP-M8G7LPH;Initial Catalog=Alumnos y Asignaturas;Integrated Security=True;";
                this.alumnosTableAdapter.Fill(this.alumnos_y_AsignaturasDataSet.Alumnos);
                MessageBox.Show("Datos cargados correctamente.");
               

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
            
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                AlumnosBLL.AlumnosBL.Eliminar(id);
                ListarAlumnos();
                MessageBox.Show("Registro eliminado.");
            }
            else
            {
                MessageBox.Show("Selecciona un registro para eliminar.");
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                IDGlobal = id.ToString();

                Alumno alumno = AlumnosBLL.AlumnosBL.SeleccionarUnAlumno(id);
                BoxNombre.Text = alumno.Nombre;
                BoxApellidoPat.Text = alumno.ApellidoPAt;
                BoxApellidoMat.Text = alumno.ApellidoMat;
                BoxEmail.Text = alumno.Email;
                BoxNumMatricula.Text = alumno.NumeroMatricula;
            }
            else
            {
                MessageBox.Show("Selecciona un registro para modificar.");
            }
        }

        private void Bt_DescargarAlumn_Click(object sender, EventArgs e)
        {
            AlumnosAsignaturaWS.MiWS ws = new AlumnosAsignaturaWS.MiWS();
            // Obtener la lista de alumnos desde el servicio web
            List<AlumnosAsignaturaWS.Alumnos> lista = ws.listarAlumn().ToList();
            string fallas;

            foreach (var item in lista)
            {
                Alumno alum = new Alumno
                {
                    Nombre = item.Nombre,
                    ApellidoPAt = item.ApellidoPAt,
                    ApellidoMat = item.ApellidoMat,
                    Email = item.Email,
                    NumeroMatricula = item.NumeroMatricula.ToString(),
                };

                AlumnosBLL.AlumnosBL.Insertar(alum, out fallas);
            }
            ListarAlumnos();
        }

    }
}
