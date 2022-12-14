using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViajeFacil.DB.EF;
using ViajeFacil.Poco;

namespace ViajeFacil.Service
{
    public class usuarioservice : GenericService<usuario, usuariopoco>
    {
        public usuarioservice(ViajeFacilContexto context) : base(context)
        { }

        public override List<usuariopoco> Consultar(Expression<Func<usuario, bool>>? predicate = null)
        {
            IQueryable<usuario> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            return this.ConverterPara(query);
        }

        public override List<usuariopoco> Listar(int? take, int? skip = null)
        {
            IQueryable<usuario> query;
            if (skip == null)
            {
                query = this.genrepo.GetAll();
            }
            else
            {
                query = this.genrepo.GetAll(take, skip);
            }
            return this.ConverterPara(query);
        }

        public override List<usuariopoco> ConverterPara(IQueryable<usuario> query)
        {
            return query.Select(usu => new usuariopoco
            {
                codigousuario = usu.codigousuario,
                nome = usu.nome,
                email = usu.email,
                cpf = usu.cpf,
                telefone = usu.telefone,
                login = usu.login,
                senha = usu.senha,
                codigoendereco = usu.codigoendereco,
                codigotipousuario = usu.codigotipousuario,
                codigoinstituicao = usu.codigoinstituicao
            }).ToList();
        }
    }
}
