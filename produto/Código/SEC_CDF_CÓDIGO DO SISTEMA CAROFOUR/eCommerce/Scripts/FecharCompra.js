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
    else {
        document.location.href = 'DadosPedido';//Redirecionar para a tela com os dados do pedido
        alert('Pedido enviado com sucesso'); //Retirar a mensagem  .. Submit
    }

    return false;
}

function formataTelefone(valor, evt) {    
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValidaTelefone(tecla))
        return;

    var str = valor.value = filtraNumeros(filtraCampo(valor));

    var iniStr = "", endStr = "";
    str = str.replace(".", "").replace("-", "").replace("#", "").replace("*", "")
				.replace("(", "").replace(")", "");

    var length = str.length;

    for (var i = 0; i < str.length; i++) {
        iniStr = str.substring(0, i);

        // verifica se é um grupo de 4 dígitos e não é o final da string
        if (i == 0 || i == 3 || i == 8 || i == 9) {
            if (str.length > i)
                endStr = str.substring(i, str.length);
            else endStr = "";

            var strConcat = "";
            str = "";

            if (i == 0)
                strConcat = "(";

            if (i == 3)
                strConcat = ")";

            if ((i == 9 && length == 11)
  				  || (i == 8 && length <= 10))
                strConcat = "-";

            if (strConcat != "") {
                str = str.concat(iniStr) + strConcat + str.concat(endStr);
                i++;
            }
            else str = str.concat(iniStr) + str.concat(endStr);

        } else if (str.length > i) {
            endStr = str.substring(i, str.length);
        } else {
            endStr = "";
        }
    }

    valor.value = str;

}
//evita criar mascara quando as teclas são pressionadas
function teclaValidaTelefone(tecla) {
    if ( //backspace
        //Esta evitando o post, quando são pressionadas estas teclas.
        //Foi comentado pois, se for utilizado o evento texchange, é necessario o post.
         tecla == 9 //TAB
        || tecla == 27 //ESC
        || tecla == 16 //Shif TAB
        || tecla == 45 //insert
        || tecla == 46 //delete
        || tecla == 35 //home
        || tecla == 36 //end
        || tecla == 37 //esquerda
        || tecla == 38 //cima
        || tecla == 39 //direita
        || tecla == 40)//baixo
        return false;
    else
        return true;
}
// limpa todos caracteres que não são números
function filtraNumeros(campo) {
    var s = "";
    var cp = "";
    vr = campo;
    tam = vr.length;
    for (i = 0; i < tam; i++) {
        if (vr.substring(i, i + 1) == "0" ||
            vr.substring(i, i + 1) == "1" ||
            vr.substring(i, i + 1) == "2" ||
            vr.substring(i, i + 1) == "3" ||
            vr.substring(i, i + 1) == "4" ||
            vr.substring(i, i + 1) == "5" ||
            vr.substring(i, i + 1) == "6" ||
            vr.substring(i, i + 1) == "7" ||
            vr.substring(i, i + 1) == "8" ||
            vr.substring(i, i + 1) == "9") {
            s = s + vr.substring(i, i + 1);
        }
    }
    return s;    
}
// recupera o evento do form
function getEvent(evt) {
    if (!evt) evt = window.event;
    return evt;
}
//Recupera o código da tecla que foi pressionado
function getKeyCode(evt) {
    var code;
    if (typeof (evt.keyCode) == 'number')
        code = evt.keyCode;
    else if (typeof (evt.which) == 'number')
        code = evt.which;
    else if (typeof (evt.charCode) == 'number')
        code = evt.charCode;
    else
        return 0;

    return code;
}
// limpa todos os caracteres especiais do campo solicitado
function filtraCampo(campo) {
    var s = "";
    var cp = "";
    vr = campo.value;
    tam = vr.length;
    for (i = 0; i < tam; i++) {
        if (vr.substring(i, i + 1) != "/"
            && vr.substring(i, i + 1) != "-"
            && vr.substring(i, i + 1) != "."
            && vr.substring(i, i + 1) != "("
            && vr.substring(i, i + 1) != ")"
            && vr.substring(i, i + 1) != ":"
            && vr.substring(i, i + 1) != ",") {
            s = s + vr.substring(i, i + 1);
        }
    }
    return s;   
}
