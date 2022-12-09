using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service;

namespace ViajeFacilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class paisController : ControllerBase
    {

        public paisservice servico;

        public paisController(ViajeFacilContexto context) : base()
        {
            this.servico = new paisservice(context);
        }

        [HttpGet]
        public ActionResult<List<paispoco>> Obter(int? take = null, int? skip = null)
        {
            try
            {
                List<paispoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<paispoco> Obter(int chave)
        {
            try
            {
                paispoco
                    poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
