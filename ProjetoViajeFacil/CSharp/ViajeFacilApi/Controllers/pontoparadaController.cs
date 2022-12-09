using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service;

namespace ViajeFacilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pontoparadaController : ControllerBase
    {

        public pontoparadaservice servico;

        public pontoparadaController(ViajeFacilContexto context) : base()
        {
            this.servico = new pontoparadaservice(context);
        }

        [HttpGet]
        public ActionResult<List<pontoparadapoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<pontoparadapoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorRota/{rotid:long}")]
        public ActionResult<List<pontoparadapoco>> GetByRota(long rotid)
        {
            try
            {
                List<pontoparadapoco> listaPoco = this.servico.Consultar(rot => rot.codigorota == rotid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{chave:long}")]
        public ActionResult<pontoparadapoco> GetById(long chave)
        {
            try
            {
                pontoparadapoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult<pontoparadapoco> Post([FromBody] pontoparadapoco poco)
        {
            try
            {
                pontoparadapoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public ActionResult<pontoparadapoco> Put([FromBody] pontoparadapoco poco)
        {
            try
            {
                pontoparadapoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{chave:long}")]
        public ActionResult<pontoparadapoco> DeleteById(long chave)
        {
            try
            {
                pontoparadapoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
