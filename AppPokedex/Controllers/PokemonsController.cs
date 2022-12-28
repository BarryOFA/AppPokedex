using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPokedex.Controllers
{
    public class PokemonsController : Controller
    {
        // GET: Pokemons
        public ActionResult Index()
        {
            return View();
        }
    }
}