function GestionClickHL_Update_Bkm(event, idbkm) {

    //cette ligne évite que le lien hypertext renvoie vers autre chose
    //event.preventDefault();

    UpdateBookmark(idbkm);

}

//gestion du clic sur le bouton Update
function UpdateBookmark(idbkm) {

    console.log("passage dans la fonction UpdateBookmark");

    jQuery.support.cors = true;  //permet un appel crossdomain (ici ce n'est même pas la peine car on est sur le même domaine)
    
    var bookmark = { 
        Id: idbkm,
        Title: $('#TitleUpdate[data-bkm="' + idbkm + '"]').val(),
        Url: $('#UrlUpdate[data-bkm="' + idbkm + '"]').val(),
        Description: $('#DescriptionUpdate[data-bkm="' + idbkm + '"]').val()
    };

    console.log("voici ce qu'il y a dans le bookmark");
    console.log(bookmark);

    $.ajax({
        url: '/api/WebBookmarks',
        type: 'PUT',
        data: JSON.stringify(bookmark),
        contentType: "application/json;charset=utf-8",
        success: function (data, textStatus, jqXHR) {

            //attention depuis les web api 2, si l'utilisateur n'est pas authentifié on pas le code http 401 directement
            //il faut lire un http header pour voir

            //console.log(textStatus);

            var headerJSON = jqXHR.getResponseHeader('X-Responded-JSON');

            headerJSON = JSON.parse(headerJSON);

            if (headerJSON != null && headerJSON.status == "401")
            {
                
                alert("Vous devez vous authentifier pour réaliser cette action (et être admin)");
                window.document.location.href = "/Account/Login?ReturnUrl=%2FHome%2FAbout";
            }
            else
            {
                console.log("la modification s'est bien passée");
                var tr = $('tr[data-bkm="' + idbkm + '"]');
                $(tr).children('td').children('div').slideToggle('slow', 'swing');
                setTimeout( function () { AppelSearchAll(); }, 1000)
            }
        },
        statusCode: {
            
            400: function (jqxhr) {
                var validationResult = $.parseJSON(jqxhr.responseText);
                if (typeof window.console != "undefined") {
                    console.log("Les données saisies ne sont pas valides");
                    console.log(validationResult);
                }
                AffichageErreurs(validationResult);
            },
            //401: function () {
            //    alert("Vous devez vous authentifier pour réaliser cette action (et être admin)");
            //    window.document.location.href = "/Account/Login";
            //}

        }

    });

   

}


function AffichageErreurs(validationRes) {

    var i = 0;

    var msgErrors = " Les données saisies ne sont pas valides \n pour les raisons suivantes : \n";

    var modelState = validationRes["ModelState"];
    console.log("modelState");
    console.log(modelState);


    for (var property in modelState) {
        i++;

        //if (i != 1) {
            msgErrors += modelState[property];
            msgErrors += "\n";
        //}
    }

    alert(msgErrors);

}


//function AffichageErreurs(validationRes) {

//    var i = 0;

//    var msgErrors = " Les données saisies ne sont pas valides \n pour les raisons suivantes : \n";

//    for (var property in validationRes) {
//        i++;

//        if (i != 1) {
//            msgErrors += validationRes[property];
//            msgErrors += "\n";
//        }
//    }

//    alert(msgErrors);

//}


