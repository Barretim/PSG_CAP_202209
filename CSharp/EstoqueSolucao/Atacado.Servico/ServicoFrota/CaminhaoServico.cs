using Atacado.Dominio.Estoque;
using Atacado.Dominio.FrotaAtacado;
using Atacado.Poco.Estoque;
using Atacado.Poco.FrotaPoco;
using Atacado.Repositorio.Estoque;
using Atacado.Repositorio.RepFrota;
using Atacado.Servico.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Atacado.Servico.ServicoFrota
{
    public class CaminhaoServico : BaseServico<CaminhaoPoco, Caminhao>
    {
        private CaminhaoRepositorio repo;

        public CaminhaoServico() : base()
        {
            this.repo = new CaminhaoRepositorio();
        }

        public override CaminhaoPoco Add(CaminhaoPoco poco)
        {
            Caminhao nova = this.ConvertTo(poco);
            Caminhao criada = this.repo.Create(nova);
            CaminhaoPoco criadaPoco = this.ConvertTo(criada);
            return criadaPoco;

        }

        public override List<CaminhaoPoco> Browse()
        {
            List<CaminhaoPoco> listaPoco = this.repo.Read()
            .Select(cat => new CaminhaoPoco()
            {
                Codigo = cat.Codigo,
                Ativo = cat.Ativo,
                DataInclusao = cat.DataInclusao,
                Chassi = cat.Chassi,
                Cor = cat.Cor,
                Marca = cat.Marca,
                Modelo = cat.Modelo,
                Placa = cat.Placa, 
                PesoBruto = cat.PesoBruto, 
                PesoLiquido = cat.PesoLiquido,
                PesoTotal = cat.PesoTotal
            }
            )
            .ToList();
            return listaPoco;
        }

        public override CaminhaoPoco ConvertTo(Caminhao dominio)
        {
            return new CaminhaoPoco() 
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

        public override Caminhao ConvertTo(CaminhaoPoco poco)
        {
            return new Caminhao(poco.Codigo, poco.Ativo, poco.DataInclusao, poco.Chassi,
                poco.Cor, poco.Marca, poco.Modelo, poco.Placa, poco.PesoBruto, poco.PesoLiquido, poco.PesoTotal);
        }

        public override CaminhaoPoco Delete(int chave)
        {
            Caminhao del = this.repo.Delete(chave);
            CaminhaoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override CaminhaoPoco Delete(CaminhaoPoco poco)
        {
            Caminhao del = this.repo.Delete(poco.Codigo);
            CaminhaoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override CaminhaoPoco Edit(CaminhaoPoco poco)
        {
            Caminhao editada = this.ConvertTo(poco);
            Caminhao alterada = this.repo.Create(editada);
            CaminhaoPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override CaminhaoPoco Read(int chave)
        {
            Caminhao lida = this.repo.Read(chave);
            CaminhaoPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
