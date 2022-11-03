using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Estoque;
using Atacado.Servico.Estoque;


namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private CategoriaServico servico;
        /// <summary>
        /// 
        /// </summary>
        public CategoriaController() : base()
        {
            this.servico = new CategoriaServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela Categoria
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<CategoriaPoco> Obter()
        {
            return this.servico.Browse();

        }

        /// <summary>
        /// Busca um registro de Categoria por Id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public CategoriaPoco ObterPorId(int codigo)
        {
            return this.servico.Read(codigo);
        }

        /// <summary>
        /// Registra um novo registro e um novo Id em Categoria
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public CategoriaPoco Adicionar([FromBody] CategoriaPoco poco)
        {
            return this.servico.Add(poco);
        }

        /// <summary>
        /// Atualiza um registro em Categoria
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public CategoriaPoco Atualizar([FromBody] CategoriaPoco poco)
        {
            return this.servico.Edit(poco);
        }

        /// <summary>
        /// Exclui um registro pelo código
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public CategoriaPoco ExcluirPorId(int codigo)
        {
            return this.servico.Delete(codigo);
        }

        /// <summary>
        /// Exclui um registro atraves da tabela toda
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public CategoriaPoco ExcluirPorInstancia([FromBody] CategoriaPoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}
