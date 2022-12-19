using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibTec.Domain.EF;
using LibTec.Service;
using LibTec.Poco;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace LibTecApi.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Route("api/libtec/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ItemServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public ItemController(LibTecContext contexto) : base()
        {
            this.servico = new ItemServico(contexto);
        }

        /// <summary>
        /// Retorna todos os registros da tabela Item
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ItemPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<ItemPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros da tabela Item buscando por TipoItem
        /// </summary>
        /// <param name="ateid"></param>
        /// <returns></returns>
        [HttpGet("PorTipoItem/{tipid:int}")]
        public ActionResult<List<ItemPoco>> GetByTipoItem(int tipid)
        {
            try
            {
                List<ItemPoco> listaPoco = this.servico.Consultar(tip => tip.CodigoTipoItem == tipid).ToList();
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
        public ActionResult<ItemPoco> GetById(int chave)
        {
            try
            {
                ItemPoco poco = this.servico.PesquisarPelaChave(chave);
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
        public ActionResult<ItemPoco> Post([FromBody] ItemPoco poco)
        {
            try
            {
                ItemPoco novaPoco = this.servico.Inserir(poco);
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
        public ActionResult<ItemPoco> Put([FromBody] ItemPoco poco)
        {
            try
            {
                ItemPoco alteradaPoco = this.servico.Alterar(poco);
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
        public ActionResult<ItemPoco> Delete(int chave)
        {
            try
            {
                ItemPoco delPoco = this.servico.Excluir(chave);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}