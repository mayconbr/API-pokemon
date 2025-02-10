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
                    return BadRequest("Dados inválidos enviados.");
                }

                var newTrainer = _treinadorRepository.InsertTrainer(request);

                return Ok("Treinador criado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar treinador: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao processar sua solicitação.");
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
                    return BadRequest("Dados inválidos enviados.");
                }



                var newTrainer = _treinadorRepository.UpdateTrainer(request);

                return Ok("Treinador criado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar treinador: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao processar sua solicitação.");
            }
        }

        [Route("DeleteTrainer")]
        public async Task<IActionResult> DeleteTreinador(long id)
        {
            try
            {
                return (IActionResult) await _treinadorRepository.DeleteTrainer(id); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar Treinador: {ex.Message}");
                return StatusCode(500, "Ocorreu um erro ao processar sua solicitação.");
            }
        }


    }
}
