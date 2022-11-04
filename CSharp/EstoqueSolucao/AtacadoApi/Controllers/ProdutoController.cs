using Atacado.Servico.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Estoque;


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

        /// <summary>
        /// Lista todos os registros da tabela Produto
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ProdutoPoco> Obter()
        {
            return this.servico.Browse();
        }

        /// <summary>
        /// Listar todos os registros da tabela Categoria
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        [HttpGet("PorCategoria/{catid:int}")]
        public List<ProdutoPoco> GetPorCategoria(int catid)
        {
            return this.servico.Browse(prd => prd.CodigoCategoria == catid).ToList();
        }

        /// <summary>
        /// Listar todos os registros da tabela Subcategoria
        /// </summary>
        /// <param name="subid"></param>
        /// <returns></returns>
        [HttpGet("PorSubcategoria/{subid:int}")]
        public List<ProdutoPoco> GetPorSubcategoria(int subid)
        {
            return this.servico.Browse(prd => prd.CodigoSubcategoria == subid).ToList();
        }

        /// <summary>
        /// Busca um registro de Produto pelo Id de Subcategoria e pelo Id de Categoria
        /// </summary>
        /// <param name="catid"></param>
        /// <param name="subid"></param>
        /// <returns></returns>
        [HttpGet("PorCategoria/{catid:int}/PorSubcategoria/{subid:int}")]
        public List<ProdutoPoco> GetPorCategoriaPorSubcategoria(int catid, int subid)
        {
            return this.servico.Browse(prd => (prd.CodigoCategoria == catid) && (prd.CodigoSubcategoria == subid)).ToList();
        }

        /// <summary>
        /// Busca um registro de Produto pelo Id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ProdutoPoco ObterPorId(int codigo)
        {
            return this.servico.Read(codigo);
        }

        /// <summary>
        /// Registra um novo registro e um novo Id em Produto
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ProdutoPoco Adicionar([FromBody] ProdutoPoco poco)
        {
            return this.servico.Add(poco);
        }

        /// <summary>
        /// Atualiza um registro em Produto
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ProdutoPoco Atualizar([FromBody] ProdutoPoco poco)
        {
            return this.servico.Edit(poco);
        }

        /// <summary>
        /// Exclui um registro de Produto pelo Id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ProdutoPoco ExcluirPorId(int codigo)
        {
            return this.servico.Delete(codigo);
        }

        /// <summary>
        /// Exclui um registro atraves da tabela toda
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ProdutoPoco ExcluirPorInstancia([FromBody] ProdutoPoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}