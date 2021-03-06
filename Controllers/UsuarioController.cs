using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            // construtor
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> GetAll() {
            return _context.usuario.ToList();
        }
        
        [HttpGet("{UsuarioId}")]
        public ActionResult<List<Usuario>> Get(int UsuarioId) 
        {
            try
            {
                var result = _context.usuario.Find(UsuarioId);
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
        public async Task<ActionResult> post(Usuario model)
        {
            try
            {
                _context.usuario.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    //return Ok();
                    return Created($"/api/usuario/{model.Id}",model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }

        [HttpPut("{UsuarioId}")]
        public async Task<IActionResult> put(int UsuarioId, Usuario dadosUsuarioAlt)
        {
            try {
                //verifica se existe aluno a ser alterado
                var result = await _context.usuario.FindAsync(UsuarioId);
                if (UsuarioId != result.Id)
                {
                    return BadRequest();
                }
                result.nomeUsuario = dadosUsuarioAlt.nomeUsuario;
                result.senhaUsuario = dadosUsuarioAlt.senhaUsuario;
                result.emailUsuario = dadosUsuarioAlt.emailUsuario;
                result.telefone = dadosUsuarioAlt.telefone;
                result.enderecoUsuario = dadosUsuarioAlt.enderecoUsuario;
                result.fotoUsuario = dadosUsuarioAlt.fotoUsuario;
                await _context.SaveChangesAsync();
                return Created($"/api/aluno/{dadosUsuarioAlt.Id}", dadosUsuarioAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("{UsuarioId}")]
        public async Task<ActionResult> delete(int UsuarioId)
        {
            try
            {
                //verifica se existe aluno a ser excluído
                var usuario = await _context.usuario.FindAsync(UsuarioId);
                if (usuario == null)
                {
                    //método do EF
                    return NotFound();
                }
                _context.Remove(usuario);
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