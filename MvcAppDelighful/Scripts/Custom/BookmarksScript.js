//on crée un tableau (attention, il est rattaché au context global c'est à dire window
var ArrayKwSelected = new Array();

/*au chargement de la page , une fonction anonyme va être déclenchée
    cette fonction execute le fadeIn et abonne la méthode GestionClickKeyword
    à l'événement click de chaque élément html dont la class est keywordclass 
    (c'est à dire chaque lien hypertext correspondant à un mot clef)*/
$(document).ready(function () {
    $("#ListBookmarks").hide().fadeIn("slow");

    $(".keywordclass").click(GestionClickKeyword);

    //sur la perte de focus, on ajoute le mot clef à la liste des mots clefs sélectionné
    $("#SearchInput").blur(function () { gestionKeyWords($("#SearchInput").val()) });

});

//On déclare une fonction qui sera executée sur le click de chaque mot clef
function GestionClickKeyword(event) {

    //cette ligne évite que le lien hypertext renvoie vers autre chose
    event.preventDefault();

    //on vérifie que ce n'est pas le 9ième mot clef à être sélectionné
    if (ArrayKwSelected.length >= 8) {
        alert("Vous ne pouvez pas choisir plus de 8 mots clefs");
        return;
    }

    //on récupère le mot clef sur lequel on a cliqué et on le passe à la méthode
    gestionKeyWords($(this).text());

}

function gestionKeyWords(kwselected) {

    if (kwselected == "") { return; }
    //on recherche dans le tableau pour voir si le mot clef
    //avait déjà été sélectionné
    var index = ArrayKwSelected.indexOf(kwselected);

    if (index == -1) {
        ArrayKwSelected.push(kwselected); //on rajoute le mot clef dans le tableau des mots clefs sélectionné
        $("#keywords_selected").append("<div class=kw_selected>" + kwselected + "</div>");
    }
    else {
        //je ne suis pas sûr qu'en terme d'ergonomie l'alert soit à recommander
        alert("Ce mot clef a déjà été sélectionné");
        return;
    }

    //chaine permettant de stocker l'ensemble des mots clefs
    var str_listKeywords_selected = "";

    for (var z = 0; z < ArrayKwSelected.length; z++) {
        if (z == 0) {
            str_listKeywords_selected = ArrayKwSelected[0];
        }
        else {
            str_listKeywords_selected += "|" + ArrayKwSelected[z];
        }
    }

    $("#hf_keywords_selected").val(str_listKeywords_selected);



    if ($("#SearchInput").val() != "") {
        $("#SearchInput").val("");
    }
}