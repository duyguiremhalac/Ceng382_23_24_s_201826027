function centerForm() {
    var form = document.getElementById("generalApp");
    form.style.position = "fixed";
    form.style.top = "50%";
    form.style.left = "50%";
    form.style.transform = "translate(-50%, -50%)";
}

window.onload = function() {
    centerForm();
};

function toggleFunc() {
    var elementsToToggle = document.getElementById('elementsToToggle');
    if (elementsToToggle.style.display === 'none') {
        elementsToToggle.style.display = 'block';
    } else {
        elementsToToggle.style.display = 'none';
    }
};
function calculateFunc() {
    var element1  = document.getElementById("element1").value;
    var element2  = document.getElementById("element2").value;
    var calculateResult = document.getElementById('calculateResult');

    if (!(element1)) element1=0;
    if (!(element2)) element2=0;

    var result  = addNumbers(element1, element2);

    document.getElementById("resultField").value = "  \nThe sum of "+element1 +" + "+element2+" equals: " + result;
    
    if (calculateResult.style.display === 'none') {
        calculateResult.style.display = 'block';
    }
};

function addNumbers(n1, n2) {
   return parseFloat(n1) + parseFloat(n2);
};

