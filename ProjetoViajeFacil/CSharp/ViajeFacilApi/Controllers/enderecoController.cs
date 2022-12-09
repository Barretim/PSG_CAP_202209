using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service;

namespace ViajeFacilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class enderecoController : ControllerBase
    {

        public enderecoservice servico;

        public enderecoController(ViajeFacilContexto context) : base()
        {
            this.servico = new enderecoservice(context);
        }

        [HttpGet]
        public ActionResult<List<enderecopoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<enderecopoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorNumero/{numid:int}")]
        public ActionResult<List<enderecopoco>> GetByNumero(int numid)
        {
            try
            {
                List<enderecopoco> listaPoco = this.servico.Consultar(num => num.numero == numid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorCidade/{cidid:int}")]
        public ActionResult<List<enderecopoco>> GetByCidade(long cidid)
        {
            try
            {
                List<enderecopoco> listaPoco = this.servico.Consultar(cid => cid.codigocidade == cidid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{chave:int}")]
        public ActionResult<enderecopoco> GetById(long chave)
        {
            try
            {
                enderecopoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult<enderecopoco> Post([FromBody] enderecopoco poco)
        {
            try
            {
                enderecopoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public ActionResult<enderecopoco> Put([FromBody] enderecopoco poco)
        {
            try
            {
                enderecopoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{chave:long}")]
        public ActionResult<enderecopoco> DeleteById(long chave)
        {
            try
            {
                enderecopoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}

