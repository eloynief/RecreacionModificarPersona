using BL;
using DAL;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using RecreacionModificarPersona.Models.ViewModels;
using System.Diagnostics;

namespace RecreacionModificarPersona.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// metodo principal de la pagina
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            var personas = claseListadosBL.listadoPersonasAzureBBDDBL();
            //var departamentos = claseListadosBL.listadoDepartamentosAzureBBDDBL();

            //Creamos una lista de persona con nombre departamentos
            List<clasePersonaConNombreDep> listapersonaConNombreDeps = new List<clasePersonaConNombreDep>();


            clasePersonaConNombreDep personaConNombreDeps;

            //asignamos los valores a la persona con nombreDeps
            foreach (clasePersona persona in personas)
            {
                //obtengo los datos de la clase persona y se le da a personaConNombreDeps

                personaConNombreDeps = new clasePersonaConNombreDep(persona);



                listapersonaConNombreDeps.Add(personaConNombreDeps);


            }

            //ViewBag.Departamentos = departamentos;
            return View(listapersonaConNombreDeps);
        }

        /// <summary>
        /// funcion para actualizar el nombre del departamento de la persona
        /// </summary>
        /// <param name="personaIds"></param>
        /// <param name="nuevoDepartamentoId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ActualizarPersona(List<int> personaIds, int nuevoDepartamentoId)
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
            {
                ViewBag.Mensaje = "Los domingos no se pueden realizar cambios en los departamentos.";
            }
            else
            {
                ClaseListados.ActualizarDepartamentos(personaIds, nuevoDepartamentoId);
                ViewBag.Mensaje = "Departamentos actualizados correctamente.";
            }

            var personas = claseListadosBL.listadoPersonasAzureBBDDBL();
            var departamentos = claseListadosBL.listadoDepartamentosAzureBBDDBL();
            ViewBag.Departamentos = departamentos;
            return View("Index", personas);
        }
    }
}