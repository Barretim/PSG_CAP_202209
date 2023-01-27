function cadastrar(){
    var codigoProfissao = 0;
    var descricao = $("#txtDescricao").val();    
    var ativo = null;
    var dataInclusao = null;    

    var novo = {
        codigoProfissao,
        descricao,    
        ativo,
        dataInclusao
    };
    console.log(novo);
    $.ajax({        
        url: caminho,
        type: "post",
        dataType: "json",
        data: JSON.stringify(novo),
        contentType: "application/json",
        success: function(data, status, xhr){
            console.log(data);
            codigoProfissao = data.codigoProfissao;
            alert("Dados gravados com sucesso. [CodigoProfissao = " + codigoProfissao + "]");
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao gravar os dados. " + status);
            return;
        }
    });
}