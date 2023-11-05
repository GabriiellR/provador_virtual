var urlApi = `${HelperClass.urlApi}/administracao/usuario/autenticar`;


function Logar() {
    var email = $('#email').val();
    var senha = $('#senha').val();

    var camposValidos = HelperClass.ValidarCampos(email, senha);

    if (!camposValidos) {
        var mensagem = "Preencha todos os campos corretamente para continuar";
        var timeout = 2000;
        HelperClass.MostrarToastErro(mensagem, timeout);
        return;
    }

    HelperClass.ExibirPreloader();

    var data = {
        "email": email,
        "senha": senha
    }

    var settgins = {
        "url": `${urlApi}?email=${email}&senha=${senha}`,
        "method": "POST",
    }

    $.ajax(settgins).done((response) => {

        if (response) {

            localStorage.setItem("token", response);
            var usuario = HelperClass.ParseJwt(response);

            var mensagem = `Bem-vindo(a) ${usuario.nome}`;
            var timeout = 2000;
            HelperClass.MostrarToastSucesso(mensagem, timeout, (() => {
                window.location.href = "../../index.html";
            }));
        }


    }).fail((jqXHR) => {
        var mensagem = `${jqXHR.status} - Não foi possível autenticar`;
        var timeout = 2000;
        HelperClass.MostrarToastErro(mensagem, timeout, (()=>{
            HelperClass.RemoverPreLaoder();
        }));
        return;
    })


}