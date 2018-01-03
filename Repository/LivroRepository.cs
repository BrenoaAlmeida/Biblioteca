 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
namespace Repository
{
    public class LivroRepository
    {
        BibliotecaContext bibliotecaContext;
        public LivroRepository(BibliotecaContext ctx)
        {
            this.bibliotecaContext = ctx;
        }

        public List<Livro> Livros()
        {
                return bibliotecaContext.Livros.ToList();         
        }

        public void Adicionar(Livro livro)
        {
            bibliotecaContext.Livros.Add(livro);
            Salvar();
        }

        public Livro Buscar(int id)
        {
            return bibliotecaContext.Livros.Find(id);
        }

        public void Excluir(int id)
        {
            Livro livro = Buscar(id);
            bibliotecaContext.Livros.Remove(livro);
            Salvar();
        }

        public void Salvar()
        {            
            bibliotecaContext.SaveChanges();
        }

        public void Editar(Livro livroEditado)
        {
            Livro livro = Buscar(livroEditado.Id);
            livro.Nome = livroEditado.Nome;
            livro.Estoque = livroEditado.Estoque;
            livro.Editora_Id = livroEditado.Editora_Id;
            Salvar();
        }
    }
}
