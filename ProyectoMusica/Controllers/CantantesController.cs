using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoMusica.Helpers;
using ProyectoMusica.Models;
using ProyectoMusica.Repository;

namespace ProyectoMusica.Controllers
{
    [ApiController]
    [Route("api/cantante")]
    public class CantantesController : ControllerBase
    {
        private readonly IGenericRepository<Cantante> _cantanteRepo;

        public CantantesController(IGenericRepository<Cantante> cantanteRepo)
        {
            _cantanteRepo = cantanteRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCantantes()
        {
            var cantantes = await _cantanteRepo.GetAllAsync();
            return Ok(cantantes);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCantante(Cantante cantante)
        {
            var nuevo = await _cantanteRepo.AddAsync(cantante);
            return Ok(nuevo);
        }
    }

}
