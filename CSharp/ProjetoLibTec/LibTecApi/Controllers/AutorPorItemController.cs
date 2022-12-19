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
    public class AutorPorItemController : ControllerBase
    {
        private AutorPorItemServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public AutorPorItemController(LibTecContext contexto) : base()
        {
            this.servico = new AutorPorItemServico(contexto);
        }

        /// <summary>
        /// Retorna todos os registros da tabela AutorPorItem
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<AutorPorItemPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<AutorPorItemPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros da tabela AutorPorItem buscando por Autor
        /// </summary>
        /// <param name="autid"></param>
        /// <returns></returns>
        [HttpGet("PorAutor/{autid:int}")]
        public ActionResult<List<AutorPorItemPoco>> GetByAutor(int autid)
        {
            try
            {
                List<AutorPorItemPoco> listaPoco = this.servico.Consultar(aut => aut.CodigoAutor == autid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros da tabela AutorPorItem buscando por Item
        /// </summary>
        /// <param name="iteid"></param>
        /// <returns></returns>
        [HttpGet("PorItem/{iteid:int}")]
        public ActionResult<List<AutorPorItemPoco>> GetByItem(int iteid)
        {
            try
            {
                List<AutorPorItemPoco> listaPoco = this.servico.Consultar(ite => ite.CodigoItem == iteid).ToList();
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
        public ActionResult<AutorPorItemPoco> GetById(int chave)
        {
            try
            {
                AutorPorItemPoco poco = this.servico.PesquisarPelaChave(chave);
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
        public ActionResult<AutorPorItemPoco> Post([FromBody] AutorPorItemPoco poco)
        {
            try
            {
                AutorPorItemPoco novaPoco = this.servico.Inserir(poco);
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
        public ActionResult<AutorPorItemPoco> Put([FromBody] AutorPorItemPoco poco)
        {
            try
            {
                AutorPorItemPoco alteradaPoco = this.servico.Alterar(poco);
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
        public ActionResult<AutorPorItemPoco> Delete(int chave)
        {
            try
            {
                AutorPorItemPoco delPoco = this.servico.Excluir(chave);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}