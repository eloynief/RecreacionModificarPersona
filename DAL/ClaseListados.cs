using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ClaseListados
    {
        #region atributos para BBDD Azure
        /// <summary>
        /// atrivutos `de  SQL
        /// </summary>
        private static SqlConnection miConexion;
        private static SqlCommand miComando;
        private static SqlDataReader miLector;

        #endregion

        /// <summary>
        /// funcion para recoger los datos de los departamentos de SQL en un listado
        /// </summary>
        /// <returns></returns>
        public static List<claseDepartamento> ListadoDepartamentosAzureBBDD()
        {
            List<claseDepartamento> listado = new List<claseDepartamento>();

            miConexion = new SqlConnection();
            miComando = new SqlCommand();

            claseDepartamento oDepartamento;

            try
            {
                miConexion.ConnectionString = EnlaceBBDD.Conexion();
                miConexion.Open();

                // Creamos el comando
                miComando.CommandText = "SELECT * FROM departamentos";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                // Si hay líneas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oDepartamento = new claseDepartamento
                        {
                            Id = (int)miLector["ID"],
                            Nombre = (string)miLector["Nombre"]
                        };

                        listado.Add(oDepartamento);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listado;
        }

        /// <summary>
        /// funcion para recoger los datos de los personas de SQL en un listado
        /// </summary>
        /// <returns></returns>
        public static List<clasePersona> ListadoPersonasAzureBBDD()
        {
            List<clasePersona> listado = new List<clasePersona>();

            miConexion = new SqlConnection();
            miComando = new SqlCommand();

            clasePersona oPersona;

            try
            {
                miConexion.ConnectionString = EnlaceBBDD.Conexion();
                miConexion.Open();

                // Creamos el comando
                miComando.CommandText = "SELECT * FROM personas";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                // Si hay líneas en el lector
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new clasePersona
                        {
                            Id = (int)miLector["ID"],
                            Nombre = (string)miLector["Nombre"],
                            Apellidos = (string)miLector["Apellidos"],
                            Telefono = (string)miLector["Telefono"],
                            Direccion = (string)miLector["Direccion"],
                            Foto = (string)miLector["Foto"],
                            FechaNacimiento = (DateTime)miLector["FechaNacimiento"],
                            IdDepartamento = (int)miLector["IDDepartamento"]
                        };

                        listado.Add(oPersona);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listado;
        }
    }
}