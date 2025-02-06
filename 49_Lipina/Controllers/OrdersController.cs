using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using _49_Lipina.Context;
using _49_Lipina.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _49_Lipina.Controllers
{
    [ApiExplorerSettings(GroupName = "v4")]
    public class OrdersController : Controller
    {
        /// <summary>
        /// Метод для оформления заказа 
        /// </summary>
        /// <returns>Данный метод отправляет на сервер заказ</returns>
        /// /// <response code="200">Заказ принят</response>
        /// /// <response code="400">Проблемы при запросе</response>
        /// /// <response code="401">Неавторизованный доступ</response>
        [Route("order")]
        [HttpPost]
        [ProducesResponseType(typeof(Orders), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public ActionResult AddOrder([FromForm] string Address, [FromForm] string Date, [FromForm] int DishId, [FromForm] int Count, [FromForm] string Token)
        {
            if (Address == null || Date == null || DishId == 0 || Count == 0 || Token == null) return StatusCode(400);
            try
            {
                var newOrder = new OrdersContext();
                var findUserToken = new UsersContext();
                if (findUserToken.Users.FirstOrDefault(x => x.Token == Token) == null) return StatusCode(400, "Такого токена нету!");
                else
                {
                    Orders Order = new Orders()
                    {
                        Address = Address,
                        Date = Date,
                        DishId = DishId,
                        Count = Count
                    };
                    newOrder.Orders.Add(Order);
                    newOrder.SaveChanges();
                    return Json(Order);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Метод для получения истории 
        /// </summary>
        /// <returns>Данный метод отправляет на сервер заказ</returns>
        /// /// <response code="200">successful operation</response>
        /// /// <response code="400">Проблема при запросе</response>
        [Route("histories")]
        [HttpGet]
        [ProducesResponseType(typeof(Orders), 200)]
        [ProducesResponseType(400)]
        public ActionResult History()
        {
            IEnumerable<Orders> Order = new OrdersContext().Orders;
            return Json(Order);
        }
    }
}
