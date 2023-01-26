using Avaliar.Poco;
using System;
using System.Collections.Generic;
using Avaliar.Envelope.Modelo;

namespace Avaliar.Envelope.Modelo
{
    public class CandidatoEnvelope : BaseEnvelope
    {
        public int CodigoCandidato { get; set; }
        public int CodigoProfissao { get; set; }
        public string Nome { get; set; } = null!;
        public string Sobrenome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? Situacao { get; set; }
        public DateTime? DataInclusao { get; set; }

        public CandidatoEnvelope(CandidatoPoco poco)
        {
            CodigoCandidato = poco.CodigoCandidato;
            CodigoProfissao = poco.CodigoProfissao;
            Nome = poco.Nome;
            Sobrenome = poco.Sobrenome;
            Email = poco.Email;
            Situacao = poco.Situacao;
            DataInclusao = poco.DataInclusao;
        }

        public override void SetLinks()
        {
            Links.List = "GET /cidade";
            Links.Self = "GET /cidade/" + CodigoCandidato.ToString();
            Links.Exclude = "DELETE /cidade/" + CodigoCandidato.ToString();
            Links.Update = "PUT /cidade";
        }
    }
}