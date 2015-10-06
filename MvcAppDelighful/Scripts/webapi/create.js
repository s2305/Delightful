$(function () {
    
    $("#dialog").dialog({
        autoOpen: false,
        height: 500,
        width: 400,
        modal: true,
        buttons: {
            "Create": CreateBookmark,
            "Cancel": function () {
                $(this).dialog("close");
            }
        },
        close: function () {
            console.log("la fenêtre de dialogue vient d'être fermée");
            window.setTimeout(function () {
                AppelSearchAll();
            }, 500);
           
        }
    });


    //gestion de l'ouverture du dialog form
    $("#btCreate").click(
        function () {
          
            $("#dialog").dialog({ width: 800 });
            $('#dialog').dialog('open');
            return false;
        });


    //gestion du clic sur le bouton create
    function CreateBookmark() {

        console.log("passage dans la fonction CreateBookmark");
          
        //création de l'objet JS correspondant au bookmark à créer
        var bookmark = {
            Id: $('#Id').val(),
            Title: $('#Title').val(),
            Description: $('#Description').val(),
            Url: $('#Url').val(),
            Keywords: [
            {'Word': $('#Keywords_0__Word').val()},
            {'Word': $('#Keywords_1__Word').val()},
            { 'Word': $('#Keywords_2__Word').val() }]
        };

        console.log("bookmark");
        console.log(bookmark);

        $.ajax({
            url: '/api/WebBookmarks',
            type: 'POST',
            data: JSON.stringify(bookmark),
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                console.log("l'enregistrement s'est bien passé");
                $('#dialog').dialog('close');
            },
            //statusCode: { 400: function () { alert("Les données à enregistrer ne sont pas valides"); } }
            statusCode: {
                //400: function (jqxhr) {
                //    var validationResult = $.parseJSON(jqxhr.responseText);
                //    var form = $("#toto");
                //    console.log(form);
                //        $.validator.unobtrusive.validate(form, validationResult);}  }
                400: function (response) {
                    var form = $("#toto");
                    console.log("toto");
                    console.log(form);
                    var validationErrors = $.parseJSON(response.responseText);
                    $.each(validationErrors.ModelState, function (i, ival) {
                        remoteErrors(form, i, ival);
                    }

                    )
                },
                401: function () {
                    alert("Vous devez vous authentifier pour réaliser cette action (et être admin)");
                    window.document.location.href = "/Account/Login";
                }
            }
        });
        
        //$(this).dialog("close");

    }

});


function remoteErrors(jForm, name, errors) {
    
    console.log("remoteErrors");
    console.log(name);
    console.log(errors);

    function inner_ServerErrors(name, elements) {
        var ToApply = function () {
            for (var i = 0; i < elements.length; i++) {
                var currElement = elements[i];
                var currDom = $('#' + name.split('.')[1]);
                if (currDom.length == 0) continue;
                var currForm = currDom.parents('form').first();
                if (currForm.length == 0) continue;

                if (!currDom.hasClass('input-validation-error'))
                    currDom.addClass('input-validation-error');
                var currDisplay = $(currForm).find("[data-valmsg-for='" + name.split('.')[1] + "']");
                if (currDisplay.length > 0) {
                    currDisplay.removeClass("field-validation-valid").addClass("field-validation-error");
                    if (currDisplay.attr("data-valmsg-replace") !== false) {
                        currDisplay.empty();
                        currDisplay.text(currElement);
                    }
                }
            }
        };
        setTimeout(ToApply, 0);
    }

    jForm.find('.input-validation-error').removeClass('input-validation-error');
    jForm.find('.field-validation-error').removeClass('field-validation-error').addClass('field-validation-valid');
    var container = jForm.find("[data-valmsg-summary=true]");
    list = container.find("ul");
    list.empty();
    if (errors && errors.length > 0) {
        $.each(errors, function (i, ival) {
            $("<li />").html(ival).appendTo(list);
        });
        container.addClass("validation-summary-errors").removeClass("validation-summary-valid");
        inner_ServerErrors(name, errors);
        setTimeout(function () { jForm.find('span.input-validation-error[data-element-type]').removeClass('input-validation-error') }, 0);
    }
    else {
        container.addClass("validation-summary-valid").removeClass("validation-summary-errors");
    }
}

function clearErrors(jForm) {
    remoteErrors(jForm, []);
}