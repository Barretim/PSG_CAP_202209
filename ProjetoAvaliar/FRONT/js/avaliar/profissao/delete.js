function excluir(){
    var codigoProfissao = $("#txtCodigoProfissao").val();

    var caminhoComValor = caminho + '/' + codigo;

    $.ajax({
        url: caminhoComValor,
        type: "delete",
        dataType: "json",
        contentType: "application/json",
        data: null,
        success: function(data, status, xhr){
            console.log(data);
            codigoProfissao = data.codigoProfissao;
            alert("Dados excluídos com sucesso. [CodigoCandidato = " + codigoProfissao + "]");
            window.location.href = "list.html"
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao excluir os dados. " + status);
            return;
        }
    });
}