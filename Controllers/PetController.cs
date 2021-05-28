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
    public class PetController : Controller
    {
        private readonly CuidarContext _context;
        public PetController(CuidarContext context)
        {
            // construtor
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Pet>> GetAll() {
            return _context.pet.ToList();
        }
        
        [HttpGet("{PetId}")]
        public ActionResult<List<Pet>> Get(int PetId) 
        {
            try
            {
                var result = _context.pet.Find(PetId);
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
        public async Task<ActionResult> post(Pet model)
        {
            try
            {
                _context.pet.Add(model);
                if (await _context.SaveChangesAsync() == 1)
                {
                    //return Ok();
                    return Created($"/api/pet/{model.Id}",model);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            // retorna BadRequest se não conseguiu incluir
            return BadRequest();
        }

        [HttpPut("{PetId}")]
        public async Task<IActionResult> put(int PetId, Pet dadosPetAlt)
        {
            try {
                //verifica se existe aluno a ser alterado
                var result = await _context.pet.FindAsync(PetId);
                if (PetId != result.Id)
                {
                    return BadRequest();
                }
                result.nomePet = dadosPetAlt.nomePet;
                result.fotoPet = dadosPetAlt.fotoPet;
                result.raca = dadosPetAlt.raca;
                result.idade = dadosPetAlt.idade;
                result.condicoesMedicas = dadosPetAlt.condicoesMedicas;
                result.descricao = dadosPetAlt.descricao;
                await _context.SaveChangesAsync();
                return Created($"/api/aluno/{dadosPetAlt.Id}", dadosPetAlt);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha no acesso ao banco de dados.");
            }
        }

        [HttpDelete("{PetId}")]
        public async Task<ActionResult> delete(int PetId)
        {
            try
            {
                //verifica se existe aluno a ser excluído
                var pet = await _context.pet.FindAsync(PetId);
                if (pet == null)
                {
                    //método do EF
                    return NotFound();
                }
                _context.Remove(pet);
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