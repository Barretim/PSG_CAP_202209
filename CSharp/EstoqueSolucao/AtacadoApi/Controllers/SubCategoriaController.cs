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
        public ActionResult<List<SubcategoriaPoco>> Obter()
        {
            try
            {
                List<SubcategoriaPoco> lista = this.servico.Browse();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Busca um registro de Subcategoria pelo Id de Categoria
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        [HttpGet("PorCategoria/{catid:int}")]
        public ActionResult<List<SubcategoriaPoco>> GetPorCategoria(int catid)
        {
            try
            {
                List<SubcategoriaPoco> lista = this.servico.Browse(cat => cat.CodigoCategoria == catid).ToList();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Busca um registro de Subcategoria pelo Id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<SubcategoriaPoco> ObterPorId(int codigo)
        {
            try
            {
               SubcategoriaPoco lista = this.servico.Read(codigo);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Registra um novo registro e um novo Id em Subcategoria
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<SubcategoriaPoco> Adicionar([FromBody] SubcategoriaPoco poco)
        {
            try
            {
                SubcategoriaPoco lista = this.servico.Add(poco);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Atualiza um registro em Subcategoria
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<SubcategoriaPoco> Atualizar([FromBody] SubcategoriaPoco poco)
        {
            try
            {
                SubcategoriaPoco lista = this.servico.Edit(poco);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro de Subcategoria pelo Id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<SubcategoriaPoco> ExcluirPorId(int codigo)
        {
            try
            {
                SubcategoriaPoco lista = this.servico.Delete(codigo);
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
        public ActionResult<SubcategoriaPoco> ExcluirPorInstancia([FromBody] SubcategoriaPoco poco)
        {
            try
            {
                SubcategoriaPoco lista = this.servico.Delete(poco);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}