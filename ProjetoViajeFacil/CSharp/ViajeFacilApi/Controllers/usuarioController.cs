using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service;

namespace ViajeFacilApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuarioController : ControllerBase
    {

        public usuarioservice servico;

        public usuarioController(ViajeFacilContexto context) : base()
        {
            this.servico = new usuarioservice(context);
        }

        [HttpGet]
        public ActionResult<List<usuariopoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<usuariopoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorEndereco/{endid:long}")]
        public ActionResult<List<usuariopoco>> GetByEndereco(long endid)
        {
            try
            {
                List<usuariopoco> listaPoco = this.servico.Consultar(end => end.codigoendereco == endid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorTipoUsuario/{usuid:long}")]
        public ActionResult<List<usuariopoco>> GetByTipoUsuario(long usuid)
        {
            try
            {
                List<usuariopoco> listaPoco = this.servico.Consultar(usu => usu.codigotipousuario == usuid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("PorInstituicao/{insid:long}")]
        public ActionResult<List<usuariopoco>> GetByInstituicao(long insid)
        {
            try
            {
                List<usuariopoco> listaPoco = this.servico.Consultar(isn => isn.codigoinstituicao    == insid).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{chave:long}")]
        public ActionResult<usuariopoco> GetById(long chave)
        {
            try
            {
                usuariopoco poco = this.servico.PesquisarPelaChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult<usuariopoco> Post([FromBody] usuariopoco poco)
        {
            try
            {
                usuariopoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public ActionResult<usuariopoco> Put([FromBody] usuariopoco poco)
        {
            try
            {
                usuariopoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{chave:long}")]
        public ActionResult<usuariopoco> DeleteById(long chave)
        {
            try
            {
                usuariopoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
