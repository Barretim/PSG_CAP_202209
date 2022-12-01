using Clinica.Dominio.EF;
using Clinica.Poco;
using Clinica.Servico;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClinicaApi.Controllers
{
    [Route("api/clinica/[controller]")]
    [ApiController]
    public class TipoServicoController : ControllerBase
    {

        private TipoServicoServico servico;

        public TipoServicoController(ClinicaContext contexto) : base()
        {
            this.servico = new TipoServicoServico(contexto);
        }

        [HttpGet]
        public ActionResult<List<TipoServicoPoco>> Obter(int? take = null, int? skip = null)
        {
            try
            {
                List<TipoServicoPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<TipoServicoPoco> Obter(int chave)
        {
            try
            {
                TipoServicoPoco
                    poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult<TipoServicoPoco> Post([FromBody] TipoServicoPoco poco)
        {
            try
            {
                TipoServicoPoco novo = this.servico.Inserir(poco);
                return Ok(novo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
