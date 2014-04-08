function validarFormularioCompra() {
   
    var strMsg = '';
    if (document.getElementById('txtNome').value == "")
        strMsg += 'Informe o nome\n';
    if (document.getElementById('txtDataNascimento').value == "")
        strMsg += 'Informe a data nascimento\n';  

    if (strMsg != "")
        alert(strMsg);
    else
        alert('Pedido enviado com sucesso');

    return false;
}



