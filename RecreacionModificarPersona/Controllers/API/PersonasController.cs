using BL;
using Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecreacionModificarPersona.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {

            IActionResult salida;

            List<clasePersona> listado = new List<clasePersona>();



            //try para ponerle los valores a la lista y ponerlos al IactionResult
            try
            {

                listado = claseListadosBL.listadoPersonasAzureBBDDBL();

                if (listado.Count == 0)
                {

                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listado);
                }

            }
            catch (Exception ex)
            {

                salida = BadRequest();

            }


            return salida;
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
