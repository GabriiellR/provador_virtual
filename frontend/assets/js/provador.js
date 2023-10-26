const hamburger = document.querySelector('.header .nav-bar .nav-list .hamburger');
const mobile_menu = document.querySelector('.header .nav-bar .nav-list ul');
const menu_item = document.querySelectorAll('.header .nav-bar .nav-list ul li a');
const header = document.querySelector('.header.container');
let imagemAtual = 0;
const imagemBase = document.getElementById('imagemBase')

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


function openImage(imageId) {

	if (imageId == 1) {
		document.getElementById('virtual-image').src = '../images/provador/TernoPreto01.png';
	}
	if (imageId == 2) {
		document.getElementById('virtual-image').src = '../images/provador/TernoPreto02.png';
	}
	if (imageId == 3) {
		document.getElementById('virtual-image').src = '../images/provador/TernoPreto03.png';
	}
	if (imageId == 4) {
		document.getElementById('virtual-image').src = '../images/provador/TernoPreto04.png';
	}
	if (imageId == 5) {
		document.getElementById('virtual-image').src = '../images/provador/TernoCinza01.png';
	}
}

document.addEventListener('DOMContentLoaded', function () {
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

	const produtoImagem = document.getElementById('produtoImagem');
	const setaEsquerda = document.getElementById('setaEsquerda');
	const setaDireita = document.getElementById('setaDireita');
	const detalhesProduto = document.getElementById('detalhesProduto');
	

	const detalhesImagens = [
		{
			descricao: 'Descrição da primeira imagem',
			preco: '$100.00',
			disponibilidade: 'Em estoque',
			cor: 'Azul',
			tamanho: 'M',
			material: 'Algodão',
			modelo: '1234'
		},
		{
			descricao: 'Descrição da segunda imagem',
			preco: '$150.00',
			disponibilidade: 'Fora de estoque',
			cor: 'Vermelho',
			tamanho: 'L',
			material: 'Seda',
			modelo: '5678'
		},
		{
			descricao: 'Descrição da segunda imagem',
			preco: '$200.00',
			disponibilidade: 'Fora de estoque',
			cor: 'Vermelho',
			tamanho: 'L',
			material: 'Seda',
			modelo: '5678'
		},
		{
			descricao: 'Gravata Xadrez Cinza Com Azul',
			preco: 'R$29,90',
			disponibilidade: 'Em estoque',
			cor: 'Cinza com Azul',
			tamanho: 'Slim',
			material: '100% Poliéster',
		},
		{
			descricao: 'Gravata Xadrez Azul, Branco e Laranja',
			preco: 'R$29,90',
			disponibilidade: 'Em estoque',
			cor: 'Azul, Branco e Laranja',
			tamanho: 'Slim',
			material: '100% Poliéster',
		}
		// Adicione mais detalhes conforme necessário
	];


	function atualizarDetalhes() {
		const detalhes = detalhesImagens[imagemAtual];
		detalhesProduto.innerHTML = `
            <h3>Gravata</h3>
            <p>Descrição do Produto: ${detalhes.descricao}</p>
            <p>Preço: ${detalhes.preco}</p>
            <p>Disponibilidade: ${detalhes.disponibilidade}</p>
            <p>Cor: ${detalhes.cor}</p>
            <p>Tamanho: ${detalhes.tamanho}</p>
            <p>Material: ${detalhes.material}</p>

            <div class="experimentar-btn">
              <button id="experimentar" onclick="vestir()">Experimentar</button>
              <button class="" style="margin-left: 160px;">
                <ion-icon name="heart-outline"></ion-icon>
              </button>
            </div>
        `;
	}

	setaEsquerda.addEventListener('click', function () {
		imagemAtual = (imagemAtual - 1 + detalhesImagens.length) % detalhesImagens.length;
		produtoImagem.src = `../images/provador/${imagemAtual + 1}.png`;
		atualizarDetalhes();
	});
	
	setaDireita.addEventListener('click', function () {
		console.log('seta', imagemAtual)
		imagemAtual = (imagemAtual + 1) % detalhesImagens.length;
		produtoImagem.src = `../images/provador/${imagemAtual + 1}.png`;
		atualizarDetalhes();
	});
	
	// Carregar a primeira imagem ao iniciar a página
	produtoImagem.src = `../images/provador/1.png`;
	atualizarDetalhes();
	

});

// function vestir() {
// 		if (imagemAtual === 0) {
// 			imagemBase.src = '../images/provador/a.png';
// 		} else if (imagemAtual === 1) {
// 			imagemBase.src = '../images/provador/b.png';
// 		} else if (imagemAtual === 2) {
// 			imagemBase.src = '../images/provador/c.png';
// 		}
// }

function vestir() {

    if (imagemAtual === 0) {
        anime({
            targets: imagemBase,
            opacity: [1, 0],
            scale: [1, 1.05], 
            translateX: [0, 10], 
            duration: 500,
            easing: 'easeInOutQuad',
            complete: function() {
                imagemBase.src = '../images/provador/TernoPreto01.png';
                anime({
                    targets: imagemBase,
                    opacity: [0, 1],
                    scale: [1.05, 1],
                    translateX: [10, 0], 
                    duration: 500,
                    easing: 'easeInOutQuad'
                });
            }
        });
    } else if (imagemAtual === 1) {
        anime({
            targets: imagemBase,
            opacity: [1, 0],
            scale: [1, 1.05],
            translateX: [0, 10],
            duration: 500,
            easing: 'easeInOutQuad',
            complete: function() {
                imagemBase.src = '../images/provador/TernoPreto02.png';
                anime({
                    targets: imagemBase,
                    opacity: [0, 1],
                    scale: [1.05, 1],
                    translateX: [10, 0],
                    duration: 500,
                    easing: 'easeInOutQuad'
                });
            }
        });
    }
	else if (imagemAtual === 2) 
	{
        anime({
            targets: imagemBase,
            opacity: [1, 0],
            scale: [1, 1.05],
            translateX: [0, 10],
            duration: 500,
            easing: 'easeInOutQuad',
            complete: function() {
                imagemBase.src = '../images/provador/TernoPreto03.png';
                anime({
                    targets: imagemBase,
                    opacity: [0, 1],
                    scale: [1.05, 1],
                    translateX: [10, 0],
                    duration: 500,
                    easing: 'easeInOutQuad'
                });
            }
        });
		
    }
	else if (imagemAtual === 3) 
	{
        anime({
            targets: imagemBase,
            opacity: [1, 0],
            scale: [1, 1.05],
            translateX: [0, 10],
            duration: 500,
            easing: 'easeInOutQuad',
            complete: function() {
                imagemBase.src = '../images/provador/TernoPreto04.png';
                anime({
                    targets: imagemBase,
                    opacity: [0, 1],
                    scale: [1.05, 1],
                    translateX: [10, 0],
                    duration: 500,
                    easing: 'easeInOutQuad'
                });
            }
        });
		
    }
	else if (imagemAtual === 4) 
	{
        anime({
            targets: imagemBase,
            opacity: [1, 0],
            scale: [1, 1.05],
            translateX: [0, 10],
            duration: 500,
            easing: 'easeInOutQuad',
            complete: function() {
                imagemBase.src = '../images/provador/TernoCinza01.png';
                anime({
                    targets: imagemBase,
                    opacity: [0, 1],
                    scale: [1.05, 1],
                    translateX: [10, 0],
                    duration: 500,
                    easing: 'easeInOutQuad'
                });
            }
        });
		
    }
}