using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service;

namespace ViajeFacilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class estadoController : ControllerBase
    {

        public estadoservice servico;

        public estadoController(ViajeFacilContexto context) : base()
        {
            this.servico = new estadoservice(context);
        }

        [HttpGet]
        public ActionResult<List<estadopoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<estadopoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorRegiao/{regid:long}")]
        public ActionResult<List<estadopoco>> GetByRegiao(long regid)
        {
            try
            {
                List<estadopoco> listaPoco = this.servico.Consultar(reg => reg.codigoregiao == regid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorUF/{ufid:long}")]
        public ActionResult<List<estadopoco>> GetByUF(long ufid)
        {
            try
            {
                List<estadopoco> listaPoco = this.servico.Consultar(uf => uf.codigouf == ufid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{chave:int}")]
        public ActionResult<estadopoco> GetById(long chave)
        {
            try
            {
                estadopoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult<estadopoco> Post([FromBody] estadopoco poco)
        {
            try
            {
                estadopoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public ActionResult<estadopoco> Put([FromBody] estadopoco poco)
        {
            try
            {
                estadopoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{chave:long}")]
        public ActionResult<estadopoco> DeleteById(long chave)
        {
            try
            {
                estadopoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
