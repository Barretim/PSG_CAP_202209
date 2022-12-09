using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service;

namespace ViajeFacilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cidadeController : ControllerBase
    {

        public cidadeservice servico;

        public cidadeController(ViajeFacilContexto context) : base()
        {
            this.servico = new cidadeservice(context);
        }

        [HttpGet]
        public ActionResult<List<cidadepoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<cidadepoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorCodigoIBGE7/{codid:long}")]
        public ActionResult<List<cidadepoco>> GetByIBGE(long codid)
        {
            try
            {
                List<cidadepoco> listaPoco = this.servico.Consultar(cod => cod.codigoibge7 == codid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorEstado/{estid:long}")]
        public ActionResult<List<cidadepoco>> GetByEstado(long estid)
        {
            try
            {
                List<cidadepoco> listaPoco = this.servico.Consultar(est => est.codigoestado == estid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{chave:long}")]
        public ActionResult<cidadepoco> GetById(long chave)
        {
            try
            {
                cidadepoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult<cidadepoco> Post([FromBody] cidadepoco poco)
        {
            try
            {
                cidadepoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public ActionResult<cidadepoco> Put([FromBody] cidadepoco poco)
        {
            try
            {
                cidadepoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{chave:long}")]
        public ActionResult<cidadepoco> DeleteById(long chave)
        {
            try
            {
                cidadepoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
