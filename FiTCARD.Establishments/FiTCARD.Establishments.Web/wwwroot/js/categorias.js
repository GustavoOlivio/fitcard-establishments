function insertCategoria() {

    if (!validaForm()) return;

    let nome = document.querySelector("#nome").value;
    let ativo = document.querySelector("#ativo").checked;
    let telefoneObrigatorio = document.querySelector("#telefoneObrigatorio").checked;

    var data = {
        Nome: nome,
        Ativo: ativo,
        TelefoneObrigatorio: telefoneObrigatorio
    };

    sendData('POST', '/api/categorias/insert', data, '/api/categorias/');
}

function updateCategoria() {

    if (!validaForm()) return;

    let id = parseInt(document.querySelector("#id").value);
    let nome = document.querySelector("#nome").value;
    let ativo = document.querySelector("#ativo").checked;
    let telefoneObrigatorio = document.querySelector("#telefoneObrigatorio").checked;

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

function validaForm() {
    let result = true;
    if (!$('#nome').val()) {
        printError('#nome', 'Campo obrigatório!');
        result = false;
    }

    return result;
}
