class HelperClass {

    static urlApi = "https://localhost:7125/api";

    static MostrarToastSucesso(mensagem, timeout, callback) {

        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: timeout,
            timerProgressBar: true,
            didOpen: callback
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
            didOpen: callback
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
}
var helperClass = new HelperClass();