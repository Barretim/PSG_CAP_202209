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
    public class AutorController : ControllerBase
    {
        private AutorServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public AutorController(LibTecContext contexto) : base()
        {
            this.servico = new AutorServico(contexto);
        }

        /// <summary>
        /// Retorna todos os registros da tabela Autor
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<AutorPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<AutorPoco> listaPoco = this.servico.Listar(take, skip);
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
        public ActionResult<AutorPoco> GetById(int chave)
        {
            try
            {
                AutorPoco poco = this.servico.PesquisarPelaChave(chave);
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
        public ActionResult<AutorPoco> Post([FromBody] AutorPoco poco)
        {
            try
            {
                AutorPoco novaPoco = this.servico.Inserir(poco);
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
        public ActionResult<AutorPoco> Put([FromBody] AutorPoco poco)
        {
            try
            {
                AutorPoco alteradaPoco = this.servico.Alterar(poco);
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
        public ActionResult<AutorPoco> Delete(int chave)
        {
            try
            {
                AutorPoco delPoco = this.servico.Excluir(chave);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}