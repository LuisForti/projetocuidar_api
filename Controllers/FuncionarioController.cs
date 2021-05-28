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
    public class FuncionarioController : Controller
    {
        private readonly CuidarContext _context;
        public FuncionarioController(CuidarContext context)
        {
            // construtor
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Funcionario>> GetAll() {
            return _context.funcionario.ToList();
        }
        
        [HttpGet("{FuncionarioId}")]
        public ActionResult<List<Funcionario>> Get(int FuncionarioId) 
        {
            try
            {
                var result = _context.funcionario.Find(FuncionarioId);
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
        public async Task<ActionResult> post(Funcionario model)
        {
            try
            {
                _context.funcionario.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    //return Ok();
                    return Created($"/api/funcionario/{model.Id}",model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }

        [HttpPut("{FuncionarioId}")]
        public async Task<IActionResult> put(int FuncionarioId, Funcionario dadosFuncionarioAlt)
        {
            try {
                //verifica se existe aluno a ser alterado
                var result = await _context.funcionario.FindAsync(FuncionarioId);
                if (FuncionarioId != result.Id)
                {
                    return BadRequest();
                }
                result.nomeFuncionario = dadosFuncionarioAlt.nomeFuncionario;
                result.senhaFuncionario = dadosFuncionarioAlt.senhaFuncionario;
                result.emailFuncionario = dadosFuncionarioAlt.emailFuncionario;
                result.fotoFuncionario = dadosFuncionarioAlt.fotoFuncionario;
                await _context.SaveChangesAsync();
                return Created($"/api/aluno/{dadosFuncionarioAlt.Id}", dadosFuncionarioAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("{FuncionarioId}")]
        public async Task<ActionResult> delete(int FuncionarioId)
        {
            try
            {
                //verifica se existe aluno a ser excluído
                var funcionario = await _context.funcionario.FindAsync(FuncionarioId);
                if (funcionario == null)
                {
                    //método do EF
                    return NotFound();
                }
                _context.Remove(funcionario);
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