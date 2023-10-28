AdicionarMascara();


function AdicionarMascara() {
    alert('asd');
}


function BuscarEndereco() {

    var urlBase = "https://viacep.com.br/ws";

    var cep = $('#cep').val();
    var bairro = $('#bairro').val();
    var cidade = $('#cidade').val();
    var estado = $('#estado').val();
    var endereco = $('#endereco').val();

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


    }).fail((jqXHR) => {
        $('#bairro').prop('required', true);
        $('#cidade').prop('required', true);
        $('#estado').prop('required', true);
        $('#endereco').prop('required', true);

    })


}