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
    public class SubcategoriaController : ControllerBase
    {
        private SubcategoriaServico servico;

        /// <summary>
        /// 
        /// </summary>
        public SubcategoriaController() : base()
        {
            this.servico = new SubcategoriaServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela Subcategoria
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<SubcategoriaPoco> Obter()
        {
            return this.servico.Browse();
        }

        /// <summary>
        /// Busca um registro de Subcategoria pelo Id de Categoria
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        [HttpGet("PorCategoria/{catid:int}")]
        public List<SubcategoriaPoco> GetPorCategoria(int catid)
        {
            return this.servico.Browse(cat =>cat.CodigoCategoria == catid).ToList();
        }

        /// <summary>
        /// Busca um registro de Subcategoria pelo Id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public SubcategoriaPoco ObterPorId(int codigo)
        {
            return this.servico.Read(codigo);
        }

        /// <summary>
        /// Registra um novo registro e um novo Id em Subcategoria
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public SubcategoriaPoco Adicionar([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Add(poco);
        }

        /// <summary>
        /// Atualiza um registro em Subcategoria
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public SubcategoriaPoco Atualizar([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Edit(poco);
        }

        /// <summary>
        /// Exclui um registro de Subcategoria pelo Id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public SubcategoriaPoco ExcluirPorId(int codigo)
        {
            return this.servico.Delete(codigo);
        }

        /// <summary>
        /// Exclui um registro atraves da tabela toda
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public SubcategoriaPoco ExcluirPorInstancia([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}