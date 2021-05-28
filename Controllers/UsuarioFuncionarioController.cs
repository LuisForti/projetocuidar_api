using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCuidar_API.Data;
using ProjetoCuidar_API.Models;

namespace ProjetoCuidar_API.Controllers
{
    [Route("api/UsuarioFuncionario")]
    [ApiController]
    public class UsuarioFuncionarioController : Controller
    {
        private readonly CuidarContext _context;
        public UsuarioFuncionarioController(CuidarContext context)
        {
            // construtor
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<UsuarioFuncionario>> GetAll() {
            return _context.usuarioFuncionario.ToList();
        }
        
        [HttpGet("{UsuarioFuncionarioId}")]
        public ActionResult<List<UsuarioFuncionario>> Get(int UsuarioFuncionarioId) 
        {
            try
            {
                var result = _context.usuarioFuncionario.Find(UsuarioFuncionarioId);
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
        public async Task<ActionResult> post(UsuarioFuncionario model)
        {
            try
            {
                _context.usuarioFuncionario.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    //return Ok();
                    return Created($"/api/usuarioFuncionario/{model.Id}",model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }

        [HttpPut("{UsuarioFuncionarioId}")]
        public async Task<IActionResult> put(int UsuarioFuncionarioId, UsuarioFuncionario dadosUsuarioFuncionarioAlt)
        {
            try {
                //verifica se existe aluno a ser alterado
                var result = await _context.usuarioFuncionario.FindAsync(UsuarioFuncionarioId);
                if (UsuarioFuncionarioId != result.Id)
                {
                    return BadRequest();
                }
                result.idUsuarioPet = dadosUsuarioFuncionarioAlt.idUsuarioPet;
                result.idFuncionario = dadosUsuarioFuncionarioAlt.idFuncionario;
                result.dataDeAdocao = dadosUsuarioFuncionarioAlt.dataDeAdocao;
                await _context.SaveChangesAsync();
                return Created($"/api/usuarioFuncionario/{dadosUsuarioFuncionarioAlt.Id}", dadosUsuarioFuncionarioAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("{UsuarioFuncionarioId}")]
        public async Task<ActionResult> delete(int UsuarioFuncionarioId)
        {
            try
            {
                //verifica se existe aluno a ser excluído
                var usuarioFuncionario = await _context.usuarioFuncionario.FindAsync(UsuarioFuncionarioId);
                if (usuarioFuncionario == null)
                {
                    //método do EF
                    return NotFound();
                }
                _context.Remove(usuarioFuncionario);
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