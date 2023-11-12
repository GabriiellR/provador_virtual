class HelperClass {

    static urlApi = "https://localhost:7125/api";

    static MostrarToastSucesso(mensagem, timeout, callback) {

        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: timeout,
            timerProgressBar: true,
            didClose: callback
        })

        Toast.fire({
            icon: 'success',
            title: mensagem
        })
    }

    static MostrarToastErro(mensagem, timeout, callback) {

        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: timeout,
            timerProgressBar: true,
            didClose: callback
        })

        Toast.fire({
            icon: 'error',
            title: mensagem
        })
    }

    static ValidarCampos(...campos) {

        var valido = true;

        $.each(campos, (index, campo) => {

            if (!campo) {
                valido = false;
            }
        })

        return valido;
    }

    static ParseJwt(token) {
        try {
            return JSON.parse(atob(token.split('.')[1]));
        } catch (e) {
            return null;
        }
    };

    static InicializarSwipper() {

        var swiper = new Swiper(".mySwiper", {
            pagination: {
                el: ".swiper-pagination",
                type: "progressbar",
            },
            navigation: {
                nextEl: ".swiper-button-next",
                prevEl: ".swiper-button-prev",
            },
        });

        return swiper;
    }

    static ExibirPreloader() {

        $('body').css('background-color', '#fff');
        $('body').css('opacity', 0.7);
        $('body').css('pointer-events', 'none');
        $('body').css('cursor', 'wait');
    }

    static RemoverPreLaoder() {
        $('body').css('background-color', 'transparent');
        $('body').css('opacity', 1);
        $('body').css('pointer-events', 'auto');
        $('body').css('cursor', 'default');
    }

}
var helperClass = new HelperClass();