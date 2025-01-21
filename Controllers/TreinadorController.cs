using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using System.Diagnostics;

namespace Pokedex.Controllers
{
    public class TreinadorController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public TreinadorController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

    }
}
