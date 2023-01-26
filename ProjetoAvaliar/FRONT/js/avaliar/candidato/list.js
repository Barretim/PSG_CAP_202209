var caminhoEnvelope = '';
$(function(){
  carregarPessoa();
  $("#ddlProfissao").change(function(){
      var codigoProfissao = $(this).children("option:selected").val();
      var limite = $("#ddlTakeSkip").children("option:selected").val();
      var salto = 0;
      if (limite != 0){
        caminhoEnvelope = caminho + "/envelope/PorProfissao/" + codigoProfissao + "?limite=" + limite + "&salto=" + salto;
        carregar(caminhoEnvelope);
      }
      else{
        limite = 100;
        caminhoEnvelope = caminho + "/envelope/PorProfissao/" + codigoProfissao + "?limite=" + limite + "&salto=" + salto;
        carregar(caminhoEnvelope);
      }
  });

  $("#ddlTakeSkip").change(function(){
    var limite = $(this).children("option:selected").val();
    var codigoProfissao = $("#ddlProfissao").children("option:selected").val();
    var salto = 0;
    if (codigoProfissao != 0){
      caminhoEnvelope = caminho + "/envelope/PorProfissao/" + codigoProfissao + "?limite=" + limite + "&salto=" + salto;
      carregar(caminhoEnvelope);
    }
    else{
      alert("Informe uma Profissao para pesquisa.")
    }
  });
});

function carregar(caminhoEnvelope){
    $.ajax({
      url: caminhoEnvelope,
      type: "get",
      dataType: "json",
      contentType: "application/json",
      data: null,
      async: false,
      success: function(data, status, xhr){
        var codigoStatus = data.status.codigo;
        var mensagemStatus = data.status.mensagem;
                
        if (codigoStatus == 404){
          $("#liPagina").hide();
          $("#liPosterior").hide();          
          alert(mensagemStatus);
          return;
        }

        $("#tblDados tbody").empty();

        for (let index = 0; index < data.dados.length; index++) {
          const candidato = data.dados[index];

          console.log(candidato);

            var codigoCandidato = candidato.codigoCandidato;
            var codigoProfissao = candidato.codigoProfissao;
            var nome = candidato.nome;
            var sobrenome = candidato.sobrenome;
            var email = candidato.email;
            var hasPrev = data.paginacao.hasPrev;
            var hasNext = data.paginacao.hasNext;
            var pageNumber = data.paginacao.pageNumber;   

            var linha = '';
            linha += "<tr>";
            linha +=  "<td class='table-active text-center'>";
            linha +=    "<button id='btnExibir' class='border-light border-0' onclick='exibirAtual("+ codigoCandidato +");'>";
            linha +=      "<img src='/img/att.png''width=35 height=35'>";
            linha +=    "</button>";
            linha +=  "</td>";
            linha += "<td class='table-active text-center'>" + codigoCandidato + "</td>";
            linha += "<td class='table-active text-center'>" + codigoProfissao + "</td>";
            linha += "<td class='table-active text-center'>" + nome + "</td>";
            linha += "<td class='table-active text-center'>" + sobrenome + "</td>";
            linha += "<td class='table-active text-center'>" + email + "</td>";
            linha += "<td class='table-active text-center'>";
            linha +=    "<button id='btnAlterar' class='btn-warning' onclick='alterarAtual("+ codigoCandidato +");'>Alterar</button>";
            linha +=    "</td>";
            linha += "<td class='table-active text-center'>";
            linha +=    "<button id='btnExcluir' class='btn-danger' onclick='excluirAtual("+ codigoCandidato +");'>Excluir</button>";
            linha +=    "</td>";
            linha += "</tr>"; 
            $("#tblDados tbody").append(linha);
          }
          carregarLinkPaginacao(pageNumber, hasPrev, hasNext);
        },
        error: function(xhr, status, errorThrown){
          alert("Erro ao obter os dados. " + status);
          return;
        }
      });
}

function exibirAtual(codigo){
  localStorage.setItem("candidatoAcao",JSON.stringify(0));
  localStorage.setItem("codigoCandidatoSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function cadastrarNovo(){
  localStorage.setItem("candidatoAcao",JSON.stringify(1));
  window.location.href = "detail.html";
}


function alterarAtual(codigo){
  localStorage.setItem("candidatoAcao",JSON.stringify(2));
  localStorage.setItem("codigoCandidatoSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function excluirAtual(codigo){
  localStorage.setItem("candidatoAcao",JSON.stringify(3));
  localStorage.setItem("codigoCandidatoSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

var candidatos = [];

function carregarCandidato(){
  var caminhoCandidato  = servidor + "/" + "TipoCandidato";
  $.get(caminhoCandidato, function(data){

        for (let index = 0; index < data.length; index++) {
          const candidato = data[index];

          $("#ddlProfissao").append(
            $('<option></option>').val(candidato.codigoTipoProfissao).html(candidato.descricao)
        );
        }     
  });
}

function carregarLinkPaginacao(numeroPagina, anterior, posterior){
  $("#navPaginacao ul").empty();

    var linha = '';
    linha += "<li class='page-item'>";
    linha +=  "<a class='page-link' id='liAnterior' onclick='carregar(\""+ anterior +"\")' tabindex='-1'>Anterior</a>";
    linha += "</li>";
    linha += "<li class='page-item'>";
    linha +=  "<a class='page-link' id='liPagina'> "+ numeroPagina +"</a>";
    linha += "</li>";
    linha += "<li class='page-item'>";
    linha +=  "<a class='page-link' id='liPosterior' onclick='carregar(\""+ posterior +"\")'>Próximo</a>";
    linha += "</li>";
    $("#navPaginacao ul").html(linha);

    if(numeroPagina == 1){
      $("#liAnterior").hide();
    }
}