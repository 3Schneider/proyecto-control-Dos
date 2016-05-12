using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LayerDataControl
{
    public class DataControl
    {
        //string de conexion
        public string strconn = @"Data Source=DESKTOP-0PR0TLI;Initial Catalog = BDControlColocacion; Integrated Security = True";

        //metodo constructor
        public DataControl() { }

        //metodo  insertar empleado para enlazar con el stor procidios
        public int InsertarUsuario(Int64 IdCodigo, string Apellidos, string Nombre,long FechaNacimiento,string CargoEmpleado, int NumeroTelefono,string Email)
        {
            using (SqlConnection cnx = new SqlConnection(strconn))
            {
                //conexion a la base de datos
                cnx.Open();
                SqlCommand OrdenSql = new SqlCommand("SPInsertarUsuario", cnx);
                OrdenSql.CommandType = CommandType.StoredProcedure;
                //loque se va a ejecutar para validar si no prosigue
                try
                {
                    OrdenSql.Parameters.AddWithValue("@IdCodigo", IdCodigo);
                    OrdenSql.Parameters.AddWithValue("@Apellidos", Apellidos);
                    OrdenSql.Parameters.AddWithValue("@Nombres", Nombre);
                    OrdenSql.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                    OrdenSql.Parameters.AddWithValue("@CargoEmpleado", CargoEmpleado);
                    OrdenSql.Parameters.AddWithValue("@NumeroTelefono",NumeroTelefono);
                    OrdenSql.Parameters.AddWithValue("@Email", Email);

                    return OrdenSql.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    //se cierra la conexion a la BD 
                    cnx.Close();
                    cnx.Dispose();
                    OrdenSql.Dispose();
                }
            }
        }
    }
}
