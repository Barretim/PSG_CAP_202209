using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service;

namespace ViajeFacilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class instituicaoController : ControllerBase
    {

        public instituicaoservice servico;

        public instituicaoController(ViajeFacilContexto context) : base()
        {
            this.servico = new instituicaoservice(context);
        }

        [HttpGet]
        public ActionResult<List<instituicaopoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<instituicaopoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorEndereco/{endid:long}")]
        public ActionResult<List<instituicaopoco>> GetByEndereco(long endid)
        {
            try
            {
                List<instituicaopoco> listaPoco = this.servico.Consultar(end => end.codigoendereco == endid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult<instituicaopoco> Post([FromBody] instituicaopoco poco)
        {
            try
            {
                instituicaopoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public ActionResult<instituicaopoco> Put([FromBody] instituicaopoco poco)
        {
            try
            {
                instituicaopoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{chave:long}")]
        public ActionResult<instituicaopoco> DeleteById(long chave)
        {
            try
            {
                instituicaopoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
