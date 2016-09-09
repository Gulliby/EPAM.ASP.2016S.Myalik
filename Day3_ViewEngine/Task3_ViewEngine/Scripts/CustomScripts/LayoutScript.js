$(function () {
    $("#switchButton").click(switchFunction);

    function switchFunction(){
        if ($("#navbar").hasClass("navbar-inverse")) {
            alert("Sorry Darth Vader!")
        }
        else {
            $("#navbar").addClass("navbar-inverse");
        }
    }
});

function success(data) {
    $("#header-person").replaceWith(data);
}