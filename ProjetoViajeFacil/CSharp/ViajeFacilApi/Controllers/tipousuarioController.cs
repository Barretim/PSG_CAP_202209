using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service;

namespace ViajeFacilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tipousuarioController : ControllerBase
    {

        public tipousuarioservice servico;

        public tipousuarioController(ViajeFacilContexto context) : base()
        {
            servico = new tipousuarioservice(context);
        }

        [HttpGet]
        public ActionResult<List<tipousuariopoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<tipousuariopoco> listaPoco = servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{chave:long}")]
        public ActionResult<tipousuariopoco> GetById(long chave)
        {
            try
            {
                tipousuariopoco poco = servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult<tipousuariopoco> Post([FromBody] tipousuariopoco poco)
        {
            try
            {
                tipousuariopoco novoPoco = servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public ActionResult<tipousuariopoco> Put([FromBody] tipousuariopoco poco)
        {
            try
            {
                tipousuariopoco novoPoco = servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{chave:long}")]
        public ActionResult<tipousuariopoco> DeleteById(long chave)
        {
            try
            {
                tipousuariopoco poco = servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
