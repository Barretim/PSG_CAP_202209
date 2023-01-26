function excluir(){
    var codigoCandidato = $("#txtCodigoCandidato").val();

    var caminhoComValor = caminho + '/' + codigo;

    $.ajax({
        url: caminhoComValor,
        type: "delete",
        dataType: "json",
        contentType: "application/json",
        data: null,
        success: function(data, status, xhr){
            console.log(data);
            codigoCandidato = data.codigoCandidato;
            alert("Dados excluídos com sucesso. [CodigoCandidato = " + codigoCandidato + "]");
            window.location.href = "list.html"
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao excluir os dados. " + status);
            return;
        }
    });
}