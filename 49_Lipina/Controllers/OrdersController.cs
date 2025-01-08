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
        public ActionResult Order([FromForm] string token, [FromForm] string address, [FromForm] int DishId, [FromForm] int count)
        {
            if (!String.Equals(token, UsersController.token)) return StatusCode(401);

            OrdersContext Context = new OrdersContext();

            Orders orders = new Orders()
            {
                Address = address,
                Date = DateTime.Now.ToString(),
                DishId = DishId,
                Count = count
            };

            Context.Orders.Add(orders);
            Context.SaveChanges();
            return Json(orders);
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
