function alterar(){
    var codigoProfissao = $("#txtCodigoProfissao").val();
    var descricao = $("#txtDescricao").val();
    var dataInclusao = $("#txtDataInclusao").val();
    var ativo = $("#chbAtivo").prop('checked');
    
    var novo = {
        codigoProfissao,
        descricao,
        dataInclusao,
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
            codigoProfissao = data.codigoProfissao;
            alert("Dados alterados com sucesso. [codigoCandidato = " + codigoProfissao + "]");
            window.location.href = "list.html"
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao altera os dados. " + status);
            return;
        }
    });
}
