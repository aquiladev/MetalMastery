$(document).ready(function () {
    ModuleManager();
});

function ModuleManager() {
    this.Modules = [];
    var obj = this;
    init(this);
    draw(this);

    function init() {
        obj.Modules.push(new SignIn());
        obj.Modules.push(new Articles());
    }
    function draw() {
        for (key in obj.Modules) {
            obj.Modules[key].build();
            obj.Modules[key].initHandler(preEventHandle);
        }
    }
    function preEventHandle(module) {
        hideAll();
        if (module.IsHideCenter || module.IsHideCenter === undefined) {
            $(".center").hide();
        } else {
            $(".center").show();
        }
    }
    function hideAll() {
        for (key in obj.Modules) {
            obj.Modules[key].hide();
        }
    }
}

function Module(name) {
    this.Name = name;
    this.Selected = false;
}
Module.prototype.hide = function () {
    this.Selected = false;
    $('#' + this.Form).hide();
};
Module.prototype.writeLog = function (message) {
    window.console && console.log && console.log(message);
};
Module.prototype.destruct = function () {
    this.Selected = false;
    $('#' + this.Btn).remove();
    $('#' + this.Form).hide();
};
Module.prototype.build = function () {
    this.destruct();
    $("body").append("<div id='" + this.Btn + "' class='" + this.BtnClass + "'><div>" + this.Text + "</div></div>");
};
Module.prototype.initHandler = function (preEventHandler) {
    var obj = this;
    var preEvHandler = preEventHandler;
    $("#" + this.Btn).live("click", function () {
        if (obj.Selected)
            return;

        if (preEvHandler != undefined
            && typeof preEvHandler === 'function')
            preEvHandler(obj);

        var block = $("#" + obj.Form);
        if (block.is(":hidden")) {
            obj.Selected = true;
            block.show();
        } else {
            block.hide();
        }
    });
};

function SignIn() {
    Module.call(this, "SignIn");
    this.Text = MM.Res.get("EntranceTab");
    this.Form = "auth";
    this.Btn = "signin-btn";
    this.PersonalPanel = "personal-pan";
    this.BtnClass = "top-button";
    this.IsAuthenticated = false;
    this.IsAdmin = false;
    this.IsHideCenter = false;
    this.User;
    var obj = this;
    init();

    function init() {
        ko.applyBindings(new signInViewModel(), document.getElementById("signin"));
        ko.applyBindings(new signUpViewModel(), document.getElementById("signup"));

        $.get('/user/isAuthenticate', { })
            .success(function(result) {
                if (result.Success && result.Data) {
                    obj.IsAuthenticated = result.Data.IsAuthenticated;
                    obj.IsAdmin = result.Data.IsAdmin;
                    if (obj.IsAuthenticated) {
                        obj.User = result.Data.User;
                        obj.buildUserPanel();
                    }
                }
            })
            .error(function() { alert("error"); });
    }
    
    function signInViewModel() {
        this.email = ko.observable("");
        this.password = ko.observable("");

        this.signIn = function () {
            $.get('/user/signIn', { Email: this.email(), Password: this.password() })
                .success(function(result) {
                    if (result === undefined)
                        return;
                    if (result.Success) {
                        obj.User = result.Data;
                        obj.buildUserPanel();
                    } else {
                        alert('error');
                    }
                })
                .error(function() { alert("error"); })
                .complete(function() {
                    obj.cleanForm();
                });
        };
    }

    function signUpViewModel() {
        this.email = ko.observable("");
        this.password = ko.observable("");
        this.confirmPassword = ko.observable("");

        this.signUp = function () {
            $.get('/user/signup', { Email: this.email(), Password: this.password(), ConfirmPassword: this.confirmPassword() })
                .success(function(result) {
                    if (result === undefined)
                        return;
                    if (result.Success) {
                        obj.User = result.Data;
                        obj.buildUserPanel();
                    } else {
                        alert('error');
                    }
                })
                .error(function() { alert("error"); })
                .complete(function() {
                    obj.cleanForm();
                });
        };
    }
}
SignIn.prototype = new Module();
SignIn.base = Module.prototype;
SignIn.prototype.build = function (preEventHandler) {
    if (this.IsAuthenticated) {
        this.buildUserPanel();
    }
    else {
        SignIn.base.build.call(this, preEventHandler);
    }
};
SignIn.prototype.buildUserPanel = function () {
    var obj = this;
    this.destruct();
    var body = $("body");
    body.find("#" + this.PersonalPanel).remove();
    body.append("<div id='" + this.PersonalPanel + "' class='" + this.BtnClass + "'><span>" + MM.Res.get("WelcomePrefix") + " " + obj.User + "</span><div id='signout'>" + MM.Res.get("Exit") + "</div></div>");
    $('#signout').live('click', function () {
        $.get('/user/signOut', {});
        body.find("#" + this.PersonalPanel).remove();
        SignIn.base.build.call(obj);
    });
};
SignIn.prototype.cleanForm = function () {
    $('#email, #password, #pwd, #confirmPassword').val("");
};

function Articles() {
    Module.call(this, "Articles");
    this.Text = MM.Res.get("ArticlesTab");
    this.Form = "articles";
    this.Btn = "articles-btn";
    this.BtnClass = "left-button";
    this.Items = [];

    this.loadArticles = function (pageIndex, pageSize) {
        var items = this.Items;
        $.get(
            '/Article/GetArticles',
            { 'pageIndex': pageIndex, 'pageSize': pageSize },
            function (result) {
                if (result.Success && result.Data) {
                    for (i in result.Data) {
                        if (result.Data[i]) {
                            items.push(result.Data[i]);
                        }
                    }
                }
            });
    };

    this.drawArticles = function () {
        var list = $("form#" + this.Form + " > ul");
        list.empty();
        for (i in this.Items) {
            if (this.Items[i]) {
                list.append("<li><a href='#'><div></div><h3>" + this.Items[i].Title + "</h3><p>" + this.Items[i].Text + "</p></a></li>");
            }
        }
    };
}
Articles.prototype = new Module();
Articles.base = Module.prototype;
Articles.prototype.build = function () {
    Articles.base.build.call(this);
    this.Items = [];
    this.loadArticles();
};
Articles.prototype.initHandler = function (preEventHandler) {
    var obj = this;
    Articles.base.initHandler.call(this, preEventHandler);
    $("#" + this.Btn).live("click", function () {
        obj.drawArticles();
    });
}