var url = `${HelperClass.urlApi}/administracao`;
var instanciaAtualProdutos = {};

const hamburger = document.querySelector('.header .nav-bar .nav-list .hamburger');
const mobile_menu = document.querySelector('.header .nav-bar .nav-list ul');
const menu_item = document.querySelectorAll('.header .nav-bar .nav-list ul li a');
const header = document.querySelector('.header.container');
const imagemCombinacao = document.getElementById('imagemCombinacao')
let indiceProdutoAtual = 0;
let numeroTotalProdutos = 0;
let swipper;

hamburger.addEventListener('click', () => {
	hamburger.classList.toggle('active');
	mobile_menu.classList.toggle('active');
});

document.addEventListener('scroll', () => {
	var scroll_position = window.scrollY;
	if (scroll_position > 250) {
		header.style.backgroundColor = '#29323c';
	} else {
		header.style.backgroundColor = 'transparent';
	}
});

menu_item.forEach((item) => {
	item.addEventListener('click', () => {
		hamburger.classList.toggle('active');
		mobile_menu.classList.toggle('active');
	});
});

function BuscarProdutos() {

	HelperClass.ExibirPreloader();

	var settings = {
		"url": `${url}/produto/detalhes`,
		"method": "GET",
	}

	$.ajax(settings).done((response) => {

		HelperClass.RemoverPreLaoder();
		instanciaAtualProdutos = response;
		ControlarExibicaoProdutos(response);


	}).fail((jqXHR) => {
		var mensagem = `${jqXHR.status} - Não foi possível buscar os produtos`;
		var timeout = 2000;
		HelperClass.MostrarToastErro(mensagem, timeout);
		HelperClass.RemoverPreLaoder();
		return;
	})

}

function ControlarExibicaoProdutos() {

	swipper = HelperClass.InicializarSwipper();
	CarregarProdutos();
	numeroTotalProdutos = instanciaAtualProdutos.length;

	$('#setaEsquerda').click(() => {

		if (indiceProdutoAtual == 0) {
			indiceProdutoAtual = numeroTotalProdutos;
		}

		indiceProdutoAtual--;
		CarregarProdutos();
	});

	$('#setaDireita').click(() => {

		indiceProdutoAtual++;

		if (indiceProdutoAtual == numeroTotalProdutos) {
			indiceProdutoAtual = 0;
		}

		CarregarProdutos();
	});
}

function CarregarProdutos() {

	$('#produtoImagem').attr('src', `../${instanciaAtualProdutos[indiceProdutoAtual].imagemGravataProvador}`);
	$('#detalhesProduto').empty();
	$('#detalhesProduto').append(`<h3>Gravata</h3>
							      <p>Nome: ${instanciaAtualProdutos[indiceProdutoAtual].nome}</p>
							      <p>Preço: ${instanciaAtualProdutos[indiceProdutoAtual].preco}</p>
							      <p>Cor: ${instanciaAtualProdutos[indiceProdutoAtual].cor}</p>
							      <p>Tamanho: ${instanciaAtualProdutos[indiceProdutoAtual].tamanho}</p>
							      <p>Material: ${instanciaAtualProdutos[indiceProdutoAtual].material}</p>						
							      <div class="experimentar-btn">
							      	<button id="experimentar" onclick="vestir()">Experimentar</button>
							        <button   onclick="Favoritar()" >Favoritar</button>
							      <div>
	`);
}

document.addEventListener('DOMContentLoaded', function () {

	BuscarProdutos();

	const openModalButton = document.querySelector('.open-modal');
	const modal = document.getElementById('modal');
	const closeModalButton = document.getElementById('close-modal');

	openModalButton.addEventListener('click', function () {
		modal.style.display = 'flex';
		modal.style.animationName = 'modalopen';
	});

	closeModalButton.addEventListener('click', function () {
		modal.style.animationName = 'modalclose';
	});

	modal.addEventListener('animationend', function () {
		if (modal.style.animationName === 'modalclose') {
			modal.style.display = 'none';
		}
	});

});

function Favoritar() {

	var token = localStorage.getItem('token');

	if (!token) {
		var mensagem = "Faça login e tente novamente";
		var timeout = 2000;
		HelperClass.MostrarToastErro(mensagem, timeout, (() => {
			window.location.href = "login.html";
		}))
	}

	HelperClass.ExibirPreloader();

	var usuario = HelperClass.ParseJwt(token);

	var produtoId = instanciaAtualProdutos[indiceProdutoAtual].id;
	var usuarioId = usuario.id;

	var data = {
		"produtoId": produtoId,
		"usuarioId": usuarioId
	}


	var settings= {
		"url": `${url}/favoritos`,
		"method": "POST",
		"data": JSON.stringify(data),
		"headers": {
			"Authorization": `Bearer ${token}`,
			"content-type": "application/json"
		}
	}


	$.ajax(settings).done((response) => {

		var mensagem = "Produto adicionado aos favoritos";
		var timeout = 2000;
		HelperClass.MostrarToastSucesso(mensagem, timeout, (()=>{
			HelperClass.RemoverPreLaoder();
		}));


	}).fail((jqXHR) => {

		if (jqXHR.status == 401) {

			var mensagem = "Faça login e tente novamente";
			var timeout = 2000;
			HelperClass.MostrarToastErro(mensagem, timeout, (() => {
				window.location.href = "login.html";
			}))
			return;
		}

		var mensagem = `${jqXHR.status} - Erro ao adicionar favoritos`;
		var timeout = 2000;
		HelperClass.MostrarToastErro(mensagem, timeout);
		HelperClass.RemoverPreLaoder();
	})

}

function vestir() {

	swipper.slideTo(0, 500, true);
	var imagensCombinacoes = instanciaAtualProdutos[indiceProdutoAtual].produtoImagensProvador;

	$('.swiper-wrapper').empty();

	$.each(imagensCombinacoes, ((index, combinacao) => {

		$('.swiper-wrapper').append(`<div class="swiper-slide"><img src="../${combinacao.imagem}" alt="Imagem do Produto" /></div>`);
	}))

}