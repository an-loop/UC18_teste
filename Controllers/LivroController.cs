using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UC17.Models;
using UC17.Repositories;

namespace UC17.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]

        public IActionResult Listar()
        {
                return Ok(_livroRepository.Listar());
        }



        [HttpGet("{id}")]
        
        public IActionResult BuscarPorId(int id)
        {
            try
            {

                Livro livroBuscado = _livroRepository.BuscarPorId(id);

                if(livroBuscado == null)
                {
                    return NotFound("Não encontrado");
                }

            return Ok(livroBuscado);

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [HttpPost]

        public IActionResult Cadastrar(Livro l)
        {
            try
            {
                _livroRepository.Cadastro(l);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);
                return Ok("Livro removido com sucesso!");
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Livro l)
        {
            try
            {
                _livroRepository.Alterar(id, l);
                return StatusCode(204);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }

}

