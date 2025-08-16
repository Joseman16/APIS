using Microsoft.AspNetCore.Mvc;
using ProyectoMusica.Helpers;
using ProyectoMusica.Models;
using ProyectoMusica.Repository;

namespace ProyectoMusica.Controllers
{
    [ApiController]
    [Route("api/genero")]
    public class GenerosController : ControllerBase
    {
        private readonly IGenericRepository<Genero> _generoRepo;

        public GenerosController(IGenericRepository<Genero> generoRepo)
        {
            _generoRepo = generoRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetGeneros()
        {
            var generos = await _generoRepo.GetAllAsync();
            return Ok(new ResponseHelper<object>
            {
                Success = true,
                Message = "Lista de géneros",
                Data = generos
            });
        }

        [HttpPost]
        public async Task<IActionResult> CrearGenero([FromBody]Genero genero)
        {
            if (string.IsNullOrWhiteSpace(genero.Nombre))
                return BadRequest(new ResponseHelper<object>
                {
                    Success = false,
                    Message = "Nombre del género requerido"
                });

            var nuevoGenero = await _generoRepo.AddAsync(genero);
            return Ok(new ResponseHelper<Genero>
            {
                Success = true,
                Message = "Género creado correctamente",
                Data = nuevoGenero
            });
        }
    }


}
