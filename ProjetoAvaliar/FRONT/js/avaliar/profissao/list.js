var caminhoEnvelope = '';
$(function(){
  $("#ddlTakeSkip").change(function(){
    var limite = $(this).children("option:selected").val();
    var salto = 0;
    if (limite != 0){
        caminhoEnvelope = caminho + "/envelope/" + "?limite=" + limite + "&salto=" + salto;
        carregar(caminhoEnvelope);
    }
    else{
        caminhoEnvelope = caminho + "/envelope" + "?limite=" + 5 + "&salto=" + salto;
        carregar(caminhoEnvelope);
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
          const profissao = data.dados[index];

          console.log(profissao);

            var codigoProfissao = profissao.codigoProfissao;
            var descricao = profissao.descricao;
            var hasPrev = data.paginacao.hasPrev;
            var hasNext = data.paginacao.hasNext;
            var pageNumber = data.paginacao.pageNumber;   

            var linha = '';
            linha += "<tr>";
            linha +=  "<td class='table-active text-center'>";
            linha +=    "<button id='btnExibir' class='border-light border-0' onclick='exibirAtual("+ codigoProfissao +");'>";
            linha +=      "<img src='/img/att.png''width=35 height=35'>";
            linha +=    "</button>";
            linha +=  "</td>";
            linha += "<td class='table-active text-center'>" + codigoProfissao + "</td>";
            linha += "<td class='table-active text-center'>" + descricao + "</td>";
            linha += "<td class='table-active text-center'>";
            linha +=    "<button id='btnAlterar' class='btn-warning' onclick='alterarAtual("+ codigoProfissao +");'>Alterar</button>";
            linha +=    "</td>";
            linha += "<td class='table-active text-center'>";
            linha +=    "<button id='btnExcluir' class='btn-danger' onclick='excluirAtual("+ codigoProfissao +");'>Excluir</button>";
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
  localStorage.setItem("profissaoAcao",JSON.stringify(0));
  localStorage.setItem("codigoProfissaoSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function cadastrarNovo(){
  localStorage.setItem("profissaoAcao",JSON.stringify(1));
  window.location.href = "detail.html";
}


function alterarAtual(codigo){
  localStorage.setItem("profissaoAcao",JSON.stringify(2));
  localStorage.setItem("codigoProfissaoSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
}

function excluirAtual(codigo){
  localStorage.setItem("profissaoAcao",JSON.stringify(3));
  localStorage.setItem("codigoProfissaoSelecionado",JSON.stringify(codigo));
  window.location.href = "detail.html";
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