var codigo = 0;

$(function(){
    avaliarAcao('candidatoAcao');
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
        $("#txtCodigoCandidato").attr('readonly',true);
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
        $("#txtCodigoCandidato").attr('readonly',true);
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
    $("#txtCodigoCandidato").attr('readonly',true);
    $("#txtCodigoProfissao").attr('readonly',true);
    $("#txtNome").attr('readonly',true);
    $("#txtSobrenome").attr('readonly',true);
    $("#txtEmail").attr('readonly',true);
    $("#txtAtivo").attr('readonly',true);
    $("#txtDataInclusao").attr('readonly', true);
}

function carregarDetalhe(){
    var tmp = localStorage.getItem("codigoCandidatoSelecionado");
    codigo = JSON.parse(tmp)

    if ((codigo == undefined) || (codigo == 0)){
        alert("código inválido!!");
        window.location.href = "list.html";
    }
    else{
        localStorage.removeItem("codigoCandidatoSelecionado");
    }
    
    var caminhoComValor = caminho + '/' + codigo;

    $.get(caminhoComValor, function(data, status){
        if (data.length == 0){
            alert("Erro ao obter os dados.")
            return;
        }
        else{
            console.log(data);
            $("#txtCodigoCandidato").val(data.codigoPessoa);
            $("#txtCodigoProfissao").val(data.codigoPessoa);
            $("#txtNome").val(data.nome)
            $("#txtSobrenome").val(data.sobrenome);
            $("#txtEmail").val(data.email);
            $("#txtAtivo").val(data.ativo);
            $("#txtDataInclusao").val(data.dataInclusao.substring(0,10));
            $("#chbAtivo").attr('checked', (stringToBoolean(data.ativo)));
        }
    });
}

function stringToBoolean(value){
    return (String(value) === '1' || String(value).toLowerCase() === 'true');
}