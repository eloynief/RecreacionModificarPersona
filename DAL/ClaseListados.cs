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

        /// <summary>
        /// funcion para obtener el nombre del departamento en funcion del id escrito
        /// </summary>
        /// <param name="id"></param>
        public static String obtenerNombreDepPorId(int id)
        {
            //nombre del departamento a devolver
            String nombreDepar = "";

            //llamamos la funion de azure
            List<claseDepartamento> listadoDeps = ListadoDepartamentosAzureBBDD();

            foreach(claseDepartamento dep in listadoDeps)
            {
                if (dep.Id == id)
                {
                    nombreDepar = dep.Nombre;
                }
            }

            return nombreDepar;
        }



        /// <summary>
        /// funcion que llama a la base de datos y cambia el id de las personas cuyo id me vienen en el listado como parametro en la base de datos al id nuevo
        /// </summary>
        /// <param name="personaIds"></param>
        /// <param name="nuevoDepartamentoId"></param>
        public static void ActualizarDepartamentos(List<int> personaIds, int nuevoDepartamentoId)
        {
            int numeroFilasAfectadas=0;

            miConexion = new SqlConnection();
            miComando = new SqlCommand();

            foreach(int id in personaIds)
            {
                if (id! == nuevoDepartamentoId)
                {
                    miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                        try

                    {

                        miConexion.Open();

                        miComando.CommandText = "UPDATE FROM Departamentos WHERE Id!=@id";

                        miComando.Connection = miConexion;

                        numeroFilasAfectadas = miComando.ExecuteNonQuery();

                    }

                    catch (Exception ex)

                    {

                        throw ex;

                    }
                }
            }
        }//fin ActualizarDepartamentos


    }
}