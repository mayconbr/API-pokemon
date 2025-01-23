using Microsoft.AspNetCore.Mvc;
using Pokedex.Interfaces;
using Pokedex.Models;
using System.Diagnostics;

namespace Pokedex.Controllers
{
    public class TreinadorController : Controller
    {
        private readonly ITreinadorepository _treinadorRepository;

        public TreinadorController(ITreinadorepository treinadorepository)
        {
            _treinadorRepository = treinadorepository;
        }

        [HttpPost]
        [Route("CreateTreiandor")]
        public IActionResult InsertTreinador([FromBody] Pokemon request)
        {
            try
            {
                //if (request == null)
                //{
                //    return BadRequest("Dados inválidos enviados.");
                //}

                //var newPokemon = _treinadorRepository.InsertPokemon(request);

                //// Retorna o Pokémon criado com status 201
                //return CreatedAtAction(nameof(InsertPokemon), new { id = newPokemon.id }, newPokemon);
                return StatusCode(500, "Ocorreu um erro ao processar sua solicitação.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar Pokémon: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao processar sua solicitação.");
            }
        }

    }
}
