$(document).ready(function () {
    $("#times-cards").css({
        "display": "none"
    })


    $(".card-link").click(function () {
        $("#times-cards").css({
            "display": "block"
        })
        $("#courts-cards").css({
            "display": "none"
        })
    })


})