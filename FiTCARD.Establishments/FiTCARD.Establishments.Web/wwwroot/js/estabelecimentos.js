function insertEstabelecimento() {

    if (!validaForm()) return;

    let razaoSocial = document.querySelector("#razaoSocial").value;
    let nomeFantasia = document.querySelector("#nomeFantasia").value;
    let cnpj = document.querySelector("#cnpj").value.replace(/[^0-9]+/g, '');
    let email = document.querySelector("#email").value;
    let endereco = document.querySelector("#endereco").value;
    let cidade = document.querySelector("#cidade").value;
    let estado = document.querySelector("#estado").value;
    let dataCadastro = convertData(document.querySelector("#dataCadastro").value);
    let categoria = parseInt(document.querySelector("#categoria").value);
    let telefone = document.querySelector("#telefone").value.replace(/[^0-9]+/g, '');
    let bancoAgencia = parseInt(document.querySelector("#bancoAgencia").value.replace(/[^0-9]+/g, ''));
    let bancoConta = parseInt(document.querySelector("#bancoConta").value.replace(/[^0-9]+/g, ''));
    let ativo = document.querySelector("#ativo").checked;

    var data = {
        RazaoSocial: razaoSocial,
        NomeFantasia: nomeFantasia == null ? "" : nomeFantasia,
        CNPJ: cnpj,
        Email: email == null ? "" : email,
        Endereco: endereco == null ? "" : endereco,
        Cidade: cidade == null ? "" : cidade,
        Estado: estado == null ? "" : estado,
        DataCadastro: dataCadastro,
        CategoriaId: categoria,
        CategoriaNome: 'categoria',
        Telefone: telefone == null ? "" : telefone,
        BancoAgencia: bancoAgencia == null ? "" : 0,
        BancoConta: bancoConta == null ? "" : 0,
        Ativo: ativo
    };

    sendData('POST', '/api/estabelecimentos/insert', data, '/api/estabelecimentos/');
}

function updateEstabelecimento() {
    if (!validaForm()) return;

    let id = parseInt(document.querySelector("#id").value);
    let razaoSocial = document.querySelector("#razaoSocial").value;
    let nomeFantasia = document.querySelector("#nomeFantasia").value;
    let cnpj = document.querySelector("#cnpj").value.replace(/[^0-9]+/g, '');
    let email = document.querySelector("#email").value;
    let endereco = document.querySelector("#endereco").value;
    let cidade = document.querySelector("#cidade").value;
    let estado = document.querySelector("#estado").value;
    let dataCadastro = convertData(document.querySelector("#dataCadastro").value);
    let categoria = parseInt(document.querySelector("#categoria").value);
    let telefone = document.querySelector("#telefone").value.replace(/[^0-9]+/g, '');
    let bancoAgencia = parseInt(document.querySelector("#bancoAgencia").value.replace(/[^0-9]+/g, ''));
    let bancoConta = parseInt(document.querySelector("#bancoConta").value.replace(/[^0-9]+/g, ''));
    let ativo = document.querySelector("#ativo").checked;

    var data = {
        Id: id,
        RazaoSocial: razaoSocial,
        NomeFantasia: nomeFantasia,
        Cnpj: cnpj,
        Email: email,
        Endereco: endereco,
        Cidade: cidade,
        Estado: estado,
        DataCadastro: dataCadastro,
        Categoria: categoria,
        Telefone: telefone,
        BancoAgencia: bancoAgencia,
        BancoConta: bancoConta,
        Ativo: ativo
    };

    sendData('PUT', '/api/estabelecimentos/update', data, '/api/estabelecimentos/');
}

function deleteEstabelecimento(id) {
    if (confirm('Deseja excluir o estabelecimento?'))
        sendData('DELETE', '/api/estabelecimentos/delete?Id=' + id, null, '/api/estabelecimentos/');
}

function validaForm() {
    let result = true;
    if (!$('#razaoSocial').val()) {
        printError('#razaoSocial', 'Campo obrigatório!');
        result = false;
    }
    if ($('#cnpj').val().replace(/[^0-9]+/g, '').length != 14) {
        printError('#cnpj', 'CNPJ Inválido!');
        result = false;
    }

    if (!validaData($('#dataCadastro').val())) {
        printError('#dataCadastro', 'Data Inválida!');
        result = false;
    }

    return result;
}

function convertData(data) {
    data_formatada = data.substr(6, 4) + '-' + data.substr(3, 2) + '-' + data.substr(0, 2);
    return data_formatada;
}