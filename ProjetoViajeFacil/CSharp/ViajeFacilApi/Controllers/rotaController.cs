using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service;

namespace ViajeFacilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class rotaController : ControllerBase
    {

        public rotaservice servico;

        public rotaController(ViajeFacilContexto context) : base()
        {
            servico = new rotaservice(context);
        }

        [HttpGet]
        public ActionResult<List<rotapoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<rotapoco> listaPoco = servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{chave:long}")]
        public ActionResult<rotapoco> GetById(long chave)
        {
            try
            {
                rotapoco poco = servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult<rotapoco> Post([FromBody] rotapoco poco)
        {
            try
            {
                rotapoco novoPoco = servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public ActionResult<rotapoco> Put([FromBody] rotapoco poco)
        {
            try
            {
                rotapoco novoPoco = servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{chave:long}")]
        public ActionResult<rotapoco> DeleteById(long chave)
        {
            try
            {
                rotapoco poco = servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
