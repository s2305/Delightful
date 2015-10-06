/// <reference path="jquery-1.7.1.intellisense.js" />
/// <reference path="jquery-ui-1.8.20.js" />

$(document).ready(gestion_autocomplete);

function gestion_autocomplete() {
   
    $("input[data-autocomplete]").each(
           function () {
            $(this).autocomplete(
                { source: $(this).attr("data-autocomplete") })
           }
        );
}

