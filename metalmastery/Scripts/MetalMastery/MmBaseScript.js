function MetalMasteryViewModel() {
    this.email = ko.observable("");
    this.password = ko.observable("");

    this.logIn = function () {
        $.get('/user/login', { Email: this.email(), Password: this.password() }, function () { alert("ss"); });
    };
}
function MetalMasteryViewModel2() {
    this.email = ko.observable("");
    this.password = ko.observable("");
    this.confirmPassword = ko.observable("");

    this.logOn = function () {
        $.get('/user/logon', { Email: this.email(), Password: this.password(), ConfirmPassword: this.confirmPassword() });
    };
}

$(document).ready(function () {
    $('#logout').click(function () {
        $.get('/user/logout', {}, function () { alert("--"); });
    });
    ko.applyBindings(new MetalMasteryViewModel(), document.getElementById('user'));
    ko.applyBindings(new MetalMasteryViewModel2(), document.getElementById('userReg'));
});
