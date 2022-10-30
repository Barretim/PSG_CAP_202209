using Atacado.Dominio.FrotaAtacado;
using Atacado.Poco.FrotaPoco;
using Atacado.Repositorio.RepFrota;
using Atacado.Servico.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


namespace Atacado.Servico.ServicoFrota
{
    public class FrotaServico : BaseServico<FrotaPoco, Frota>
    {
        private FrotaRepositorio repo;

        public FrotaServico() : base()
        {
            this.repo = new FrotaRepositorio();
        }

        public override FrotaPoco Add(FrotaPoco poco)
        {
            Frota nova = this.ConvertTo(poco);
            Frota criada = this.repo.Create(nova);
            FrotaPoco criadaPoco = this.ConvertTo(criada);
            return criadaPoco;
        }

        public override List<FrotaPoco> Browse()
        {
            List<FrotaPoco> listaPoco = this.repo.Read()
                .Select(frot =>
                    new FrotaPoco()
                    {
                        Codigo = frot.Codigo,
                        Ativo = frot.Ativo,
                        DataInclusao = frot.DataInclusao,
                        Finalidade = frot.Finalidade,
                        Veiculos = frot.Veiculos,
                    }
                 )
                .ToList();
            return listaPoco;
        }

        public override FrotaPoco ConvertTo(Frota dominio)
        {
            return new FrotaPoco()
            {
                Codigo = dominio.Codigo,
                Ativo = dominio.Ativo,
                DataInclusao = dominio.DataInclusao,
                Finalidade = dominio.Finalidade,
                Veiculos = dominio.Veiculos,
            };
        }

        public override Frota ConvertTo(FrotaPoco poco)
        {
            return new Frota(poco.Codigo, poco.Ativo, poco.DataInclusao, poco.Finalidade, poco.Veiculos);
        }

        public override FrotaPoco Delete(int chave)
        {
            Frota del = this.repo.Delete(chave);
            FrotaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override FrotaPoco Delete(FrotaPoco poco)
        {
            Frota del = this.repo.Delete(ConvertTo(poco));
            FrotaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override FrotaPoco Edit(FrotaPoco poco)
        {
            Frota editada = this.ConvertTo(poco);
            Frota alterada = this.repo.Update(editada);
            FrotaPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override FrotaPoco Read(int chave)
        {
            Frota lida = this.repo.Read(chave);
            FrotaPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
