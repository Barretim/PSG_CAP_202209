console.log(caminho);

function cadastrar(){
    var codigoCandidato = 0;
    var codigoProfissao = $("#txtCodigoProfissao").val();;
    var nome = $("#txtNome").val();
    var sobrenome = $("#txtSobrenome").val();
    var email = $("#txtEmail").val();
    var situacao = null;
    var dataInclusao = null;

    var novo = {
        codigoCandidato,
        codigoProfissao,
        nome,
        sobrenome,
        email,
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
            codigoCandidato = data.codigoCandidato;
            alert("Dados gravados com sucesso! Codigo:" + codigoCandidato);
            window.location.href = "list.html";
        },
        error: function(xhr, status, errorThrown){
            alert("Erro ao gravar os dados!" + status);
            return;
        }
    })
}