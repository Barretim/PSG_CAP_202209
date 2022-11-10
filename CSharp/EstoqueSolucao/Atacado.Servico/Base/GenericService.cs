using Atacado.DB.EF.Database;
using Atacado.Poco.Estoque;
using Atacado.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Servico.Base
{
    public class GenericService<TDominio, TPoco> :
        IGenericService<TDominio, TPoco>
        where TPoco : class
        where TDominio : class
    {
        protected GenericRepository<TDominio> genrepo;

        public GenericService()
        {
            this.genrepo = new GenericRepository<TDominio>();
        }

        public List<TPoco> Listar()
        {
            return this.Consultar(null);
        }

        public virtual List<TPoco> Listar(int? take = null, int? skip = null)
        {
            throw new NotImplementedException();
        }

        public virtual List<TPoco> Consultar(Expression<Func<TDominio, bool>>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public TPoco? PesquisaPelaChave(object chave)
        {
            TDominio? lida = this.genrepo.GetById(chave);
            TPoco? lidaPoco = null;
            if (lida != null)
            {
                lidaPoco = this.ConverterPara(lida);
            }
            return lidaPoco;

        }
        
        public TPoco? Inserir(TPoco obj)
        {
            TDominio? nova = this.ConverterPara(obj);
            TDominio? criada = this.genrepo.Insert(nova);
            TPoco? criadaPoco = null;
            if (criada != null)
            {
                criadaPoco = this.ConverterPara(criada);
            }
            return criadaPoco;
        }

        public TPoco? Alterar(TPoco obj)
        {
            TDominio? editada = this.ConverterPara(obj);
            TDominio? alterada = this.genrepo.Update(editada);
            TPoco? alteradaPoco = null;
            if (alterada != null)
            {
                alteradaPoco = this.ConverterPara(alterada);
            }
            return alteradaPoco;
        }
        public TPoco? Excluir(object chave)
        {
            TDominio? del = this.genrepo.Delete(chave);
            TPoco? delPoco = null;
            if(del != null)
            {
                this.ConverterPara(del);
            }
            return delPoco;
        }

        public virtual TDominio ConverterPara(TPoco obj)
        {
            throw new NotImplementedException();
        }

        public virtual TPoco ConverterPara(TDominio obj)
        {
            throw new NotImplementedException();
        }

        public virtual List<ProdutoPoco> ConverterPara(IQueryable<Produto> query)
        {
            throw new NotImplementedException();
        }
    }
}
