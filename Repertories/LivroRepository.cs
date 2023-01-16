using Microsoft.EntityFrameworkCore;
using UC17.Contexts;
using UC17.Models;

namespace UC17.Repositories
{
    public class LivroRepository
    {
        private readonly SqlContext _context;
        public LivroRepository(SqlContext context)
        {
            _context = context;
        }

        public List<Livro> Listar()
        {
            return _context.Livros.ToList();
        }

        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        public void Cadastro(Livro l)
        {
            _context.Livros.Add(l);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro l = _context.Livros.Find(id);
            _context.Livros.Remove(l);
            _context.SaveChanges();
        }

        public void Alterar(int id, Livro l)
        {
            Livro livroBuscado = _context.Livros.Find(id);

            if (livroBuscado != null)
            {
                livroBuscado.Título = l.Título;
                livroBuscado.QuantidadePaginas = l.QuantidadePaginas;
                livroBuscado.Disponível = l.Disponível;

                _context.Livros.Update(livroBuscado);
                _context.SaveChanges();
            }
        }

    }
}
