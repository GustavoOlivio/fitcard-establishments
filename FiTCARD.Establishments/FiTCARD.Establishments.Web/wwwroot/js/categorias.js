function insertCategoria() {
    let nome = document.querySelector("#nome").value;
    let ativo = document.querySelector("#ativo").value == "true" ? true : false;
    let telefoneObrigatorio = document.querySelector("#telefoneObrigatorio").value == "true" ? true : false;

    var data = {
        Nome: nome,
        Ativo: ativo,
        TelefoneObrigatorio: telefoneObrigatorio
    };

    sendData('POST', '/api/categorias/insert', data, '/api/categorias/');
}

function updateCategoria() {
    let id = parseInt(document.querySelector("#id").value);
    let nome = document.querySelector("#nome").value;
    let ativo = document.querySelector("#ativo").value == "true" ? true : false;
    let telefoneObrigatorio = document.querySelector("#telefoneObrigatorio").value == "true" ? true : false;

    var data = {
        Id: id,
        Nome: nome,
        Ativo: ativo,
        TelefoneObrigatorio: telefoneObrigatorio
    };

    sendData('PUT', '/api/categorias/update', data, '/api/categorias/');
}

function deleteCategoria(id) {
    if (confirm('Deseja excluir a categoria?'))
        sendData('DELETE', '/api/categorias/delete?Id=' + id, null, '/api/categorias/');
}