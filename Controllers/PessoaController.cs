using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using trabalhows.Context;
using trabalhows.Models;


//Os ids servem para exclusão


namespace trabalhows.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {

        private readonly PessoaDbContext _pessoaDbContext;

        public PessoaController(PessoaDbContext pessoaDbContext)
        {
            _pessoaDbContext = pessoaDbContext;
        }
        

        [HttpPost("{nome}/{cpf}/{idade}")]
        public async Task<ActionResult<Pessoa>> CriarPessoa(string nome, string cpf, int idade, Pessoa pessoa)
        {
            Pessoa p = new Pessoa(nome,cpf,idade);
            _pessoaDbContext.pessoas.Add(p);
            await _pessoaDbContext.SaveChangesAsync();

            return Ok(new
            {
                success=true,
                data = pessoa,
            }
            );
        }

        [HttpGet]

        public async Task <IActionResult> GetPessoas()
        {
            return Ok(new
            {
                success = true,
                data = await _pessoaDbContext.pessoas.ToListAsync()
            }
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarPessoa(int id, [FromBody] Pessoa pessoa)
        {
            if (pessoa.Id != id)
            {
                return BadRequest();
            } 
            else{
                _pessoaDbContext.Entry(pessoa).State =  EntityState.Modified;
            await _pessoaDbContext.SaveChangesAsync();
            }  
           
            return Ok(new
            {
                success=true,
                data = pessoa,
            }
            );
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            var pessoa = await _pessoaDbContext.pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            else{
            _pessoaDbContext.pessoas.Remove(pessoa);
            await _pessoaDbContext.SaveChangesAsync();
            }
            return Ok(new
            {
                success=true,
                data=pessoa,
            }
            );
}
    }
//Os returns com "Ok" foram uma 'adaptação técnica' que surgiu porque essa parte do código não rodava de outra forma. 

}

 