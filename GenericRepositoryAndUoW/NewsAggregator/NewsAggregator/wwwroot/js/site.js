let loginRequest = new XMLHttpRequest();
//create request
loginRequest.open('GET', '/Account/UserInfo', true);
//create request handler
loginRequest.onload = function () {
    if (loginRequest.status >= 200 && loginRequest.status < 400) {
        let resp = loginRequest.responseText;
        document.getElementById('navbar-row').innerHTML += resp;
    }
}

//send request
loginRequest.send();