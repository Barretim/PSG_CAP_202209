using Atacado.Servico.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Estoque;
using Atacado.Servico.Estoque;

namespace AtacadoApi.Controllers
{
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private ProdutoServico servico;

        public ProdutoController() : base()
        {
            this.servico = new ProdutoServico();
        }

        [HttpGet]
        public List<ProdutoPoco> Obter()
        {
            return this.servico.Browse();
        }

        [HttpGet("{codigo:int}")]
        public ProdutoPoco ObterPorId(int codigo)
        {
            return this.servico.Read(codigo);
        }

        [HttpPost]
        public ProdutoPoco Adicionar([FromBody] ProdutoPoco poco)
        {
            return this.servico.Add(poco);
        }

        [HttpPut]
        public ProdutoPoco Atualizar([FromBody] ProdutoPoco poco)
        {
            return this.servico.Edit(poco);
        }


        [HttpDelete("{codigo:int}")]
        public ProdutoPoco ExcluirPorId(int codigo)
        {
            return this.servico.Delete(codigo);
        }

        [HttpDelete]
        public ProdutoPoco ExcluirPorInstancia([FromBody] ProdutoPoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}