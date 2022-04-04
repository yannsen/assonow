/*Declaration of the function to validate the result of the multiplication of the number of tickets by the ticket price */


function onkeyupsum() { // calculate sum and show in textbox
    var nbr;
    var multiply = 1,
    

        multiply = Number(document.getElementById("TicketsNumber").value) * Number(document.getElementById("TicketPrice").value);

    document.getElementById("Amount").value = multiply;
}


function check() {
    var remainingticket = Number(document.getElementById("RemainingTicket").value);

    nbr = Number(document.getElementById("TicketsNumber").value);
    if (nbr > remainingticket) {
        alert("il reste seulement " + remainingticket + " billets");
        document.getElementById("submitbutton").disabled = true;
    } else {
        document.getElementById("submitbutton").disabled = false;
    }

}

