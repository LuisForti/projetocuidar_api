using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCuidar_API.Data;
using ProjetoCuidar_API.Models;

namespace ProjetoCuidar_API.Controllers
{
    [Route("api/UsuarioPet")]
    [ApiController]
    public class UsuarioPetController : Controller
    {
        private readonly CuidarContext _context;
        public UsuarioPetController(CuidarContext context)
        {
            // construtor
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<UsuarioPet>> GetAll() {
            return _context.usuarioPet.ToList();
        }
        
        [HttpGet("{UsuarioPetId}")]
        public ActionResult<List<UsuarioPet>> Get(int UsuarioPetId) 
        {
            try
            {
                var result = _context.usuario.Find(UsuarioPetId);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> post(UsuarioPet model)
        {
            try
            {
                _context.usuarioPet.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    //return Ok();
                    return Created($"/api/usuarioPet/{model.Id}",model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }

        [HttpPut("{UsuarioPetId}")]
        public async Task<IActionResult> put(int UsuarioPetId, UsuarioPet dadosUsuarioPetAlt)
        {
            try {
                //verifica se existe aluno a ser alterado
                var result = await _context.usuarioPet.FindAsync(UsuarioPetId);
                if (UsuarioPetId != result.Id)
                {
                    return BadRequest();
                }
                result.idUsuario = dadosUsuarioPetAlt.idUsuario;
                result.idPet = dadosUsuarioPetAlt.idPet;
                result.dataDeAdocao = dadosUsuarioPetAlt.dataDeAdocao;
                await _context.SaveChangesAsync();
                return Created($"/api/usuarioPet/{dadosUsuarioPetAlt.Id}", dadosUsuarioPetAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("{UsuarioPetId}")]
        public async Task<ActionResult> delete(int UsuarioPetId)
        {
            try
            {
                //verifica se existe aluno a ser excluído
                var usuarioPet = await _context.usuarioPet.FindAsync(UsuarioPetId);
                if (usuarioPet == null)
                {
                    //método do EF
                    return NotFound();
                }
                _context.Remove(usuarioPet);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu deletar
            return BadRequest();
        }
    }
}