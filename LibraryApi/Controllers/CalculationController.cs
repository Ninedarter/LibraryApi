        using LibraryApi.Requests;
        using LibraryApi.Services;
        using Microsoft.AspNetCore.Cors;
        using Microsoft.AspNetCore.Mvc;

        namespace LibraryApi.Controllers
        {
            [Route("api/[controller]")]
            [ApiController]
            [EnableCors("CorsApi")]
            public class CalculationController : ControllerBase
            {

                private readonly CalculationService _calculationService;

                public CalculationController(CalculationService calculationService)
                {
                    _calculationService = calculationService;
                }

                [HttpPost("calculateTotal")]
                public double CalculateTotal(ReservationData request)
                {
                    return _calculationService.CalculateTotalAmount(request);
                }
            }
        }