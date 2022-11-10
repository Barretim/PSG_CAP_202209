using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Servico.Base;
using Atacado.DB.EF.Database;
using Atacado.Poco.Estoque;
using Atacado.Repositorio.Base;
using System.ComponentModel;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Atacado.Servico.Estoque
{
    public class CategoriaServico : GenericService<Categoria ,CategoriaPoco>
    {
        public override CategoriaPoco ConverterPara(Categoria obj)
        {
            return new CategoriaPoco()
            {
                Codigo = obj.Codigo,
                Descricao = obj.Descricao,
                Ativo = obj.Ativo,
                DataInsert = obj.DataInsert
            };
        }

        public override Categoria ConverterPara(CategoriaPoco obj)
        {
            return new Categoria()
            {
                Codigo = obj.Codigo,
                Descricao = obj.Descricao,
                Ativo = obj.Ativo,
                DataInsert = obj.DataInsert
            };
        }

        public override List<CategoriaPoco> Consultar(Expression<Func<Categoria, bool>> predicate = null)
        {
            IQueryable<Categoria> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            List<CategoriaPoco> listaPoco = query.Select(cat => new CategoriaPoco()
            {
                Codigo = cat.Codigo,
                Descricao = cat.Descricao,
                Ativo = cat.Ativo,
                DataInsert = cat.DataInsert
            }
            ).ToList();
            return listaPoco;
        }
    }
}
