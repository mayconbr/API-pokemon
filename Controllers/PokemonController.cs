using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using System.Diagnostics;

namespace Pokedex.Controllers
{
    public class PokemonCrontroller : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public PokemonCrontroller(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

    }
}
