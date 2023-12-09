using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
namespace PryPlataformaEmpleados
{
    class clsClase
    {

        //MySqlConnection conn = new MySqlConnection();

        static string servidor = "localhost";
        static string bd = "planificadordatabase";
        static string user = "root";
        static string pw = "251199";
        static string port = "3306";



        string cadenaConexion = "server=" + servidor + ";" + "port=" + port + ";" + "user=" + user + ";" + "password=" + pw + ";" + "database=" + bd + ";";



        public bool IniciarSesion(string nombre, string email)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();

                    // Utiliza parámetros con tipos específicos
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM empleados WHERE nombre = @nombre AND mail = @mail", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre).MySqlDbType = MySqlDbType.VarChar;
                        cmd.Parameters.AddWithValue("@mail", email).MySqlDbType = MySqlDbType.VarChar;

                        // Utiliza ExecuteScalar de manera segura para obtener el recuento
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Si el recuento es mayor que 0, las credenciales son válidas
                        return count > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Maneja excepciones específicas de MySQL
                MessageBox.Show("Error de MySQL: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                // Maneja otras excepciones
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }


        public bool NuevoLogeo(string nombre, string email, string fecha, string accion, TimeSpan hora, string anio, string mes, byte[] huella)
        {
            try
            {
                
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string tabla = "logueo_" + anio;
                    using (MySqlCommand cmd = new MySqlCommand($"INSERT INTO {tabla} (fecha, nombre_empleado, accion, hora, mes, huella_dactilar) VALUES (@fecha, @nombre, @accion, @hora, @mes, @huella_dactilar)", conn))
                    {

                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@accion", accion);
                        cmd.Parameters.AddWithValue("@hora", hora);
                        cmd.Parameters.AddWithValue("@mes", mes);
                        cmd.Parameters.AddWithValue("@huella_dactilar", huella);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registro enviado con éxito.");
                        return true;


                    }
                }
                
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades
                MessageBox.Show("Error al registrar: " + ex.Message);
                return false;
            }

            


        }


        public TimeSpan HoraIngreso(string nombre, string anio)
        {
            TimeSpan hora = TimeSpan.Zero;  // Inicializa la variable para evitar problemas de alcance

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
                {
                    string tabla = "logueo_" + anio;
                    string accion = "INGRESO";
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand($"SELECT hora FROM {tabla} WHERE nombre_empleado = @nombre AND accion = @accion ORDER BY id DESC LIMIT 1;", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@accion", accion);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())  // Verifica si hay al menos una fila
                            {
                                // Lee la columna 'hora' y conviértela a TimeSpan
                                if (reader["hora"] != DBNull.Value)
                                {
                                    hora = ((TimeSpan)reader["hora"]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }

            return hora;
        }

        public bool NuevoIngresoEgreso(string nombre, string fecha, TimeSpan horaIngreso, TimeSpan horaEgreso, string mes, string anio)
        {
            int valorHora = 0;
            int horaT = 0;
            int acumulado = 0;
            TimeSpan horasTrabajadas = TimeSpan.Zero;
            if (horaEgreso < horaIngreso)
            {
                horasTrabajadas = (horaEgreso + TimeSpan.FromDays(1)) - horaIngreso;
            }
            else
            {
                horasTrabajadas = horaEgreso - horaIngreso;
            }
            
            horaT = Convert.ToInt32(Math.Round(horasTrabajadas.TotalHours));
            string tabla = "controlhs_" + anio;


            try
            {
                using (MySqlConnection conn = new MySqlConnection(cadenaConexion)) 
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT hora_normal FROM empleados where nombre = @nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                valorHora = Convert.ToInt32(reader["hora_normal"]);
                            }
                        }
                    }   

                    acumulado = horaT * valorHora;


                    using (MySqlCommand cmd = new MySqlCommand($"INSERT INTO {tabla} (fecha, nombre_empleado, hora_ingreso, hora_egreso, horas_trabajadas, acumulado, mes) VALUES (@fecha, @nombre, @horaIngreso, @horaEgreso, @horaT, @acumulado, @mes)", conn)) 
                    {
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@horaIngreso", horaIngreso);
                        cmd.Parameters.AddWithValue("@horaEgreso", horaEgreso);
                        cmd.Parameters.AddWithValue("@horaT", horaT);
                        cmd.Parameters.AddWithValue("@acumulado", acumulado);
                        cmd.Parameters.AddWithValue("@mes", mes);


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registro satisfactorio.");
                        return true;
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
                return false;
            }
        }

    }
}
