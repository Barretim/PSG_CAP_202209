using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service;

namespace ViajeFacilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class regiaoController : ControllerBase
    {

        public regiaoservice servico;

        public regiaoController(ViajeFacilContexto context) : base()
        {
            this.servico = new regiaoservice(context);
        }

        [HttpGet]
        public ActionResult<List<regiaopoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<regiaopoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorPais/{paiid:long}")]
        public ActionResult<List<regiaopoco>> GetByIBGEPais(long paiid)
        {
            try
            {
                List<regiaopoco> listaPoco = this.servico.Consultar(pai => pai.codigopais == paiid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{chave:long}")]
        public ActionResult<regiaopoco> GetById(long chave)
        {
            try
            {
                regiaopoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult<regiaopoco> Post([FromBody] regiaopoco poco)
        {
            try
            {
                regiaopoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public ActionResult<regiaopoco> Put([FromBody] regiaopoco poco)
        {
            try
            {
                regiaopoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{chave:long}")]
        public ActionResult<regiaopoco> DeleteById(long chave)
        {
            try
            {
                regiaopoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
