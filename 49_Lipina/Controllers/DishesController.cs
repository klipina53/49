using Microsoft.AspNetCore.Mvc;
using _49_Lipina.Context;
using _49_Lipina.Models;
using System.Collections.Generic;
using System.Linq;

namespace _49_Lipina.Controllers
{
    [Route("dishes")]
    public class DishesController : Controller
    {
        /// <summary>
        /// Список версий
        /// </summary>
        /// <returns>Данный метод предназначен для получения списка версий</returns>
        /// /// <response code="200">successful operation</response>
        /// /// <response code="400">Проблемы при запросе</response>
        [Route("version")]
        [HttpGet]
        [ApiExplorerSettings(GroupName = "v2")]
        [ProducesResponseType(typeof(List<Versions>), 200)]
        [ProducesResponseType(400)]
        public ActionResult ListVersion()
        {
            List<string> Versions = new VersionsContext().Versions.Select(x => x.Version).ToList();
            return Json(Versions);
        }

        /// <summary>
        /// Получить список блюд
        /// </summary>
        /// <param name="Version">Номер версии</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Проблемы при запросе</response>
        [Route("")]
        [HttpGet]
        [ApiExplorerSettings(GroupName = "v3")]
        [ProducesResponseType(typeof(List<Dishes>), 200)]
        [ProducesResponseType(400)]
        public ActionResult Dishes(int Version)
        {
            IEnumerable<Dishes> Dishes = new DishesContext().Dishes.Where(x => x.Version == Version);
            return Json(Dishes);
        }
    }
}
