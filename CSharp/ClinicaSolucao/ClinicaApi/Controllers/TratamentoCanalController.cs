using Clinica.Dominio.EF;
using Clinica.Poco;
using Clinica.Servico;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers
{
    [Route("api/clinica/[controller]")]
    [ApiController]
    public class TratamentoCanalController : ControllerBase
    {
        private ProcedimentosServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public TratamentoCanalController(ClinicaContext contexto) : base()
        {
            this.servico = new ProcedimentosServico(contexto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoServico"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ServicoPoco>> Obter(int? take = null, int? skip = null)
        {
            try
            {
                List<ServicoPoco> listaPoco;
                var predicado = PredicateBuilder.New<Clinica.Dominio.EF.Servico>(true);
                if (take == null)
                {
                    if (skip != null)
                    {
                        return BadRequest("Informe os parametros take e skip");
                    }
                    else
                    {
                        predicado = predicado.And(s => s.TipoServico == "TC");
                        listaPoco = this.servico.Consultar(predicado);
                        return Ok(listaPoco);
                    }
                }
                else
                {
                    if (skip == null)
                    {
                        return BadRequest("Informe os parametros take e skip");
                    }
                    else
                    {
                        predicado = predicado.And(s => s.TipoServico == "TC");
                        listaPoco = this.servico.Vasculhar(take, skip, predicado);
                        return Ok(listaPoco);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public ActionResult<ServicoPoco> Obter(int id)
        {
            try
            {
                List<ServicoPoco> listaPoco = this.servico.Consultar(s => (s.TipoServico == "TC") && (s.CodigoServico == id));
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ServicoPoco> Adicionar([FromBody] ServicoPoco poco)
        {
            try
            {
                ServicoPoco lista = this.servico.Inserir(poco);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ServicoPoco> Atualizar([FromBody] ServicoPoco poco)
        {
            try
            {
                ServicoPoco lista = this.servico.Alterar(poco);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<ServicoPoco> ExcluirPorId(int codigo)
        {
            try
            {
                ServicoPoco lista = this.servico.Excluir(codigo);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<ServicoPoco> ExcluirPorInstancia([FromBody] ServicoPoco poco)
        {
            try
            {
                ServicoPoco lista = this.servico.Excluir(poco.CodigoServico);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
