function GestionClickHL_Delete_Bkm(event, idbkm) {

    //cette ligne évite que le lien hypertext renvoie vers autre chose
    //event.preventDefault();
   
    DeleteBookmark(idbkm);

}

//gestion du clic sur le bouton create
function DeleteBookmark(idbkm) {

    console.log("passage dans la fonction DeleteBookmark");
    
    $.ajax({
        url: '/api/WebBookmarks/' + idbkm,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            console.log("la suppression s'est bien passée");
            setTimeout(function () { AppelSearchAll(); }, 1000)

        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });



}


