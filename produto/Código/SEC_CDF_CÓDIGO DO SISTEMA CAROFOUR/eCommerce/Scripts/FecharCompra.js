
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

    $("form#frmFecharCompra").submit(function (e) {        

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

    
