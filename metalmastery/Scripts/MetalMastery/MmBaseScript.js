function MetalMasteryViewModel() {
    this.email = ko.observable("");
    this.password = ko.observable("");

    this.logIn = function () {
        $.get('/user/login', { Email: this.email(), Password: this.password() }, function () {
            
        });
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
    ko.applyBindings(new MetalMasteryViewModel(), document.getElementById('user'));
    ko.applyBindings(new MetalMasteryViewModel2(), document.getElementById('userReg'));

    ModuleManager();
});

function ModuleManager() {
    this.Modules = [];
    var obj = this;
    init(this);
    draw(this);
   
    function init() {
        obj.Modules.push(new SignIn());
        obj.Modules.push(new News());
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
Module.prototype.writeLog = function(message) {
    window.console && console.log && console.log(message);
};
Module.prototype.destruct = function () {
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

        var block = $("form#" + obj.Form);
        if (block.is(":hidden")) {
            obj.Selected = true;
            block.slideDown("fast");
        } else {
            block.hide();
        }
    });
};

function SignIn() {
    Module.call(this, "SignIn");
    this.Text = MM.Res.get("EntranceTab");
    this.Form = "signin";
    this.Btn = "signin-btn";
    this.PersonalPanel = "personal-pan";
    this.BtnClass = "top-button";
    this.IsAuthenticated = false;
    this.IsAdmin = false;
    this.IsHideCenter = false;
    var obj = this;
    init();
    
    function init() {
        $.get('/user/isAuthenticate', {}, function (result) {
            if (result.Success && result.Data) {
                this.IsAuthenticated = result.Data.IsAuthenticated;
                this.IsAdmin = result.Data.IsAdmin;
                if (this.IsAuthenticated) {
                    obj.buildUserPanel();
                }
            }
        });       
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
    $("body").append("<div id='" + this.PersonalPanel + "' class='" + this.BtnClass + "'><span>Hi</span><input id='logout' type='button' value='LogOut2121'></div>");
    $('#' + this.PersonalPanel).live('click', function () {
        $.get('/user/logout', {});
        SignIn.base.build.call(obj);
    });
};

function News() {
    Module.call(this, "News");
    this.Text = MM.Res.get("NewsTab");
    this.Form = "news";
    this.Btn = "news-btn";
    this.BtnClass = "left-button";
}
News.prototype = new Module();
News.base = Module.prototype;

