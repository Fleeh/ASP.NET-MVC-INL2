var nameError = document.getElementById('name-error');
var emailError = document.getElementById('email-error');
var messageError = document.getElementById('message-error');
var submitError = document.getElementById('submit-error');
var submitSuccess = document.getElementById('submit-success');



const btn = document.getElementById('buttonmoves');
btn.addEventListener('click', function handleClick(event) {
    event.preventDefault();

    const inputs = document.querySelectorAll('#firstnametest, #lastnametest, #floatingInputValue')
    inputs.forEach(input => {
        input.value = '';
    })
})



function validateName() {
    var name = document.getElementById('firstnametest').value;

    if (name.length == 0) {
        nameError.innerHTML = 'Name is required';
        return false;
    }
    if (!name.match(/^(([A-Za-z]+[\-\']?)*([A-Za-z]+)?\s)+([A-Za-z]+[\-\']?)*([A-Za-z]+)?$/)) {
        nameError.innerHTML = 'Write your full name';
        return false;
    }
    nameError.innerHTML = '<i class="fa-solid fa-badge-check"></i>';
    return true;
}



function validateEmail() {
    var email = document.getElementById('lastnametest').value;

    if (email.length == 0) {
        emailError.innerHTML = 'Email is required';
        return false;
    }
    if (!email.match(/^[A-Za-z\._\-[0-9]*[@][A-Za-z]*[\.][a-z]{2,4}$/)) {
        emailError.innerHTML = 'Invalid Email';
        return false;
    }
    emailError.innerHTML = '<i class="fa-solid fa-badge-check"></i>';
    return true;
}

function validateMessage() {
    var message = document.getElementById('floatingInputValue').value;
    var required = 20;
    var left = required - message.length;

    if (left > 0) {
        messageError.innerHTML = left + ' more characters required';
        return false;
    }

    messageError.innerHTML = '<i class="fa-solid fa-badge-check"></i>';
    return true;
}

function validateForm() {
    if (!validateName() || !validateEmail() || !validateMessage()) {
        submitError.style.display = 'block';
        submitError.innerHTML = 'You have not met the requirements';
        setTimeout(function () { submitError.style.display = 'none'; }, 7000);
        return false;
    }
    if (validateName() || validateEmail() || validateMessage()) {
        submitSuccess.style.display = 'block';
        submitSuccess.innerHTML = 'Thank you! we will respond as fast as possible';
        setTimeout(function () { submitSuccess.style.display = 'none'; }, 7000);
        return true;





    }
}
