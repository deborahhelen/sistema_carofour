
$(document).ready(function () {

    $(".selectAll").click(function () {

        $("input:checkbox:not(#marcarTodos)").each(function () {
            if ($(this).is(':checked')) {
                $(this).prop("checked", false);
            }
            else {
                $(this).prop("checked", true);
            }
        });
    });

    $(".lnk").click(function () {

        var listItem = $(this);
        var index = $("a#lnk").index(listItem);
        var qtde = $("input[type=text]").eq(index).val();

        var linkParams = $("a#lnk").eq(index).prop("href").replace("value", qtde);

        $("a#lnk").eq(index).removeAttr("href");
        $("a#lnk").eq(index).prop("href", linkParams);
    });

    $("form#frmFecharComprabtnFecharCompra").submit(function (e) {

        var valido = true;
        var msg = "";
        var countNullQtde = 0;

        $("input#_Quantidade").each(function (e) {

            if ($(this).val() == "" || $(this).val() == 0) {

                countNullQtde++;
            }
        });

        if (countNullQtde > 0) {
            msg += "Informe a quantidade dos ítens\n";
            valido = false;
        }

        if ($("input#_Quantidade").length < 1) {

            valido = false;
            msg += "Não ha nenhum produto na lista para compra\n";
        }

        if (!valido) {

            alert(msg);
            e.preventDefault();
        }
    });

    $("#frmEnviaCliente").submit(function (e) {

        var strMsg = '';

        if ($("#_NomeCompleto").val() == "") {
            strMsg += 'Informe o nome\n';
        }

        if ($("#_DataNascimento").val() == "") {
            strMsg += 'Informe a data nascimento\n';
        }
        else {
            if (!ValidaData($("#_DataNascimento").val()))
                strMsg += 'Data de nascimento inválida\n';
        }

        if ($("#_Email").val() == "") {
            strMsg += 'Informe o email\n';
        }       

        if ($("#_Senha").val() == "") {
            strMsg += 'Informe a senha\n';
        }

        if ($("#_Endereco").val() == "") {
            strMsg += 'Informe o endereço\n';
        }

        if ($("#_Telefone").val() == "") {
            strMsg += 'Informe o telefone de contato\n';
        }

        if (strMsg != "") {

            alert(strMsg);

            e.preventDefault();
        }

    });

    $("#_DataNascimento").setMask("99/99/9999");
    $("#_Telefone").setMask("(99)9999-9999");
})

function ValidaData(_Data) {
    
    var bissexto = 0;
    var data = _Data;
    var tam = data.length;
    if (tam == 10) {
        var dia = data.substr(0, 2)
        var mes = data.substr(3, 2)
        var ano = data.substr(6, 4)
        if ((ano > 1900) || (ano < 2100)) {
            switch (mes) {
                case '01':
                case '03':
                case '05':
                case '07':
                case '08':
                case '10':
                case '12':
                    if (dia <= 31) {
                        return true;
                    }
                    break

                case '04':
                case '06':
                case '09':
                case '11':
                    if (dia <= 30) {
                        return true;
                    }
                    break
                case '02':
                    /* Validando ano Bissexto / fevereiro / dia */
                    if ((ano % 4 == 0) || (ano % 100 == 0) || (ano % 400 == 0)) {
                        bissexto = 1;
                    }
                    if ((bissexto == 1) && (dia <= 29)) {
                        return true;
                    }
                    if ((bissexto != 1) && (dia <= 28)) {
                        return true;
                    }
                    break
            }
        }
    }
    return false;
}


