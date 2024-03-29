﻿using Clinica.Dominio.EF;
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
    public class AgendaController : ControllerBase
    {

        /// <summary>
        ///
        /// </summary>
        public AgendaServico servico;

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        public AgendaController(ClinicaContext context) : base()
        {
            this.servico = new AgendaServico(context);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<AgendaPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<AgendaPoco> listaPoco = this.servico.Listar(take, skip);
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
        /// <param name="pacid"></param>
        /// <returns></returns>
        [HttpGet("PorPaciente/{pacid:int}")]
        public ActionResult<List<AgendaPoco>> GetByPaciente(int pacid)
        {
            try
            {
                List<AgendaPoco> listaPoco = this.servico.Consultar(pac => pac.CodigoPaciente == pacid).ToList();
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
        /// <param name="conid"></param>
        /// <param name="ano"></param>
        /// <returns></returns>
        [HttpGet("PorConsulta/{conid:int}/PorAno/{ano:int}")]
        public ActionResult<List<AgendaPoco>> GetByConsultaByAno(int conid, int ano)
        {
            try
            {
                List<AgendaPoco> listaPoco = this.servico.Consultar(get => (get.CodigoConsulta == conid) && (get.Ano == ano)).ToList();
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
        public ActionResult<AgendaPoco> GetById(int chave)
        {
            try
            {
                AgendaPoco poco = this.servico.PesquisarPelaChave(chave);
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
        public ActionResult<AgendaPoco> Post([FromBody] AgendaPoco poco)
        {
            try
            {
                AgendaPoco novoPoco = this.servico.Inserir(poco);
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
        public ActionResult<AgendaPoco> Put([FromBody] AgendaPoco poco)
        {
            try
            {
                AgendaPoco novoPoco = this.servico.Alterar(poco);
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
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<AgendaPoco> DeleteById(int chave)
        {
            try
            {
                AgendaPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
