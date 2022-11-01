using Atacado.Servico.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Estoque;
using Atacado.Servico.Estoque;

namespace AtacadoApi.Controllers
{
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class SubcategoriaController : ControllerBase
    {
        private SubcategoriaServico servico;

        public SubcategoriaController() : base()
        {
            this.servico = new SubcategoriaServico();
        }

        [HttpGet]
        public List<SubcategoriaPoco> Obter()
        {
            return this.servico.Browse();
        }

        [HttpGet("{codigo:int}")]
        public SubcategoriaPoco ObterPorId(int codigo)
        {
            return this.servico.Read(codigo);
        }

        [HttpPost]
        public SubcategoriaPoco Adicionar([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Add(poco);
        }

        [HttpPut]
        public SubcategoriaPoco Atualizar([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Edit(poco);
        }


        [HttpDelete("{codigo:int}")]
        public SubcategoriaPoco ExcluirPorId(int codigo)
        {
            return this.servico.Delete(codigo);
        }

        [HttpDelete]
        public SubcategoriaPoco ExcluirPorInstancia([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}