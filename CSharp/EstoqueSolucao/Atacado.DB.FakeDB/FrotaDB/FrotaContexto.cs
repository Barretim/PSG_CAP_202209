using Atacado.DB.FakeDB.Estoque;
using Atacado.Dominio.Estoque;
using Atacado.Dominio.FrotaAtacado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.FrotaDB
{
    public class FrotaContexto
    {
        public List<Caminhao> Caminhoes
        {
            get => CaminhaoFakeDB.Caminhoes;
        }

        public List<Carro> Carros
        {
            get => CarroFakeDB.Carros;
        }

        public List<EventoFrota> EventoFrotas
        {
            get => EventoFrotaFakeDB.EventoFrotas;
        }
        public List<Frota> Frotas
        {
            get => FrotaFakeDB.Frotas;
        }
        public List<Motocicleta> Motocicletas
        {
            get => MotocicletaFakeDB.Motocicletas;
        }
        public List<Utilitario> Utilitarios
        {
            get => UtilitarioFakeDB.Utilitarios;
        }

        public FrotaContexto()
        {
        }

        public Caminhao AddCaminhao(Caminhao instancia)
        {
            int novaChave = this.Caminhoes.Count + 1;
            instancia.Codigo = novaChave;
            this.Caminhoes.Add(instancia);
            return instancia;
        }

        public Carro AddCarro(Carro instancia)
        {
            int novaChave = this.Carros.Count + 1;
            instancia.Codigo = novaChave;
            this.Carros.Add(instancia);
            return instancia;
        }

        public EventoFrota AddEventoFrota(EventoFrota instancia)
        {
            int novaChave = this.EventoFrotas.Count + 1;
            instancia.Codigo = novaChave;
            this.EventoFrotas.Add(instancia);
            return instancia;
        }

        public Frota AddFrota(Frota instancia)
        {
            int novaChave = this.Frotas.Count + 1;
            instancia.Codigo = novaChave;
            this.Frotas.Add(instancia);
            return instancia;
        }
        public Motocicleta AddMotocicleta(Motocicleta instancia)
        {
            int novaChave = this.Motocicletas.Count + 1;
            instancia.Codigo = novaChave;
            this.Motocicletas.Add(instancia);
            return instancia;
        }
        public Utilitario AddUtilitario(Utilitario instancia)
        {
            int novaChave = this.Utilitarios.Count + 1;
            instancia.Codigo = novaChave;
            this.Utilitarios.Add(instancia);
            return instancia;
        }
    }
}
