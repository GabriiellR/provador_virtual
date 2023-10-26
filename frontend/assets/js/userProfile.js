document.addEventListener('DOMContentLoaded', function() {
    var form = document.getElementById('form'); 
    var divEditar = document.getElementById('divEditar');
    var habilitarButton = document.getElementById('habilitar-button');
    let salvarDados = document.getElementById('salvarDados');

    var elements = form.querySelectorAll('input, select, button, a');

    elements.forEach(function(element) {
        element.disabled = true;
    });


    habilitarButton.addEventListener('click', function() {
        var salvarButton = document.createElement('a');
        salvarButton.href = '#!';
        salvarButton.className = 'btn btn-sm btn-primary';
        salvarButton.textContent = 'Salvar Dados';
        salvarButton.id = 'salvarDados';
        salvarButton.onclick = disabledForm

        divEditar.appendChild(salvarButton);


        elements.forEach(function(element) {
            element.disabled = false;
        });
    });

   

    
});

function disabledForm() {
    var elements = form.querySelectorAll('input, select, button, a');
    let salvarDados = document.getElementById('salvarDados');

    elements.forEach(function(element) {
        element.disabled = true;
    });
    let botao = salvarDados.parentNode
    botao.removeChild(salvarDados)
}