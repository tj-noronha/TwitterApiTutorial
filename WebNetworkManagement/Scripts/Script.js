window.onload = function () {
    document.getElementById("button1").onclick = function fun() {

        var email = document.getElementById("form_email");

        var button = document.getElementById("button1");
        button.style.display = "none";
        email.style.display = "none";

        var subscripbed = document.getElementById("subscribed");
        subscripbed.style.display = "block";
    }
}