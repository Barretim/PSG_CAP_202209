using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clinica.Poco;
using Clinica.Servico;
using Clinica.Dominio.EF;
using Clinica.Repositorio;
using Clinica.Mapping;
using System;

namespace ClinicaApi.Controllers
{/// <summary>
/// 
/// </summary>
    [Route("api/clinica/[controller]")]
    [ApiController]
    
    public class PacienteController : ControllerBase
    {
        private PacienteServico servico;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public PacienteController(ClinicaContext context) : base()
        {
            this.servico = new PacienteServico(context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<PacientePoco>> Obter()
        {
            try
            {
                List<PacientePoco> lista = this.servico.Listar();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        [HttpGet("PorProfissao/{proid:int}")]
        public ActionResult<List<PacientePoco>> ObterCodigoProfissao(int proid)
        {
            try
            {
                List<PacientePoco> lista = this.servico.Consultar(prd => prd.CodigoProfissao == proid).ToList();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<PacientePoco> ObterPorId(int codigo)
        {
            try
            {
                PacientePoco poco = this.servico.PesquisarPelaChave(codigo);
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
        public ActionResult<PacientePoco> Adicionar([FromBody] PacientePoco poco)
        {
            try
            {
                PacientePoco lista = this.servico.Inserir(poco);
                return Ok(lista);
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
        public ActionResult<PacientePoco> Atualizar([FromBody] PacientePoco poco)
        {
            try
            {
                PacientePoco lista = this.servico.Alterar(poco);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<PacientePoco> ExcluirPorId(int codigo)
        {
            try
            {
                PacientePoco lista = this.servico.Excluir(codigo);
                return Ok(lista);
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
        [HttpDelete]
        public ActionResult<PacientePoco> ExcluirPorInstancia([FromBody] PacientePoco poco)
        {
            try
            {
                PacientePoco lista = this.servico.Excluir(poco.CodigoPaciente);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}