using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaIngresoblibliotecario.Core.DTOs;
using PruebaIngresoblibliotecario.Core.Entities;
using PruebaIngresoblibliotecario.Core.Exceptions;
using PruebaIngresoblibliotecario.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;
        private readonly IMapper _mapper;
        private readonly ILogger<PrestamoController> _logger;

        public PrestamoController(IPrestamoService prestamoService, IMapper mapper, ILogger<PrestamoController> logger)
        {
            _prestamoService = prestamoService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Prestamo>> GetPrestamos() => Ok(await _prestamoService.GetAllAsync());

        [HttpGet("{idPrestamo}")]
        public async Task<IActionResult> GetprestamoById(Guid idPrestamo)
        {
            var response = await _prestamoService.GetByIdAsync(idPrestamo);
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound(new { Mensaje = $"El prestamo con id {idPrestamo} no existe" });
        }


        [HttpPost]
        public async Task<ActionResult> CrearPrestamo(PrestamoDTO prestamoDTO)
        {
            try
            {
                Prestamo prestamo = _mapper.Map<Prestamo>(prestamoDTO);
                var response = await _prestamoService.CreateAsync(prestamo);
                return Ok(new { Id = response.Id, FechaMaximaDevolucion = prestamo.FechaMaximaDevolucion.ToShortDateString() });

            }
            catch (ExistePrestamoException ex)
            {
                return BadRequest(new { Mensaje = ex.Message });
            }
            catch (System.Exception)
            {
                return BadRequest();
            }

        }        

    }
}
