var url = `${HelperClass.urlApi}/administracao`;
let instanciaAtualProdutos = {};


function BuscarProdutos() {

    var settings = {
        "url": `${url}/produto/detalhes`,
        "method": "GET",
    }

    $.ajax(settings).done((response) => {

        console.log(response);
        instanciaAtualProdutos = response;
        CarregarProdutos();
        CarregarProdutosPopulares();
        CarregarMelhoresCombinacoes();


    }).fail((jqXHR) => {
        var mensagem = `${jqXHR.status} - Não foi possível buscar os produtos`;
        var timeout = 2000;
        HelperClass.MostrarToastErro(mensagem, timeout);
        return;
    })

}

function CarregarCategorias() {

}


function CarregarProdutosPopulares() {

}

function CarregarMelhoresCombinacoes() {

}

function CarregarProdutos() {

    $.each(instanciaAtualProdutos, (index, produtos) => {
        
        $('#produtos').append(`<div class="">
        <div class="showcase-banner">
          <img src="assets/${produtos.imagem}" alt="Produto" width="300"class="product-img default">
        </div>

        <div class="showcase-content">

          <a href="#" class="showcase-category">${produtos.nome}</a>

          <a href="#">
            <h3 class="showcase-title">${produtos.preco.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</h3>
          </a>

        </div>

      </div>`);
    })

    
}



       
$(function () {
    BuscarProdutos();
})