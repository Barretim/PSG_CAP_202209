using Atacado.Dominio.FrotaAtacado;
using Atacado.Poco.FrotaPoco;
using Atacado.Repositorio.RepFrota;
using Atacado.Servico.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Servico.ServicoFrota
{
    public class CarroServico : BaseServico<CarroPoco, Carro>
    {
        private CarroRepositorio repo;

        public CarroServico() : base()
        {
            this.repo = new CarroRepositorio();
        }

        public override CarroPoco Add(CarroPoco poco)
        {
            Carro nova = this.ConvertTo(poco);
            Carro criada = this.repo.Create(nova);
            CarroPoco criadaPoco = this.ConvertTo(criada);
            return criadaPoco;

        }

        public override List<CarroPoco> Browse()
        {
            List<CarroPoco> listaPoco = this.repo.Read()
            .Select(cat => new CarroPoco()
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

        public override CarroPoco ConvertTo(Carro dominio)
        {
            return new CarroPoco()
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

        public override Carro ConvertTo(CarroPoco poco)
        {
            return new Carro(poco.Codigo, poco.Ativo, poco.DataInclusao, poco.Chassi,
                poco.Cor, poco.Marca, poco.Modelo, poco.Placa, poco.PesoBruto, poco.PesoLiquido, poco.PesoTotal);
        }

        public override CarroPoco Delete(int chave)
        {
            Carro del = this.repo.Delete(chave);
            CarroPoco delPoco = this.ConvertTo(del);
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
