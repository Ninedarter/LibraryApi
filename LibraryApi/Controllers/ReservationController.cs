using LibraryApi.Entities;
using LibraryApi.Requests;
using LibraryApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsApi")]
    public class ReservationController : ControllerBase
    {
        private readonly ValidationService _validationService;
        private readonly ReservationService _reservationService;


        public ReservationController(ValidationService validationService, ReservationService reservationService)
        {
            _validationService = validationService;         
            _reservationService = reservationService;
        }

        [HttpPost("makeReservation")]
        public async Task<IActionResult> MakeReservation(ReservationData request)
        {
            if (!_validationService.IsRequestValid(request))
            {
                return BadRequest(new { message = "Invalid reservation request data." });
            }

            var result = await _reservationService.MakeReservation(request);

            if (!result.IsSuccess)
            {
                return NotFound(new { message = result.Message });
            }
            return Ok(result);
        }

        [HttpGet("all")]
        public Task<List<Reservation>> GetAll()
        {
            return _reservationService.GetAll();
          
        }
    }
} 
