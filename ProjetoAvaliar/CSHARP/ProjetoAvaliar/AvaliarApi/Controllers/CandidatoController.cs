using Avaliar.Envelope.Motor;
using Avaliar.Domain.EF;
using Avaliar.Envelope.Modelo;
using Avaliar.Poco;
using Avaliar.Service.Empresa;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Avaliar.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Route("api/avaliar/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private CandidatoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public CandidatoController(AvaliarContext contexto) : base()
        {
            this.servico = new CandidatoServico(contexto);
        }

        /// <summary>
        /// Retorna todos os registros da tabela Candidato
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CandidatoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<CandidatoPoco> listaPoco = this.servico.Listar(take, skip);
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
        /// <param name="proid"></param>
        /// <returns></returns>
        [HttpGet("PorProfissao/{proid:int}")]
        public ActionResult<List<CandidatoPoco>> GetByPessoa(int proid)
        {
            try
            {
                List<CandidatoPoco> listaPoco = this.servico.Consultar(pro => pro.CodigoProfissao == proid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna o registro de acordo com a chave primária informada
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ActionResult<CandidatoPoco> GetById(int chave)
        {
            try
            {
                CandidatoPoco poco = this.servico.PesquisarPorChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a criação de um novo registro
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<CandidatoPoco> Post([FromBody] CandidatoPoco poco)
        {
            try
            {
                CandidatoPoco novaPoco = this.servico.Inserir(poco);
                return Ok(novaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a alteração de um registro
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<CandidatoPoco> Put([FromBody] CandidatoPoco poco)
        {
            try
            {
                CandidatoPoco alteradaPoco = this.servico.Alterar(poco);
                return Ok(alteradaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza a exclusão do registro de acordo com o ID.
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<CandidatoPoco> Delete(int chave)
        {
            try
            {
                CandidatoPoco delPoco = this.servico.Excluir(chave);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }








        /// <summary>
        /// Realiza uma busca dentro de Candidato e traz de forma Envelopada
        /// </summary>
        /// <param name="limite"></param>
        /// <param name="salto"></param>
        /// <returns></returns>
        [HttpGet("envelope/")]
        public ActionResult<EnvelopeGenerico<CandidatoEnvelope>> GetAllEnvelope(int? limite = null, int? salto = null)
        {
            try
            {
                List<CandidatoPoco> listapoco = this.servico.Listar(limite, salto);

                string linkPost = "POST /pessoaprojeto";

                ListEnvelope<CandidatoEnvelope> list;

                if (limite > listapoco.Count())
                {
                    string erro = "Limite não pode ser maior que a quantidade de Registros.";
                    list = new ListEnvelope<CandidatoEnvelope>(null, 400, erro, linkPost, "1.0");
                    return BadRequest(list.Etapa);
                }
                else
                {
                    List<CandidatoEnvelope> listaEnvelope = listapoco.Select(ppr => new CandidatoEnvelope(ppr)).ToList();
                    listaEnvelope.ForEach(item => item.SetLinks());

                    if (salto == null)
                    {
                        list = new ListEnvelope<CandidatoEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0");
                    }
                    else
                    {
                        var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}");
                        string urlServidor = location.AbsoluteUri;
                        list = new ListEnvelope<CandidatoEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0", urlServidor, salto, limite);
                    }
                    return Ok(list.Etapa);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Realiza uma busca pelo ID dentro de Candidato e traz de forma Envelopada
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("envelope/{chave:int}")]
        public ActionResult<CandidatoEnvelope> GetByIdEnvelope(int chave)
        {
            try
            {
                CandidatoPoco poco = this.servico.PesquisarPorChave(chave);
                CandidatoEnvelope envelope = new CandidatoEnvelope(poco);
                envelope.SetLinks();
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}