using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service;

namespace ViajeFacilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class participanteeventoController : ControllerBase
    {

        public participanteeventoservice servico;

        public participanteeventoController(ViajeFacilContexto context) : base()
        {
            this.servico = new participanteeventoservice(context);
        }

        [HttpGet]
        public ActionResult<List<participanteeventopoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<participanteeventopoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorPagamento/{pagid:int}")]
        public ActionResult<List<participanteeventopoco>> GetByPagamento(int pagid)
        {
            try
            {
                List<participanteeventopoco> listaPoco = this.servico.Consultar(pag => pag.pagamento == pagid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorAvaliacao/{avaid:int}")]
        public ActionResult<List<participanteeventopoco>> GetByAvaliacao(int? avaid)
        {
            try
            {
                List<participanteeventopoco> listaPoco = this.servico.Consultar(ava => ava.avaliacao == avaid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorEvento/{eveid:long}")]
        public ActionResult<List<participanteeventopoco>> GetByEvento(long eveid)
        {
            try
            {
                List<participanteeventopoco> listaPoco = this.servico.Consultar(eve => eve.codigoevento == eveid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorUsuario/{usuid:long}")]
        public ActionResult<List<participanteeventopoco>> GetByUsuario(long usuid)
        {
            try
            {
                List<participanteeventopoco> listaPoco = this.servico.Consultar(usu => usu.codigousuario == usuid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{chave:long}")]
        public ActionResult<participanteeventopoco> GetById(long chave)
        {
            try
            {
                participanteeventopoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult<participanteeventopoco> Post([FromBody] participanteeventopoco poco)
        {
            try
            {
                participanteeventopoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public ActionResult<participanteeventopoco> Put([FromBody] participanteeventopoco poco)
        {
            try
            {
                participanteeventopoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{chave:long}")]
        public ActionResult<participanteeventopoco> DeleteById(long chave)
        {
            try
            {
                participanteeventopoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
