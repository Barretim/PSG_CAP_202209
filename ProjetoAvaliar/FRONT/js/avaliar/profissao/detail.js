var codigo = 0;

$(function(){
    avaliarAcao('profissaoAcao');
    if (acao == 0){
        carregarDetalhe();
        somenteLeitura();
        $("#btnNovo").hide();
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
        $("#Data").hide();
        $("#Texto").hide();
        $("#divAtivoInclusao").hide();
        $("#chbAtivo").attr('disabled', true);
    }

    if (acao == 1){
        $("#txtCodigoProfissao").attr('readonly',true);
        $("#txtAtivo").attr('readonly',true);
        $("#txtDataInclusao").attr('readonly', true); 
        $("#btnAlterar").hide();
        $("#btnExcluir").hide();
        $("#Texto").hide();
        $("#divAtivoInclusao").hide();
        $("#chbAtivo").attr('checked', true);
        $("#chbAtivo").attr('disabled', true);
    }

    if (acao == 2){
        carregarDetalhe();
        $("#txtCodigoProfissao").attr('readonly',true);
        $("#txtDataInclusao").attr('readonly', true);  
        $("#btnNovo").hide();
        $("#btnExcluir").hide();
        $("#Texto").hide();
        $("#divAtivoInclusao").hide();
        $("#DatDataContratacao").attr('readonly', true);  
    }

    if (acao == 3){
       carregarDetalhe();
       somenteLeitura();
       $("#btnNovo").hide();
       $("#btnAlterar").hide();
       $("#Data").hide();
       $("#divAtivoInclusao").hide();
       $("#chbAtivo").attr('disabled', true);
    }
});

function somenteLeitura(){
    $("#txtCodigoProfissao").attr('readonly',true);
    $("#txtDescricao").attr('readonly',true);
    $("#txtAtivo").attr('readonly',true);
    $("#txtDataInclusao").attr('readonly', true);
}

function carregarDetalhe(){
    var tmp = localStorage.getItem("codigoProfissaoSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoProfissaoSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;

    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoProfissao").val(data.codigoProfissao);
            $("#txtDescricao").val(data.descricao);
            $("#txtAtivo").val(data.ativo);
            $("#txtDataInclusao").val(data.dataInclusao.substring(0,10));
            $("#chbAtivo").attr('checked', (stringToBoolean(data.ativo)));
        }
    });
}

function stringToBoolean(value){
    return (String(value) === '1' || String(value).toLowerCase() === 'true');
}