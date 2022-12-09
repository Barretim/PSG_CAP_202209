
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service;

namespace ViajeFacilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class eventoController : ControllerBase
    {

        public eventoservice servico;

        public eventoController(ViajeFacilContexto context) : base()
        {
            this.servico = new eventoservice(context);
        }

        [HttpGet]
        public ActionResult<List<eventopoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<eventopoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorInstituicao/{insid:long}")]
        public ActionResult<List<eventopoco>> GetByInstituicao(long insid)
        {
            try
            {
                List<eventopoco> listaPoco = this.servico.Consultar(ins => ins.codigoinstituicao == insid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorRotaIda/{idaid:long}")]
        public ActionResult<List<eventopoco>> GetRotaIda(long idaid)
        {
            try
            {
                List<eventopoco> listaPoco = this.servico.Consultar(ida => ida.codigorotaida == idaid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorRotaVolta/{volid:long}")]
        public ActionResult<List<eventopoco>> GetByRotaVolta(long volid)
        {
            try
            {
                List<eventopoco> listaPoco = this.servico.Consultar(vol => vol.codigorotavolta == volid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorUsuario/{usuid:long}")]
        public ActionResult<List<eventopoco>> GetByUsuario(long usuid)
        {
            try
            {
                List<eventopoco> listaPoco = this.servico.Consultar(usu => usu.codigousuarioresponsavel == usuid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{chave:long}")]
        public ActionResult<eventopoco> GetById(long chave)
        {
            try
            {
                eventopoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult<eventopoco> Post([FromBody] eventopoco poco)
        {
            try
            {
                eventopoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public ActionResult<eventopoco> Put([FromBody] eventopoco poco)
        {
            try
            {
                eventopoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{chave:long}")]
        public ActionResult<eventopoco> DeleteById(long chave)
        {
            try
            {
                eventopoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
