using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Servico.Base;
using Atacado.Dominio.FrotaAtacado;
using Atacado.Poco.FrotaAtacado;
using Atacado.Repositorio.FrotaAtacado;

namespace Atacado.Servico.ServicoFrota
{
    public class UtilitarioServico : BaseServico<UtilitarioPoco, Utilitario>
    {
        private UtilitarioRepositorio repo;

        public UtilitarioServico() : base()
        {
            this.repo = new UtilitarioRepositorio();
        }

        public override UtilitarioPoco Add(UtilitarioPoco poco)
        {
            Utilitario nova = this.ConvertTo(poco);
            Utilitario criada = this.repo.Create(nova);
            UtilitarioPoco criadaPoco = this.ConvertTo(criada);
            return criadaPoco;
        }

        public override List<UtilitarioPoco> Browse()
        {
            List<UtilitarioPoco> listaPoco = this.repo.Read()
                .Select(uti =>
                    new UtilitarioPoco()
                    {
                        Codigo = uti.Codigo,
                        Ativo = uti.Ativo,
                        DataInclusao = uti.DataInclusao,
                        Chassi = uti.Chassi,
                        Cor = uti.Cor,
                        Marca = uti.Marca,
                        Modelo = uti.Modelo,
                        Placa = uti.Placa,
                        PesoBruto = uti.PesoBruto,
                        PesoLiquido = uti.PesoLiquido,
                        PesoTotal = uti.PesoTotal,
                    }
                 )
                .ToList();
            return listaPoco;
        }

        public override UtilitarioPoco ConvertTo(Utilitario dominio)
        {
            return new UtilitarioPoco()
            {
                Codigo = dominio.Codigo,
                Ativo = dominio.Ativo,
                DataInclusao = dominio.DataInclusao,
                Chassi = dominio.Chassi,
                Cor = dominio.Cor,
                Marca = dominio.Marca,
                Modelo = dominio.Modelo,
                Placa = dominio.Placa,
                PesoBruto = dominio.PesoBruto,
                PesoLiquido = dominio.PesoLiquido,
                PesoTotal = dominio.PesoTotal
            };
        }

        public override Utilitario ConvertTo(UtilitarioPoco poco)
        {
            return new Utilitario(poco.Codigo, poco.Ativo, poco.DataInclusao, poco.Chassi, poco.Cor, poco.Marca,
                poco.Modelo, poco.Placa, poco.PesoBruto, poco.PesoLiquido, poco.PesoTotal);
        }

        public override UtilitarioPoco Delete(int chave)
        {
            Utilitario del = this.repo.Delete(chave);
            UtilitarioPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override UtilitarioPoco Delete(UtilitarioPoco poco)
        {
            Utilitario del = this.repo.Delete(ConvertTo(poco));
            UtilitarioPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override UtilitarioPoco Edit(UtilitarioPoco poco)
        {
            Utilitario editada = this.ConvertTo(poco);
            Utilitario alterada = this.repo.Update(editada);
            UtilitarioPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override UtilitarioPoco Read(int chave)
        {
            Utilitario lida = this.repo.Read(chave);
            UtilitarioPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
