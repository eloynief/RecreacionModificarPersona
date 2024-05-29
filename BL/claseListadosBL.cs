using DAL;
using Entidades;

namespace BL
{
    public class claseListadosBL
    {
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



        /// <summary>
        /// funcion para actualizar los departamentos 
        /// </summary>
        /// <param name="personaIds"></param>
        /// <param name="nuevoDepartamentoId"></param>
        public static void ActualizarDepartamentos(List<int> personaIds, int nuevoDepartamentoId)
        {
            // Lógica para actualizar el departamento de las personas seleccionadas en la BBDD
            var personas = listadoPersonasAzureBBDDBL();

            List<claseDepartamento> deps = listadoDepartamentosAzureBBDDBL();


            foreach (var persona in personas.Where(p => personaIds.Contains(p.Id)))
            {
                persona.IdDepartamento = nuevoDepartamentoId;
                // Lógica para guardar los cambios en la BBDD
            }
        }


    }
}