// Write your JavaScript code.

window.setTimeout(function () {
    $("#confirmationMssg").fadeTo(500, 0)
        .slideUp(500, function () {
            $(this).remove();
        });
},
    1500);
