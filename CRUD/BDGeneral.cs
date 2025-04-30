using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class BDGeneral 
    { 
    public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=EmpleadosListaDB;Data Source=DESKTOP-IIJQ0AO");
            conexion.Open();        

            return conexion;

        }
    }
}
