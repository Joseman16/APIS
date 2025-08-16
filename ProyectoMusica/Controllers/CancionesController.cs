using Microsoft.AspNetCore.Mvc;
using ProyectoMusica.Helpers;
using ProyectoMusica.Models;
using ProyectoMusica.Repository;
using ProyectoMusica.Validators;

namespace ProyectoMusica.Controllers
{
    [ApiController]
    [Route("api/cancion")]
    public class CancionesController : ControllerBase
    {
        private readonly IGenericRepository<Cancion> _cancionRepo;

        public CancionesController(IGenericRepository<Cancion> cancionRepo)
        {
            _cancionRepo = cancionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCanciones()
        {
            var canciones = await _cancionRepo.GetAllAsync();
            return Ok(new ResponseHelper<object>
            {
                Success = true,
                Message = "Lista de canciones",
                Data = canciones
            });
        }

        [HttpPost]
        public async Task<IActionResult> CrearCancion( [FromBody]Cancion cancion)
        {
            if (!CancionValidator.EsValida(cancion))
                return BadRequest(new ResponseHelper<object>
                {
                    Success = false,
                    Message = "Datos inválidos"
                });

            var nuevaCancion = await _cancionRepo.AddAsync(cancion);
            return Ok(new ResponseHelper<Cancion>
            {
                Success = true,
                Message = "Canción creada correctamente",
                Data = nuevaCancion
            });
        }
    }

}
