var painel = new Object();

painel.ListarSenhas = function () {
    $.ajax({
        type: "POST",
        timeout: 50000,
        url: "/api/ListarSenhas",
        async: true,

        success: function (jsonRetornado) {
            if (jsonRetornado.senha != null && jsonRetornado.senha != undefined) {

                var senhaAntiga = $("#senha").text();
                if (senhaAntiga != jsonRetornado.senha.senha)
                    $("#notificacao").trigger('play');

                $("#senha").text(jsonRetornado.senha.senha);
                $("#guiche").text(jsonRetornado.senha.guiche);
            }

            if (jsonRetornado.senhas != null && jsonRetornado.senhas != undefined) {
                $("#senhasChamadas").html("");

                jsonRetornado.senhas.forEach(function (item) {

                    var span = $("<span>", {
                        class: 'senha-chamada-alinhada'
                    });

                    span.text("Senha: " + item.senha + "-" + "Guichê : " + item.guiche);

                    $("#senhasChamadas").append(span);
                });
            }
        }
    });

    setTimeout(painel.ListarSenhas, 2000);
}

$(function () {
    painel.ListarSenhas();
})