using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedVet.Domain.EF;
using MedVet.Service;
using MedVet.Poco;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace MedVetApi.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Route("api/medvet/[controller]")]
    [ApiController]
    public class TipoAtendimentoController : ControllerBase
    {
        private TipoAtendimentoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public TipoAtendimentoController(MedVetContext contexto) : base()
        {
            this.servico = new TipoAtendimentoServico(contexto);
        }

        /// <summary>
        /// Retorna todos os registros da tabela TipoAtendimento
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<TipoAtendimentoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<TipoAtendimentoPoco> listaPoco = this.servico.Listar(take, skip);
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
        public ActionResult<TipoAtendimentoPoco> GetById(int chave)
        {
            try
            {
                TipoAtendimentoPoco poco = this.servico.PesquisarPelaChave(chave);
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
        public ActionResult<TipoAtendimentoPoco> Post([FromBody] TipoAtendimentoPoco poco)
        {
            try
            {
                TipoAtendimentoPoco novaPoco = this.servico.Inserir(poco);
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
        public ActionResult<TipoAtendimentoPoco> Put([FromBody] TipoAtendimentoPoco poco)
        {
            try
            {
                TipoAtendimentoPoco alteradaPoco = this.servico.Alterar(poco);
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
        public ActionResult<TipoAtendimentoPoco> Delete(int chave)
        {
            try
            {
                TipoAtendimentoPoco delPoco = this.servico.Excluir(chave);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}