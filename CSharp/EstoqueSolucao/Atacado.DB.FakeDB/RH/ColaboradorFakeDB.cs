using Atacado.Dominio.RH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.RH
{
    public static class ColaboradorFakeDB
    {
        private static List<Colaborador> colaboradores;

        public static List<Colaborador> Colaborador
        {
            get
            {
                if (colaboradores == null)
                {
                    colaboradores = new List<Colaborador>();
                    Carregar();
                }
                return colaboradores;
            }
        }

        private static void Carregar()
        {
            colaboradores.Add(new Colaborador(1, "Marcelo", "467.952.410-33", "291215294", "Masculino", new DateTime(1977, 10, 21), "Marcelo@gmail.com", "284.61043.96-5", "120.2433.664-9", "062613020124", true, "Casado", 2, true, "Financeiro", "Contador", 5.000, "(68) 3878-8462", "(89) 3653-7755"));
            colaboradores.Add(new Colaborador(1, "Jose", "843.462.290-42", "112699467", "Masculino", new DateTime(1980, 9, 1), "Jose@gmail.com", "978.28889.97-0", "120.0396.768-2", "220230630132", true, "Casado", 5, true, "Estoque", "Carregador", 2.000, "(68) 3878-8462", "(89) 3653-7755"));
            colaboradores.Add(new Colaborador(1, "Paula", "131.052.460-29", "328133127", "Feminino", new DateTime(2002, 3, 28), "Paula@gmil.com", "806.34011.16-9", "120.4671.782-3", "400581010191", false, "Casado", 2, true, "Financeiro", "Contador", 5.000, "(68) 3878-8462", "(89) 3653-7755"));
            colaboradores.Add(new Colaborador(1, "Vitoria", "278.342.860-13", "298664951", "Feminino", new DateTime(2000, 5, 15), "Vitoria@gmil.com", "989.80174.03-1", "120.0733.385-8", "078110620191", false, "Casado", 2, true, "Financeiro", "Contador", 5.000, "(68) 3878-8462", "(89) 3653-7755"));
            colaboradores.Add(new Colaborador(1, "Roberto", "065.887.430-68", "412368110", "Masculino", new DateTime(2001, 12, 17), "Roberto@gmil.com", "703.41226.74-7", "120.6382.621-0", "046440500108", true, "Casado", 2, true, "Financeiro", "Contador", 5.000, "(68) 3878-8462", "(89) 3653-7755"));
        }
    }
}

