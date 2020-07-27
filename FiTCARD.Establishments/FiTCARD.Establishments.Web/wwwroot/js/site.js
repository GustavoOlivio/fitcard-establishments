const sendHttpRequest = (method, url, data) => {
    const promise = new Promise((resolve, reject) => {
        const xhr = new XMLHttpRequest();
        xhr.open(method, url);

        xhr.responseType = 'json';

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
            reject('Erro!');
        }

        xhr.send(JSON.stringify(data));
    });
    return promise;
};

const getData = () => {
    sendHttpRequest('GET', 'urlhere').then(responseData => {
        coinsole.log(responseData);
    });
}

const sendData = (method, url, data, urlSuccess) => {
    sendHttpRequest(method, url, data)
        .then(responseData => {
            alert(responseAlert(method));
            window.location.href = urlSuccess;
        }).catch(err => {
            console.log(err);
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