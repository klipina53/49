using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using _49_Lipina.Context;
using _49_Lipina.Models;
using System;
using System.Linq;

namespace _49_Lipina.Controllers
{
    [Route("api/auth")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UsersController : Controller
    {
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <remarks>Данный метод предназначен для регистрации пользователя на сайте</remarks>
        /// <response code="200">Успешная регистрация</response>
        /// <response code="400">Проблемы при регистрации</response>
        [Route("register")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(400)]
        public ActionResult RegIn([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null || Password == null)
                return StatusCode(400);

            try
            {

                UsersContext usersContext = new UsersContext();
                Users User = new Users()
                {
                    Login = Login,
                    Password = Password
                };

                if (usersContext.Users.Where(x => x.Login == Login).Count() != 0)
                    return StatusCode(400);

                usersContext.Add(User);
                usersContext.SaveChanges();

                return Json(User);
            }
            catch (Exception exp)
            {
                return StatusCode(400, exp.Message + " " + exp.InnerException);
            }
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <remarks>Данный метод предназначен для авторизации пользователя на сайте</remarks>
        /// <response code="200">Успешная аутентификация</response>
        /// <response code="400">Проблема аутентификации</response>
        /// <response code="401">Пользователь не найден</response>
        [Route("login")]
        [HttpPost]
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public ActionResult SignIn([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null || Password == null)
                return StatusCode(400);

            try
            {
                UsersContext userContext = new UsersContext();
                Users User = userContext.Users.Where(x => x.Login == Login && x.Password == Password).First();

                if (User != null)
                {
                    User.Token = GenerateToken();
                    userContext.SaveChanges();
                    token = User.Token;
                    return Json(User.Token);
                }
                else
                    return StatusCode(401);
            }
            catch (Exception exp)
            {

                return StatusCode(400);
            }
        }
        private static readonly Random _random = new Random();
        private static readonly string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public static string token;

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
        public static string GenerateToken(int length = 10)
        {
            var token = new char[length];
            for (int i = 0; i < length; i++)
            {
                token[i] = _chars[_random.Next(0, _chars.Length)];
            }
            return new string(token);
        }
    }
}
