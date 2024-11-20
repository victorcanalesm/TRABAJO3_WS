using AlumnosBOL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AlumnosDAL
{
    public class AlumnosDAL
    {
        string connectionString = "Data Source=DESKTOP-M8G7LPH;Initial Catalog=Alumnos y Asignaturas;Integrated Security=True;";





        public void InsertarAlumno(Alumno alumno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"INSERT INTO Alumnos (Nombre, ApellidoPAt, ApellidoMat, Email, NumeroMatricula) 
                                 VALUES (@Nombre, @ApellidoPAt, @ApellidoMat, @Email, @NumeroMatricula); 
                                 SELECT SCOPE_IDENTITY();"; // Esto devuelve el ID generado

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                        command.Parameters.AddWithValue("@ApellidoPAt", alumno.ApellidoPAt);
                        command.Parameters.AddWithValue("@ApellidoMat", alumno.ApellidoMat);
                        command.Parameters.AddWithValue("@Email", alumno.Email);
                        command.Parameters.AddWithValue("@NumeroMatricula", alumno.NumeroMatricula);

                        var result = command.ExecuteScalar();
                        Console.WriteLine($"Alumno insertado con ID: {result}");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al insertar alumno: {ex.Message}");
                }
            }
        }

        public int EliminarAlumno(int IDAlumno)
        {
            int res = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Alumnos WHERE IDAlumno = @IDAlumno";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDAlumno", IDAlumno);
                        res = command.ExecuteNonQuery(); // Devuelve el número de filas afectadas
                        Console.WriteLine($"Alumnos eliminados: {res}");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al eliminar alumno: {ex.Message}");
                }
                return res;
            }
        }

        public List<Alumno> SeleccionarAlumnos()
        {
            List<Alumno> lista = new List<Alumno>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Conexión abierta exitosamente.");
                string query = "SELECT IDAlumno, Nombre, ApellidoPAt, ApellidoMat, Email, NumeroMatricula FROM Alumnos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Alumno alumno = new Alumno();

                        alumno.IDAlumno = dr.GetInt32(0); // Correcto: Asigna el entero al entero
                        alumno.Nombre = dr.GetString(1); // Correcto: Asigna la cadena a la cadena
                        alumno.ApellidoPAt = dr.GetString(2); // Correcto: Asigna la cadena a la cadena
                        alumno.ApellidoMat = dr.GetString(3); // Correcto: Asigna la cadena a la cadena
                        alumno.Email = dr.GetString(4); // Correcto: Asigna la cadena a la cadena

                        // Error potencial aquí
                        alumno.NumeroMatricula = dr.GetInt32(5).ToString(); // Convertir explícitamente a String

                        lista.Add(alumno);
                    }
                }
            }
            return lista;
        }




        public Alumno SeleccionarUnAlumno(int IDAlumno)
        {
            Alumno obj = null; // Inicializa como null para devolverlo en caso de no encontrar el registro
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT IDAlumno, Nombre, ApellidoPAt, ApellidoMat, Email, NumeroMatricula FROM Alumnos WHERE IDAlumno = @IDAlumno";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDAlumno", IDAlumno);
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.Read())
                        {
                            // Si encuentra el registro, crea un nuevo objeto Alumno y asigna los valores
                            obj = new Alumno
                            {
                                IDAlumno = dr.GetInt32(0),
                                Nombre = dr.GetString(1),
                                ApellidoPAt = dr.GetString(2),
                                ApellidoMat = dr.GetString(3),
                                Email = dr.GetString(4),
                                NumeroMatricula = dr.GetInt32(5).ToString() // Convierte a string si lo necesitas como tal
                            };
                        }
                        else
                        {
                            Console.WriteLine($"No se encontró ningún alumno con el ID: {IDAlumno}");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al seleccionar alumno: {ex.Message}");
                }
            }
            return obj; // Devuelve null si no se encontró el registro
        }


        public void ModificarAlumno(Alumno alumno)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"UPDATE Alumnos 
                                     SET Nombre = @Nombre, 
                                         ApellidoPAt = @ApellidoPAt, 
                                         ApellidoMat = @ApellidoMat, 
                                         Email = @Email, 
                                         NumeroMatricula = @NumeroMatricula
                                     WHERE IDAlumno = @IDAlumno;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IDAlumno", alumno.IDAlumno);
                        command.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                        command.Parameters.AddWithValue("@ApellidoPAt", alumno.ApellidoPAt);
                        command.Parameters.AddWithValue("@ApellidoMat", alumno.ApellidoMat);
                        command.Parameters.AddWithValue("@Email", alumno.Email);
                        command.Parameters.AddWithValue("@NumeroMatricula", alumno.NumeroMatricula);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Alumno modificado, filas afectadas: {rowsAffected}");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error al modificar alumno: {ex.Message}");
                }
            }
        }
        public int DatosRePETE(Alumno alum)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                string query = "SELECT COUNT(*) FROM Alumnos WHERE Email = @Email OR NumeroMatricula = @NumeroMatricula";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Email", alum.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NumeroMatricula", alum.NumeroMatricula ?? (object)DBNull.Value);

                    int result;
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result;
                }
            }
        }
    }
}
