using DAL;
using Entidades;

namespace BL
{
    public class claseListadosBL
    {
        #region BL de los listados de azure

        /// <summary>
        /// funciones  para recoger los datos de la DAL y conectarlos al controlller
        /// </summary>
        /// <returns></returns>
        public static List<clasePersona> listadoPersonasAzureBBDDBL()
        {
            List<clasePersona> listadoDAL = ClaseListados.ListadoPersonasAzureBBDD();

            return listadoDAL;
        }

        public static List<claseDepartamento> listadoDepartamentosAzureBBDDBL()
        {
            List<claseDepartamento> listadoDAL = ClaseListados.ListadoDepartamentosAzureBBDD();


            return listadoDAL;
		}

        #endregion

        public static void reglaNegocio()
        {

            //codigo

        }


    }
}