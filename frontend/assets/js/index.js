var url = `${HelperClass.urlApi}/administracao`;
let instanciaAtualProdutos = {};
let instanciaFavoritos = {};


function BuscarProdutos() {

  HelperClass.ExibirPreloader();

  var settings = {
    "url": `${url}/produto/detalhes`,
    "method": "GET",
  }

  $.ajax(settings).done((response) => {
    instanciaAtualProdutos = response;
    CarregarProdutos();
    CarregarProdutosPopulares();
    CarregarMelhoresCombinacoes();
    HelperClass.RemoverPreLaoder();


  }).fail((jqXHR) => {
    var mensagem = `${jqXHR.status} - Não foi possível buscar os produtos`;
    var timeout = 2000;
    HelperClass.MostrarToastErro(mensagem, timeout);
    HelperClass.RemoverPreLaoder();
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

function BuscarFavoritos() {

  var token = localStorage.getItem('token');

  if (!token) {
    var mensagem = "Faça login e tente novamente";
    var timeout = 2000;
    HelperClass.MostrarToastErro(mensagem, timeout, (() => {
      window.location.href = "assets/pages/login.html";
    }))
  }

  var usuario = HelperClass.ParseJwt(token);

  HelperClass.ExibirPreloader();
  var settings = {
    "url": `${url}/favoritos/${usuario.id}/favoritos`,
    "method": "GET",
    "headers": {
      "Authorization": `Bearer ${token}`
    }
  }

  $.ajax(settings).done((response) => {

    HelperClass.RemoverPreLaoder();

    $('#produtos-favoritados').empty();

    $.each(response, (index, favorito) => {


      $('#produtos-favoritados').append(`<div> <ion-icon  name="close" class="favorito" data-favorito-id="${favorito.id}" aria-label="true"></ion-icon>
      <div class="showcase-banner">
        <img src="assets/${favorito.produto.imagem}" alt="Produto" width="90"class="product-img default">
      </div>

      <div class="showcase-content">

        <a href="#" class="showcase-category" style="font-size="50px !important" ">${favorito.produto.nome}</a>

        <a href="#">
          <small style="font-size="30px !important" class="showcase-title">${favorito.produto.preco.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</small>
        </a>

      </div>
    </div>`);
    });

  }).fail((jqXHR) => {

    if (jqXHR.status == 401) {
      var mensagem = "Faça login para continuar";
      var timeout = 1500;
      HelperClass.MostrarToastErro(mensagem, timeout, (() => {
        location.href = "assets/pages/login.html"
      }));
      return;
    }

    var mensagem = "Erro ao buscar favoritos";
    var timeout = 2000;
    HelperClass.MostrarToastErro(mensagem, timeout);
    HelperClass.RemoverPreLaoder();
  })


}

function RemoverFavorito() {


  var token = localStorage.getItem('token');

  if (!token) {
    var mensagem = "Faça login e tente novamente";
    var timeout = 2000;
    HelperClass.MostrarToastErro(mensagem, timeout, (() => {
      window.location.href = "assets/pages/login.html";
    }))
  }

  var usuario = HelperClass.ParseJwt(token);

  HelperClass.ExibirPreloader();

  $(document).on('click', '.favorito', function () {

    var favoritoIndex = $(this).data('favorito-id');

    var settings = {
      "url": `${url}/favoritos/${favoritoIndex}`,
      "method": "DELETE",
      "data": JSON.stringify({ "id": favoritoIndex }),
      "headers": {
        "Authorization": `bearer ${token}`,
        "content-type": "application/json"
      }
    }

    $.ajax(settings).done((response) => {

      var mensagem = "Produto removido dos favoritos com sucesso";
      var timeout = 1500;
      HelperClass.MostrarToastSucesso(mensagem, timeout, (() => {
        location.reload();
      }));

      HelperClass.RemoverPreLaoder();

    }).fail((jqXHR) => {

      var mensagem = "Erro ao remover produto dos favoritos";
      var timeout = 1500;
      HelperClass.MostrarToastErro(mensagem, timeout)

      HelperClass.RemoverPreLaoder();
    })
  });

}

$(function () {
  BuscarProdutos();
  RemoverFavorito();
})