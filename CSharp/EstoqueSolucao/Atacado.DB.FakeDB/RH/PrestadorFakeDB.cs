using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Atacado.Dominio.RH;

namespace Atacado.DB.FakeDB.RH
{
    public static class PrestadorFakeDB
    {
        private static List<Prestador> prestadores;

        public static List<Prestador> Prestadores
        {
            get
            {
                if (prestadores == null)
                {
                    prestadores = new List<Prestador>();
                    Carregar();
                }
                return prestadores;
            }
        }

        public static void Carregar()
        {
            prestadores.Add(new Prestador());
            prestadores.Add(new Prestador(00, 2, 2)));
            prestadores.Add(new Prestador(ly(2015, 3, 3)));
            prestadores.Add(new Prestador( 5, 5)));

            prestadores.Add(new Prestador(5, "282", "183", new DateTime(2003, 9, 10), "Kabum!","KaBuM! Comércio Eletrônico S/A", "Kabum@empresa.com", new DateOnly(2001, 11, 11), new DateOnly(2023, 11, 11)));
        }
    }
}