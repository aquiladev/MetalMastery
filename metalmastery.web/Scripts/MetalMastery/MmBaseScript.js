if (!window.MM)
    MM = {};

MM.Notification = {
    Timers: [],
    pushTimer: function (timer) {
        if (this.Timers.length > 4) {
            clearTimeout(this.Timers[0]);
            this.Timers.splice(0, 1);
            $('#notifications').find("div").first().remove();
        }
        this.Timers.push(timer);
    },
    removeTimer: function (timer) {
        for (key in this.Timers) {
            if (this.Timers[key] == timer) {
                this.Timers.splice(key, 1);
                return;
            }
        }
    },
    show: function (message, type) {
        var obj = this;
        var errorBlock = $('#notifications');
        var timer = setTimeout(function () {
            errorBlock.find("div").first().remove();
            clearTimeout(timer);
            obj.removeTimer(timer);
        }, 3000);

        this.pushTimer(timer);

        errorBlock.append("<div class='" + type + "'>" + message + "</div>");
    }
};

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
    this.User = null;
    var obj = this;
    init();

    function init() {
        ko.applyBindings(new signInViewModel(), document.getElementById("signin"));
        ko.applyBindings(new signUpViewModel(), document.getElementById("signup"));

        $.get('/user/isAuthenticate', {})
            .success(function (result) {
                if (result.Success && result.Data) {
                    obj.IsAuthenticated = result.Data.IsAuthenticated;
                    obj.IsAdmin = result.Data.IsAdmin;
                    if (obj.IsAuthenticated) {
                        obj.User = result.Data.User;
                        obj.buildUserPanel();
                    }
                } else {
                    if (result.Errors.length > 0) {
                        for (key in result.Errors) {
                            MM.Notification.show(result.Errors[key], "error");
                        }
                    } else {
                        MM.Notification.show(MM.Res.get("UnhandledException"), "error");
                    }
                }
            })
            .error(function () {
                MM.Notification.show(MM.Res.get("UnhandledException"), "error");
            });

        $("#auth .close-btn").live('click', function() {
            obj.hide();
        });
    }

    function signInViewModel() {
        this.email = ko.observable("");
        this.password = ko.observable("");

        this.signIn = function () {
            $.get('/user/signIn', { Email: this.email(), Password: this.password() })
                .success(function (result) {
                    if (result === undefined)
                        return;
                    if (result.Success) {
                        obj.User = result.Data;
                        obj.buildUserPanel();
                    } else {
                        if (result.Errors.length > 0) {
                            for (key in result.Errors) {
                                MM.Notification.show(result.Errors[key], "error");
                            }
                        } else {
                            MM.Notification.show(MM.Res.get("UnhandledException"), "error");
                        }
                    }
                })
                .error(function () {
                    MM.Notification.show(MM.Res.get("UnhandledException"), "error");
                })
                .complete(function () {
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
                .success(function (result) {
                    if (result === undefined)
                        return;
                    if (result.Success) {
                        MM.Notification.show(MM.Res.get("RegistrationComplete"), "message");
                        obj.cleanForm();
                        obj.hide();
                    } else {
                        if (result.Errors.length > 0) {
                            for (key in result.Errors) {
                                MM.Notification.show(result.Errors[key], "error");
                            }
                        } else {
                            MM.Notification.show(MM.Res.get("UnhandledException"), "error");
                        }
                    }
                })
                .error(function () {
                    MM.Notification.show(MM.Res.get("UnhandledException"), "error");
                })
                .complete(function () {
                    $('#password, #pwd, #confirmPassword').val("");
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
    this.ArticleViewModel = null;
    var obj = this;
    init();

    function init() {
        obj.ArticleViewModel = new articleViewModel();
        ko.applyBindings(obj.ArticleViewModel, document.getElementById("articles"));
    }

    this.loadArticles = function (pageIndex, pageSize) {
        var vmmv = this.ArticleViewModel;
        $.get(
            '/Article/GetArticles',
            { 'pageIndex': pageIndex, 'pageSize': pageSize },
            function (result) {
                if (result.Success && result.Data) {
                    for (i in result.Data) {
                        if (result.Data[i]) {
                            vmmv.items.push(result.Data[i]);
                        }
                    }
                } else {
                    if (result.Errors.length > 0) {
                        for (key in result.Errors) {
                            MM.Notification.show(result.Errors[key], "error");
                        }
                    } else {
                        MM.Notification.show(MM.Res.get("UnhandledException"), "error");
                    }
                }
            });
    };

    function articleViewModel() {
        var self = this;
        self.items = ko.observableArray();
        self.chosenArticleData = ko.observable();

        self.goToArticle = function (article) {
            $.get('/Article/Details/' + article.Id, {}, self.chosenArticleData)
                .success(function () {
                    $('#articles .list').hide();
                    $('#articles .view-article').show();
                    if (DISQUS) {
                        DISQUS.reset({
                            reload: true,
                            config: function () {
                                this.page.identifier = "article-" + article.Id;
                                this.page.url = "http://mmua/#!A" + article.Id;
                            }
                        });
                        $("#comments").show();
                    }
                });
        };
        self.goToList = function () {
            $("#comments").hide();
            $('.dsq-tooltip-outer').remove();
            $('#articles .view-article').hide();
            $('#articles .list').show();

        };
    }
}
Articles.prototype = new Module();
Articles.base = Module.prototype;
Articles.prototype.build = function () {
    Articles.base.build.call(this);
    this.Items = [];
    this.loadArticles();
};
Articles.prototype.hide = function () {
    Articles.base.hide.call(this);
    $("#comments").hide();
};