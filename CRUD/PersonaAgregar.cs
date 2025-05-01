using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class PersonaAgregar
    {

        public static int AgregarP(Personas personas)
        {
            int retorno = 0;
            using (SqlConnection conexion = BDGeneral.ObtenerConexion())
            {
                string query = "insert into Empleados (Nombre, Apellido, Email, Telefono ) values('" + personas.Nombre + "', '" + personas.Apellido + "', '" + personas.Email + "', '" + personas.Telefono + "')";
                SqlCommand comando = new SqlCommand(query, conexion);

                retorno = comando.ExecuteNonQuery();
            }   
            return retorno;

        }

        public static List<Personas> MostrarRegistro()
        {
            List<Personas> lista = new List<Personas>();

            using (SqlConnection conexion = BDGeneral.ObtenerConexion())
            {
                string query = "select * from Empleados";
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read()) { 
                Personas personas = new Personas();

                personas.Id = reader.GetInt32(0);
                personas.Nombre = reader.GetString(1);
                personas.Apellido = reader.GetString(2);
                personas.Email = reader.GetString(3);
                personas.Telefono = reader.GetString(4);
                lista.Add(personas);
                }

                conexion.Close();
                return lista;

            }
        }

        public static modificarPersona(Personas personas)
        {

        }
           

    }
}
