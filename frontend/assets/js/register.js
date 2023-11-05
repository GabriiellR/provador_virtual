var urlApi = `${HelperClass.urlApi}/administracao/Usuario`;

AdicionarMascara();

function AdicionarMascara() {
    $('#data-nascimento').mask('00/00/0000');
    $('#cep').mask('00000-000');
    $('#cpf').mask('000.000.000-00', { reverse: true });
}

function BuscarEndereco() {

    HelperClass.ExibirPreloader();

    var urlBase = "https://viacep.com.br/ws";

    var cep = $('#cep').val();

    var settings = {
        "url": `${urlBase}/${cep}/json/`,
        "method": "GET"
    }

    $.ajax(settings).done((response) => {

        $('#cep').val();
        $('#bairro').val(response.bairro);
        $('#cidade').val(response.localidade);
        $('#estado').val(response.uf);
        $('#endereco').val(response.logradouro);

        $('#bairro').prop('readonly', true);
        $('#cidade').prop('readonly', true);
        $('#estado').prop('readonly', true);
        $('#endereco').prop('readonly', true);

        HelperClass.RemoverPreLaoder();

    }).fail((jqXHR) => {
        $('#bairro').prop('required', true);
        $('#cidade').prop('required', true);
        $('#estado').prop('required', true);
        $('#endereco').prop('required', true);

        $('#bairro').prop('readonly', false);
        $('#cidade').prop('readonly', false);
        $('#estado').prop('readonly', false);
        $('#endereco').prop('readonly', false);

        HelperClass.RemoverPreLaoder();
    })
}

function CadastrarUsuario() {

    var nome = $('#nome').val();
    var cep = $('#cep').val();
    var bairro = $('#bairro').val();
    var cidade = $('#cidade').val();
    var estado = $('#estado').val();
    var endereco = $('#endereco').val();
    var dataNascimento = $('#data-nascimento').val();
    var email = $('#email').val();
    var emailConfirmacao = $('#email-confirmacao').val();
    var senha = $('#senha').val();
    var senhaConfirmacao = $('#senha-confirmacao').val();

    var camposValidos = HelperClass.ValidarCampos(nome, bairro, cidade, estado, endereco, dataNascimento, email, emailConfirmacao, senha, senhaConfirmacao)

    if (!camposValidos) {
        var mensagem = "Preencha todos os campos para continuar";
        var timeout = 2000;
        HelperClass.MostrarToastErro(mensagem, timeout);
        return;
    }

    if (email != emailConfirmacao) {
        var mensagem = "Os e-mails não conferem";
        var timeout = 2000;
        HelperClass.MostrarToastErro(mensagem, timeout);
        return;
    }

    if (senha != senhaConfirmacao) {
        var mensagem = "As senhas não conferem";
        var timeout = 2000;
        HelperClass.MostrarToastErro(mensagem, timeout);
        return;
    }

    HelperClass.ExibirPreloader();

    var dataNascimentoArray = dataNascimento.split('/');
    var dataNascimnetoFormat = `${dataNascimentoArray[2]}-${dataNascimentoArray[1]}-${dataNascimentoArray[0]}`;

    var data = {
        "nome": nome,
        "cep": cep,
        "bairro": bairro,
        "cidade": cidade,
        "estado": estado,
        "endereco": endereco,
        "dataNascimento": dataNascimnetoFormat,
        "email": email,
        "senha": senha
    }

    var settings = {
        "url": `${urlApi}`,
        "method": "POST",
        "data": JSON.stringify(data),
        "headers": {
            "content-type": "application/json"
        }
    }

    $.ajax(settings).done((response) => {

        var mensagem = "Usuário cadastrado com sucesso";
        var timeout = 2000;
        HelperClass.MostrarToastSucesso(mensagem, timeout, (() => {
            window.location.href = "login.html";
        }));

    }).fail((jqXHR) => {
        var mensagem = `${jqXHR.status} - Não foi possível cadastrar o usuário`;
        var timeout = 2000;
        HelperClass.MostrarToastErro(mensagem, timeout);
        HelperClass.RemoverPreLaoder();
    })



}
