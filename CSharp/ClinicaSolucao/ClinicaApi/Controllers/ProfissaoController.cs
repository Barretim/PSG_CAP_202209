using Clinica.Dominio.EF;
using Clinica.Poco;
using Clinica.Servico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/clinica/[controller]")]
    [ApiController]
    public class ProfissaoController : ControllerBase
    {

        /// <summary>
        /// 
        /// </summary>
        public ProfissaoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public ProfissaoController(ClinicaContext contexto) : base()
        {
            this.servico = new ProfissaoServico(contexto);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ProfissaoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<ProfissaoPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("{chave:int}")]
        public ActionResult<ProfissaoPoco> GetById(int chave)
        {
            try
            {
                ProfissaoPoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ProfissaoPoco> Post([FromBody] ProfissaoPoco poco)
        {
            try
            {
                ProfissaoPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ProfissaoPoco> Put([FromBody] ProfissaoPoco poco)
        {
            try
            {
                ProfissaoPoco alteradaPoco = this.servico.Alterar(poco);
                return Ok(alteradaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<ProfissaoPoco> Delete(int chave)
        {
            try
            {
                ProfissaoPoco pocoExclusao = this.servico.Excluir(chave);
                return Ok(pocoExclusao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
