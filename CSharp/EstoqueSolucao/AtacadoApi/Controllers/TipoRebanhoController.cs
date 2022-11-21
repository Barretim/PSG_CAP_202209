using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Pecuaria;
using Atacado.Servico.Pecuaria;
using Atacado.DB.EF.Database;

namespace AtacadoApi.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Route("api/pecuaria/[controller]")]
    [ApiController]
    public class TipoRebanhoController : ControllerBase
    {
        private TipoRebanhoServico servico;

        /// <summary>
        /// 
        /// </summary>
        public TipoRebanhoController(ProjetoAcademiaContext contexto) : base()
        {
            this.servico = new TipoRebanhoServico(contexto);
        }

        /// <summary>
        /// Lista todos os registros da tabela TipoRebanho
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<TipoRebanhoPoco>> Obter()
        {
            try
            {
                List<TipoRebanhoPoco> lista = this.servico.Listar();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Busca um registro de TipoRebanho pelo Id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<TipoRebanhoPoco> ObterPorId(int codigo)
        {
            try
            {
                TipoRebanhoPoco lista = this.servico.PesquisaPelaChave(codigo);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Registra um novo registro e um novo Id em TipoRebanho
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<TipoRebanhoPoco> Adicionar([FromBody] TipoRebanhoPoco poco)
        {
            try
            {
                TipoRebanhoPoco lista = this.servico.Inserir(poco);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Atualiza um registro em TipoRebanho
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<TipoRebanhoPoco> Atualizar([FromBody] TipoRebanhoPoco poco)
        {
            try
            {
                TipoRebanhoPoco lista = this.servico.Alterar(poco);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro de TipoRebanho pelo Id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<TipoRebanhoPoco> ExcluirPorId(int codigo)
        {
            try
            {
                TipoRebanhoPoco lista = this.servico.Excluir(codigo);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro atraves da tabela toda
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<TipoRebanhoPoco> ExcluirPorInstancia([FromBody] TipoRebanhoPoco poco)
        {
            try
            {
                TipoRebanhoPoco lista = this.servico.Excluir(poco.CodigoTipo);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
