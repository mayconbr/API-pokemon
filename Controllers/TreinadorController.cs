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
                //    return BadRequest("Dados inv�lidos enviados.");
                //}

                //var newPokemon = _treinadorRepository.InsertPokemon(request);

                //// Retorna o Pok�mon criado com status 201
                //return CreatedAtAction(nameof(InsertPokemon), new { id = newPokemon.id }, newPokemon);
                return StatusCode(500, "Ocorreu um erro ao processar sua solicita��o.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar Pok�mon: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao processar sua solicita��o.");
            }
        }

    }
}
