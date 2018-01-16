 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
namespace Repository
{
    public class LivroRepository : GenericRepository<Livro>
    {
        BibliotecaContext bibliotecaContext;
        public LivroRepository(BibliotecaContext context) : base(context)
        {            
        }

        public void Editar(Livro livroEditado)
        {
            Livro livro = bibliotecaContext.Livros.Find(livroEditado.Id);
            livro.Nome = livroEditado.Nome;
            livro.Estoque = livroEditado.Estoque;
            livro.Editora_Id = livroEditado.Editora_Id;
            bibliotecaContext.SaveChanges();
        }
    }
}
