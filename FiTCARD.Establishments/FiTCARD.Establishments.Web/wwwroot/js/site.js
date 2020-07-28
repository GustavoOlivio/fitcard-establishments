const sendHttpRequest = (method, url, data) => {
    const promise = new Promise((resolve, reject) => {
        const xhr = new XMLHttpRequest();
        xhr.open(method, url);

        xhr.responseType = 'text';

        if (data) {
            xhr.setRequestHeader('Content-Type', 'application/json');
        }

        xhr.onload = () => {
            if (xhr.status >= 400) {
                reject(xhr.response)
            } else {
                resolve(xhr.response);
            }
        }

        xhr.onerror = () => {
            reject(xhr.response);
        }

        xhr.send(JSON.stringify(data));
    });
    return promise;
};

const getData = (url) => {
    sendHttpRequest('GET', url).then(responseData => {
        coinsole.log(responseData);
    });
}

const sendData = (method, url, data, urlSuccess) => {
    sendHttpRequest(method, url, data)
        .then(responseData => {
            alert(responseAlert(method));
            window.location.href = urlSuccess;
        }).catch(err => {
            alert(err);
        })
}

function responseAlert(method) {
    switch (method) {
        case 'POST':
            return 'Registro Incluído com sucesso!';
        case 'DELETE':
            return 'Registro Excluído com sucesso!';
        case 'PUT':
            return 'Registro Atualizado com sucesso!';
        default:
            return 'Ocorreu um erro!';
    }
}

const printError = (field, message) => {
    if (field) {
        if (!$(field).siblings('.fieldError').length) {
            $(field).after('<p class="fieldError">' + message + '</p>')
        }
    }
}

const isValidEmail = (sEmail) => {
    if (!sEmail)
        return true;
    var emailFilter = /^.+@.+\..{2,}$/;
    var illegalChars = /[\(\)\<\>\,\;\:\\\/\"\[\]]/;
    return (emailFilter.test(sEmail)) && !sEmail.match(illegalChars)
}

const removeError = (field) => {
    if (field) {
        if ($(field).siblings('.fieldError').length) {
            $(field).siblings('.fieldError').remove()
        }
    }
}

const validaData = (data) => {
    var matches = /^(\d{2})[-\/](\d{2})[-\/](\d{4})$/.exec(data);
    if (matches == null) return false;
    var d = matches[1];
    var m = matches[2] - 1;
    var y = matches[3];
    var composedDate = new Date(y, m, d);
    return composedDate.getDate() == d &&
        composedDate.getMonth() == m &&
        composedDate.getFullYear() == y;
}

$(document).ready(function () {
    $("#cnpj").mask("00.000.000/0000-00")
    $("#telefone").mask("(00) 0000-00000")
    $("#bancoAgencia").mask("000-0")
    $("#bancoConta").mask("00.000-0")
    $("#dataCadastro").mask("00/00/0000")

    $("#telefone").blur(function (event) {
        if ($(this).val().length == 15) {
            $("#telefone").mask("(00) 0000-00000")
        } else {
            $("#telefone").mask("(00) 0000-0000")
        }
    })

    $("#dataCadastro").on('keyup', (event) => {
        if (!validaData($('#dataCadastro').val())) {
            printError('#dataCadastro', 'Data Inválida!')
        } else {
            removeError('#dataCadastro');
        }
    })

    $("#email").on('keyup', (event) => {
        if (!isValidEmail($('#email').val())) {
            printError('#email', 'E-mail incorreto!')
        } else {
            removeError('#email');
        }
    })

    $("#cnpj").on('keyup', (event) => {
        if ($('#cnpj').val().replace(/[^0-9]+/g, '').length != 14) {
            printError('#cnpj', 'CNPJ Inválido!')
        } else {
            removeError('#cnpj');
        }
    })

    $("#razaoSocial").on('keyup', (event) => {
        if ($('#razaoSocial').val() == '') {
            printError('#razaoSocial', 'Digite a Razão Social')
        } else {
            removeError('#razaoSocial');
        }
    })
})