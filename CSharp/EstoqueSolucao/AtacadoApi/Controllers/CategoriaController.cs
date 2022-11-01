using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Estoque;
using Atacado.Servico.Estoque;


namespace AtacadoApi.Controllers
{
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private CategoriaServico servico;

        public CategoriaController() : base()
        {
            this.servico = new CategoriaServico();
        }

        [HttpGet]
        public List<CategoriaPoco> Obter()
        {
            return this.servico.Browse();
        }

        [HttpGet("{codigo:int}")]
        public CategoriaPoco ObterPorId(int codigo)
        {
            return this.servico.Read(codigo);
        }

        [HttpPost]
        public CategoriaPoco Adicionar([FromBody] CategoriaPoco poco)
        {
            return this.servico.Add(poco);
        }

        [HttpPut]
        public CategoriaPoco Atualizar([FromBody] CategoriaPoco poco)
        {
            return this.servico.Edit(poco);
        }


        [HttpDelete("{codigo:int}")]
        public CategoriaPoco ExcluirPorId(int codigo)
        {
            return this.servico.Delete(codigo);
        }

        [HttpDelete]
        public CategoriaPoco ExcluirPorInstancia([FromBody] CategoriaPoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}
