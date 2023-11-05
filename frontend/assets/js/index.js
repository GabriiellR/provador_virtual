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

function CarregarProdutosPopulares() {

  for (i = 0; i <= 3; i++) {

    var numeroaleatorio = Math.floor(Math.random() * instanciaAtualProdutos.length);

    $('#mais-populares').append(`<div class="showcase-container">
                                  <div class="showcase">
                                    <a href="#" class="showcase-img-box">
                                      <img src="./assets/${instanciaAtualProdutos[numeroaleatorio].imagem}" alt="relaxed short full sleeve t-shirt" width="70"
                                        class="showcase-img">
                                    </a>
                                    <div class="showcase-content">
                                      <a>
                                        <h4 class="showcase-title">${instanciaAtualProdutos[numeroaleatorio].nome}</h4>
                                      </a>
                                      <a class="showcase-category">${instanciaAtualProdutos[numeroaleatorio].preco.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</a>
                                    </div>
                                  </div>
                                 </div>`);
  }

}

function CarregarMelhoresCombinacoes() {

  for (i = 0; i <= 3; i++) {

    var numeroaleatorio = Math.floor(Math.random() * instanciaAtualProdutos.length);

    $('#melhores-combinacoes').append(`<div class="showcase-container">
                                  <div class="showcase">
                                    <a href="#" class="showcase-img-box">
                                      <img src="./assets/${instanciaAtualProdutos[numeroaleatorio].produtoImagensProvador[0].imagem}" alt="relaxed short full sleeve t-shirt" width="70"
                                        class="showcase-img">
                                    </a>
                                    <div class="showcase-content">
                                      <a href="#">
                                        <h4 class="showcase-title">${instanciaAtualProdutos[numeroaleatorio].nome}</h4>
                                      </a>
                                      <a href="#" class="showcase-category">${instanciaAtualProdutos[numeroaleatorio].preco.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</a>
                                    </div>
                                  </div>
                                 </div>`);
  }

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