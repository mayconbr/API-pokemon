using Microsoft.AspNetCore.Mvc;
using Pokedex.Interfaces;
using Pokedex.Models;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonController(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    [HttpPost]
    [Route("CreatePokemon")]
    public IActionResult InsertPokemon([FromBody] Pokemon request)
    {
        try
        {
            if (request == null)
            {
                return BadRequest("Dados inv�lidos enviados.");
            }

            var newPokemon = _pokemonRepository.InsertPokemon(request);

            // Retorna o Pok�mon criado com status 201
            return CreatedAtAction(nameof(InsertPokemon), new { id = newPokemon.id }, newPokemon);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao criar Pok�mon: {ex.Message}");
            return StatusCode(500, "Ocorreu um erro ao processar sua solicita��o.");
        }
    }
}
