using Microsoft.AspNetCore.Mvc;
using Pokedex.Interfaces;
using Pokedex.Models;

public class PokemonController : Controller
{
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonController(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("CreatePokemon")]
    public IActionResult InsertPokemon([FromBody] Pokemon request)
    {
        try
        {
            if (request == null)
            {
                return BadRequest("Dados inválidos enviados.");
            }

            var newPokemon = _pokemonRepository.InsertPokemon(request);

            return CreatedAtAction(nameof(InsertPokemon), new { id = newPokemon.id }, newPokemon);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao criar Pokémon: {ex.Message}");
            return StatusCode(500, "Ocorreu um erro ao processar sua solicitação.");
        }
    }
}
