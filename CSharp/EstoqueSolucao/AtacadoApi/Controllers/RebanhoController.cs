using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Pecuaria;
using Atacado.Servico.Pecuaria;


namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/pecuaria/[controller]")]
    [ApiController]
    public class RebanhoController : ControllerBase
    {
        private RebanhoServico servico;

        /// <summary>
        /// 
        /// </summary>
        public RebanhoController() : base()
        { 
            this.servico = new RebanhoServico();
        }

        /// <summary>
        /// Obtem a lista de Rebanho
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<RebanhoPoco>> Obter(int? take = null, int? skip = null)
        {
            try
            {
                List<RebanhoPoco> lista = this.servico.Listar(take, skip);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Trás uma lista de Municipio em Rebanho 
        /// </summary>
        /// <param name="munid"></param>
        /// <returns></returns>
        [HttpGet("PorMunicipio/{munid:int}")]
        public ActionResult<List<RebanhoPoco>> GetPorMunicipio(int munid)
        {
            try
            {
                List<RebanhoPoco> lista = this.servico.Consultar(prd => prd.CodigoMunicipio == munid).ToList();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Trás uma lista de Municipio e de Tipo de Rebanho em Rebanho 
        /// </summary>
        /// <param name="tipid"></param>
        /// <param name="munid"></param>
        /// <returns></returns>
        [HttpGet("PorTipoRebanho/{tipid:int}/PorMunicipio/{munid:int}")]
        public ActionResult<List<RebanhoPoco>> GetPorTipoRebanhoPorMunicipio(int tipid, int munid)
        {
            try
            {
                List<RebanhoPoco> lista = this.servico.Consultar(prd => (prd.CodigoTipoRebanho == tipid) && (prd.CodigoMunicipio == munid)).ToList();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Busca um registro de Rebanho por Id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<RebanhoPoco> ObterPorId(int codigo)
        {
            try
            {
                RebanhoPoco poco = this.servico.PesquisaPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Registra um novo registro e um novo Id em Rebanho
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<RebanhoPoco> Adicionar([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco lista = this.servico.Inserir(poco);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Atualiza um registro em Rebanho
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<RebanhoPoco> Atualizar([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco lista = this.servico.Alterar(poco);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro pelo código
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<RebanhoPoco> ExcluirPorId(int codigo)
        {
            try
            {
                RebanhoPoco lista = this.servico.Excluir(codigo);
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
        public ActionResult<RebanhoPoco> ExcluirPorInstancia([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco lista = this.servico.Excluir(poco.CodigoRebanho);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
