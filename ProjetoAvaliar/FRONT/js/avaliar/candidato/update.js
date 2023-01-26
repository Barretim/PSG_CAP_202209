function alterar(){
    var codigoCandidato = $("#txtCodigoPessoa").val();
    var codigoProfissao = $("#txtCodigoPessoa").val();
    var nome = $("#txtNome").val();
    var sobrenome = $("#txtSobrenome").val();
    var email = $("#txtEmail").val();
    var ativo = $("#chbAtivo").prop('checked');
    
    var novo = {
        codigoCandidato,
        codigoProfissao,
        nome,
        sobrenome,
        email,
        ativo
    };

    $.ajax({
        url: caminho,
        type: "put",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data);
            codigoCandidato = data.codigoCandidato;
            alert("Dados alterados com sucesso. [codigoCandidato = " + codigoCandidato + "]");
            window.location.href = "list.html"
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao altera os dados. " + status);
            return;
        }
    });
}
