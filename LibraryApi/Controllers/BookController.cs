using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryApi.Entities;
using LibraryApi.Data;
using Microsoft.AspNetCore.Cors;
namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsApi")]
    public class BookController : ControllerBase
    {
        private readonly ApiContext _context;

        public BookController(ApiContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(Ok(_context.Books.ToList()));
        }
    }
}
