using Clinica.Dominio.EF;
using Clinica.Poco;
using Clinica.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/clinica/[controller]")]
    [ApiController]
    public class ProcedimentosController : ControllerBase
    {
        private ProcedimentosServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public ProcedimentosController(ClinicaContext contexto) : base()
        { 
            this.servico = new ProcedimentosServico(contexto);
        }


        [HttpGet]
        public ActionResult<List<ServicoPoco>> Obter()
        {
            try
            {
                List<ServicoPoco> lista = this.servico.Listar();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }




    }
}
