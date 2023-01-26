using Avaliar.Poco;
using System;
using System.Collections.Generic;
using Avaliar.Envelope.Modelo;

namespace Avaliar.Envelope.Modelo
{
    public class ProfissaoEnvelope : BaseEnvelope
    {
        public int CodigoProfissao { get; set; }
        public string Descricao { get; set; } = null!;
        public DateTime? DataInclusao { get; set; }
        public bool? Situacao { get; set; }

        public ProfissaoEnvelope(ProfissaoPoco poco)
        {
            CodigoProfissao = poco.CodigoProfissao;
            Descricao = poco.Descricao;
            DataInclusao = poco.DataInclusao;
            Situacao = poco.Situacao;
        }

        public override void SetLinks()
        {
            Links.List = "GET /cidade";
            Links.Self = "GET /cidade/" + CodigoProfissao.ToString();
            Links.Exclude = "DELETE /cidade/" + CodigoProfissao.ToString();
            Links.Update = "PUT /cidade";
        }
    }
}