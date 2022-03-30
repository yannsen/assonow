/*Declaration of the function to validate the result of the multiplication of the number of tickets by the ticket price */


function onkeyupsum() { // calculate sum and show in textbox
  
    var sum = 0,
        amount = document.querySelectorAll('.amount'), i;
    for (i = 0; i < amount.length; i++) {
        sum += parseFloat(amount[i].value || 0);
    }
    document.submitform.tamt.value = sum;
}


function check() {
    var nbr;
    nbr = Number(document.getElementById("ticketsnumber").value);
    if (nbr > 10) {
        alert("il reste seulement X billets");
    }
    else {
        alert("ok");
    }
}