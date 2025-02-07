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
        [Route("CreateTrainer")]
        public IActionResult InsertTreinador([FromBody] Trainer request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Dados inv�lidos enviados.");
                }

                var newTrainer = _treinadorRepository.InsertTrainer(request);

                return Ok("Treinador criado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar Pok�mon: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao processar sua solicita��o.");
            }
        }


        [HttpPost]
        [Route("UpdateTrainer")]
        public IActionResult UpdateTreinador([FromBody] Trainer request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Dados inv�lidos enviados.");
                }



                var newTrainer = _treinadorRepository.InsertTrainer(request);

                return Ok("Treinador criado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar Pok�mon: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao processar sua solicita��o.");
            }
        }

    }
}
