var urlApi = `${HelperClass.urlApi}/administracao/usuario`;


function BuscarInformacoesUsuario() {

    HelperClass.ExibirPreloader();

    var token = localStorage.getItem('token');

    if (!token) {
        var mensagem = `${jqXHR.status} - Faça login e tente novamente`;
        var timeout = 2000;
        HelperClass.MostrarToastErro(mensagem, timeout, (() => {
            window.location.href = "../index.html";
        }))
    }

    var usuario = HelperClass.ParseJwt(token);

    var settings = {
        "url": `${urlApi}/${usuario.id}`,
        "method": "GET",
        "headers": {
            "Authorization": `Bearer ${token}`
        }
    }

    $.ajax(settings).done((response) => {

        HelperClass.RemoverPreLaoder();
        console.log(response);

        $('.nome').html(response.nome);
        $('.avatar').attr('src', `https://ui-avatars.com/api/?name=${response.nome}`);
        $('#input-nome').val(response.nome);
        $('#input-email').val(response.email);
        $('#input-endereco').val(response.endereco);
        $('#input-cidade').val(response.cidade);
        $('#input-bairro').val(response.bairro);
        $('#input-estado').val(response.estado);
        $('#input-cep').val(response.cep);

    }).fail((jqXHR) => {

        if (jqXHR.status == 401) {
            debugger;
            var mensagem = `${jqXHR.status} - Faça login e tente novamente`;
            var timeout = 2000;
            HelperClass.MostrarToastErro(mensagem, timeout, (() => {
                window.location.href = "login.html";
            }))
            return;
        }

        var mensagem = `${jqXHR.status} - Erro ao buscar informações`;
        var timeout = 2000;
        HelperClass.MostrarToastErro(mensagem, timeout, (() => {
            HelperClass.RemoverPreLaoder();
        }));
    })


}

function EditarInformacoes() {

    var token = localStorage.getItem('token');

    if (!token) {
        var mensagem = `${jqXHR.status} - Faça login e tente novamente`;
        var timeout = 2000;
        HelperClass.MostrarToastErro(mensagem, timeout, (() => {
            window.location.href = "../index.html";
        }))
    }

    var usuario = HelperClass.ParseJwt(token);

    var nome = $('#input-nome').val();
    var email = $('#input-email').val();
    var endereco = $('#input-endereco').val();
    var cidade = $('#input-cidade').val();
    var bairro = $('#input-bairro').val();
    var estado = $('#input-estado').val();
    var cep = $('#input-cep').val();

    var novaSenha = $('#input-nova-senha').val();
    var confirmarSenha = $('#input-confirmar-senha').val();

    var propriedadeNovaSenha = {};

    if (novaSenha != confirmarSenha) {
        var mensagem = "As senha não conferem";
        var timeout = 2000;
        HelperClass.MostrarToastErro(mensagem, timeout);
        return;
    }

    var data = {
        "id": usuario.id,
        "nome": nome,
        "email": email,
        "endereco": endereco,
        "cidade": cidade,
        "bairro": bairro,
        "estado": estado,
        "cep": cep,
    }

    if (novaSenha) {
        propriedadeNovaSenha = {
            "senha": novaSenha
        }
    }

    var dataObject = Object.assign(data, propriedadeNovaSenha);

    var settings = {
        "url": `${urlApi}`,
        "method": "PUT",
        "data": JSON.stringify(dataObject),
        "headers": {
            "Authorization": `Bearer ${token}`,
            "content-type": "application/json"
        }
    }

    $.ajax(settings).done((response) => {

        var mensagem = "Os dados foram editados com sucesso";
        var timeout = 2000;
        HelperClass.MostrarToastSucesso(mensagem, timeout, (() => {
            location.reload();
        }));

    }).fail((jqXHR) => {

        if (jqXHR.status == 401) {
            var mensagem = `${jqXHR.status} - Faça login e tente novamente`;
            var timeout = 2000;
            HelperClass.MostrarToastErro(mensagem, timeout, (() => {
                window.location.href = "login.html";
            }))
            return;
        }

        var mensagem = `${jqXHR.status} - Erro ao atualizar dados`;
        var timeout = 2000;
        HelperClass.MostrarToastErro(mensagem, timeout);
    })

}

$(function () {
    BuscarInformacoesUsuario();
})