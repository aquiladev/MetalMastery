if (!window.MM)
	MM={};
MM.Res={
	"ConfirmPasswordErrorMessage": "Пароли не совпадают",
	"EmailLength": "Длина e-mail адреса превышает 256 символов",
	"EntranceTab": "Вход",
	"LoginPasswordInvalid": "Пользователя с такими логином и паролем не существует, или Вы допустили ошибку!",
	"NewsTab": "Почитать",
	"PasswordLength": "Длина пароля не должна быть менее 5 символов и превышать 32 символа",
	"RoleNotFound": "Ошибка во время создания пользователья, роль не найдена.",
	get: function(param) {
		return this[param] || param;
	}
};
