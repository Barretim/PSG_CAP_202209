using MedVet.Domain.EF;
using MedVet.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedVet.Service
{
    public class EnderecoServico : GenericService<Endereco, EnderecoPoco>
    {
        public EnderecoServico(MedVetContext context) : base(context)
        { }

        public override List<EnderecoPoco> Consultar(Expression<Func<Endereco, bool>>? predicate = null)
        {
            IQueryable<Endereco> query;
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

        public override List<EnderecoPoco> Listar(int? take, int? skip = null)
        {
            IQueryable<Endereco> query;
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

        public override List<EnderecoPoco> ConverterPara(IQueryable<Endereco> query)
        {
            return query.Select(end => new EnderecoPoco
            {
                CodigoEndereco = end.CodigoEndereco,
                Rua = end.Rua,
                Numero = end.Numero,
                Complemento = end.Complemento,
                Bairro = end.Bairro,
                CEP = end.CEP,
                CodigoCidade = end.CodigoCidade
            }).ToList();
        }
    }
}