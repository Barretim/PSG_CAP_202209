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
    public class AtendimentoController : ControllerBase
    {
        private AtendimentoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public AtendimentoController(MedVetContext contexto) : base()
        {
            this.servico = new AtendimentoServico(contexto);
        }

        /// <summary>
        /// Retorna todos os registros da tabela Atendimento
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<AtendimentoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<AtendimentoPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros da tabela Atendimento buscando por TipoAtendimento
        /// </summary>
        /// <param name="tipid"></param>
        /// <returns></returns>
        [HttpGet("PorTipoAtendimento/{tipid:int}")]
        public ActionResult<List<AtendimentoPoco>> GetByTipoAtendimento(int tipid)
        {
            try
            {
                List<AtendimentoPoco> listaPoco = this.servico.Consultar(tip => tip.CodigoTipoAtendimento == tipid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros da tabela Atendimento buscando por Atendente
        /// </summary>
        /// <param name="ateid"></param>
        /// <returns></returns>
        [HttpGet("PorAtendente/{ateid:int}")]
        public ActionResult<List<AtendimentoPoco>> GetByAtendente(int ateid)
        {
            try
            {
                List<AtendimentoPoco> listaPoco = this.servico.Consultar(ate => ate.CodigoAtendente == ateid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros da tabela Atendimento buscando por Paciente
        /// </summary>
        /// <param name="pacid"></param>
        /// <returns></returns>
        [HttpGet("PorPaciente/{pacid:int}")]
        public ActionResult<List<AtendimentoPoco>> GetByPaciente(int pacid)
        {
            try
            {
                List<AtendimentoPoco> listaPoco = this.servico.Consultar(pac => pac.CodigoTipoAtendimento == pacid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros da tabela Atendimento buscando por Medico
        /// </summary>
        /// <param name="medid"></param>
        /// <returns></returns>
        [HttpGet("PorMedico/{medid:int}")]
        public ActionResult<List<AtendimentoPoco>> GetByMedico(int medid)
        {
            try
            {
                List<AtendimentoPoco> listaPoco = this.servico.Consultar(med => med.CodigoPaciente == medid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros da tabela Atendimento buscando por Convenio
        /// </summary>
        /// <param name="ateid"></param>
        /// <returns></returns>
        [HttpGet("PorConvenio/{ateid:int}")]
        public ActionResult<List<AtendimentoPoco>> GetByConvenio(int ateid)
        {
            try
            {
                List<AtendimentoPoco> listaPoco = this.servico.Consultar(ate => ate.CodigoTipoAtendimento == ateid).ToList();
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
        public ActionResult<AtendimentoPoco> GetById(int chave)
        {
            try
            {
                AtendimentoPoco poco = this.servico.PesquisarPelaChave(chave);
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
        public ActionResult<AtendimentoPoco> Post([FromBody] AtendimentoPoco poco)
        {
            try
            {
                AtendimentoPoco novaPoco = this.servico.Inserir(poco);
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
        public ActionResult<AtendimentoPoco> Put([FromBody] AtendimentoPoco poco)
        {
            try
            {
                AtendimentoPoco alteradaPoco = this.servico.Alterar(poco);
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
        public ActionResult<AtendimentoPoco> Delete(int chave)
        {
            try
            {
                AtendimentoPoco delPoco = this.servico.Excluir(chave);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}