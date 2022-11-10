using Atacado.Servico.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Estoque;
using System;


namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private ProdutoServico servico;

        /// <summary>
        /// 
        /// </summary>
        public ProdutoController() : base()
        {
            this.servico = new ProdutoServico();
        }

        [HttpGet]
        public List<ProdutoPoco> Get(int? take = null, int? skip = null)
        { 
            return this.servico.Listar(take, skip);
        }

        /// <summary>
        /// Lista todos os registros da tabela Produto
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ProdutoPoco>> Obter()
        {
            try
            {
                List<ProdutoPoco> lista = this.servico.Listar();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Listar todos os registros da tabela Categoria
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        [HttpGet("PorCategoria/{catid:int}")]
        public ActionResult<List<ProdutoPoco>> GetPorCategoria(int catid)
        {
            try
            {
                List<ProdutoPoco> lista = this.servico.Consultar(prd => prd.CodigoCategoria == catid).ToList();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Listar todos os registros da tabela Subcategoria
        /// </summary>
        /// <param name="subid"></param>
        /// <returns></returns>
        [HttpGet("PorSubcategoria/{subid:int}")]
        public ActionResult<List<ProdutoPoco>> GetPorSubcategoria(int subid)
        {
            try
            {
                List<ProdutoPoco> lista = this.servico.Consultar(prd => prd.CodigoSubcategoria == subid).ToList();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Busca um registro de Produto pelo Id de Subcategoria e pelo Id de Categoria
        /// </summary>
        /// <param name="catid"></param>
        /// <param name="subid"></param>
        /// <returns></returns>
        [HttpGet("PorCategoria/{catid:int}/PorSubcategoria/{subid:int}")]
        public ActionResult<List<ProdutoPoco>> GetPorCategoriaPorSubcategoria(int catid, int subid)
        {
            try
            {
                List<ProdutoPoco> lista = this.servico.Consultar(prd => (prd.CodigoCategoria == catid) && (prd.CodigoSubcategoria == subid)).ToList();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Busca um registro de Produto pelo Id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<ProdutoPoco> ObterPorId(int codigo)
        {
            try
            {
                ProdutoPoco lista = this.servico.PesquisaPelaChave(codigo);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Registra um novo registro e um novo Id em Produto
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ProdutoPoco> Adicionar([FromBody] ProdutoPoco poco)
        {
            try
            {
                ProdutoPoco lista = this.servico.Inserir(poco);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Atualiza um registro em Produto
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ProdutoPoco> Atualizar([FromBody] ProdutoPoco poco)
        {
            try
            {
                ProdutoPoco lista = this.servico.Alterar(poco);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro de Produto pelo Id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<ProdutoPoco> ExcluirPorId(int codigo)
        {
            try
            {
                ProdutoPoco lista = this.servico.Excluir(codigo);
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
        public ActionResult<ProdutoPoco> ExcluirPorInstancia([FromBody] ProdutoPoco poco)
        {
            try
            {
                ProdutoPoco lista = this.servico.Excluir(poco.Codigo);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}