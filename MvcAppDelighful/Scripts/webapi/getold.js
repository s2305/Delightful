$(document).ready(function () {

    //abonnement à l'événement click du bouton qui recherche tous les bookmarks
    $("#btsearchall").click(function () { AppelSearchAll(); });

    $("#btsearchbyid").click(function () { AppelSearchById(); });

    viewModel = {
        bookmarks: ko.observableArray([])
    };
    
    //on exprime par cette ligne le fait que l'objet nommé viewModel
    //fait l'objet de la liaison de données (databinding)
    ko.applyBindings(viewModel);

});

function AppelSearchAll() {
    $.get("/api/webbookmarks", "", MethSuccessSearchAll);
}

function AppelSearchById() {
    $.get("/api/webbookmarks/" + $("#idbkm").val(), "", MethSuccessSearchAll);
}

function MethSuccessSearchAll(data) {

    console.log("on met à jour le viewmodel");
    viewModel.bookmarks([]);
    viewModel.bookmarks(data);
   
    //on rattache une methode au bouton de chaque ligne
    //elle permet de faire apparaitre les champs qui vont permettre de faire la modification
    $(".btUpdate").click(GestionClickBtShowUpdate);

    $(".btDelete").click(function () { GestionClickHL_Delete_Bkm(event, $(this).attr("data-bkm")) });

}


function GestionClickBtShowUpdate() {

    //on récupère l'id du bookmark correspondant au bouton sur lequel on a cliqué
    var idbkm = $(this).attr("data-bkm");

    //on cherche la ligne qui correspond à cet identifiant
    var $tr = $('tr[data-bkm="' + idbkm + '"]');
    
    //$tr.show();
    $tr.slideToggle('slow', 'swing');
    

    //on rattache une méthod à chaque bouton qui permettra de réellement faire la mise à jour
    $('a[data-bkm="' + idbkm + '"]').click(function () { GestionClickHL_Update_Bkm(event, idbkm) });

}