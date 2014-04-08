function validarFormularioCompra() {
   
    var strMsg = '';
    if (document.getElementById('txtNome').value == "")
        strMsg += 'Informe o nome\n';
    if (document.getElementById('txtDataNascimento').value == "")
        strMsg += 'Informe a data nascimento\n';
    if (document.getElementById('txtEmail').value == "")
        strMsg += 'Informe o email\n';
    if (document.getElementById('txtEndereco').value == "")
        strMsg += 'Informe o endereço\n';
    if (document.getElementById('txtTelefone').value == "")
        strMsg += 'Informe o telefone de contato\n';
    if (strMsg != "")
        alert(strMsg);
    else
        alert('Pedido enviado com sucesso');

    return false;
}



