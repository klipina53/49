namespace _49_Lipina.Models
{
    public class Users
    {
        public int Id { get; set; }

        /// <summary> Логин пользователя
        public string Login {  get; set; }

        /// <summary> Пароль пользователя
        public string Password { get; set; }

        /// <summary> Токен пользователя
        public string Token { get; set; }
    }
}
