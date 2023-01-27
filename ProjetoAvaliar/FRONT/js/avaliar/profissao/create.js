console.log(caminho);

function cadastrar(){
    var codigoProfissao = 0;
    var descricao = $("#txtDescricao").val();;
    var situacao = null;
    var dataInclusao = null;

    var novo = {
        codigoCandidato,
        descricao,
        situacao,
        dataInclusao,
    };

    $.ajax({
        url : caminho,
        type: "post",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(novo),
        success: function(data, status, xhr){
            console.log(data)
            codigoProfissao = data.codigoProfissao;
            alert("Dados gravados com sucesso! Codigo:" + codigoProfissao);
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao gravar os dados!" + status);
            return;
        }
    })
}