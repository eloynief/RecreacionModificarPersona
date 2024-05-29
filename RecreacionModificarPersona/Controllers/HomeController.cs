using BL;
using Microsoft.AspNetCore.Mvc;
using RecreacionModificarPersona.Models;
using System.Diagnostics;

namespace RecreacionModificarPersona.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var personas = claseListadosBL.listadoPersonasAzureBBDDBL();
            var departamentos = claseListadosBL.listadoDepartamentosAzureBBDDBL();
            ViewBag.Departamentos = departamentos;
            return View(personas);
        }

        [HttpPost]
        public IActionResult ActualizarPersona(List<int> personaIds, int nuevoDepartamentoId)
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
            {
                ViewBag.Mensaje = "Los domingos no se pueden realizar cambios en los departamentos.";
            }
            else
            {
                claseListadosBL.ActualizarDepartamentos(personaIds, nuevoDepartamentoId);
                ViewBag.Mensaje = "Departamentos actualizados correctamente.";
            }

            var personas = claseListadosBL.listadoPersonasAzureBBDDBL();
            var departamentos = claseListadosBL.listadoDepartamentosAzureBBDDBL();
            ViewBag.Departamentos = departamentos;
            return View("Index", personas);
        }
    }
}