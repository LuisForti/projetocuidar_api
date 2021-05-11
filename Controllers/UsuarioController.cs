using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoCuidar_API.Data;
using ProjetoCuidar_API.Models;

namespace ProjetoCuidar_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly CuidarContext _context;
        public UsuarioController(CuidarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> GetAll()
        {
            return _context.Usuario.ToList();
        }
    }
}