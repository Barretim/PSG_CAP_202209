﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Estoque;
using Atacado.Servico.Estoque;
using Atacado.DB.EF.Database;

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
        public CategoriaController(ProjetoAcademiaContext contexto) : base()
        {
            this.servico = new CategoriaServico(contexto);
        }

        /// <summary>
        /// Listar todos os registros da tabela Categoria
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CategoriaPoco>> Obter()
        {
            try
            {
                List<CategoriaPoco> lista = this.servico.Listar();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Busca um registro de Categoria por Id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<CategoriaPoco> ObterPorId(int codigo)
        {
            try
            {
                CategoriaPoco poco = this.servico.PesquisaPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            } 
        }

        /// <summary>
        /// Registra um novo registro e um novo Id em Categoria
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<CategoriaPoco> Adicionar([FromBody] CategoriaPoco poco)
        {
            try
            {
                CategoriaPoco lista = this.servico.Inserir(poco);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Atualiza um registro em Categoria
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<CategoriaPoco> Atualizar([FromBody] CategoriaPoco poco)
        {
            try
            {
                CategoriaPoco lista = this.servico.Alterar(poco);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro pelo código
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<CategoriaPoco> ExcluirPorId(int codigo)
        {
            try
            {
                CategoriaPoco lista = this.servico.Excluir(codigo);
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
        public ActionResult<CategoriaPoco> ExcluirPorInstancia([FromBody] CategoriaPoco poco)
        {
            try
            {
                CategoriaPoco lista = this.servico.Excluir(poco.Codigo);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
