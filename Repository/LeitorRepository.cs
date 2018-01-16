using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LeitorRepository : GenericRepository<Leitor>
    {
        BibliotecaContext bibliotecaContext;
        public LeitorRepository(BibliotecaContext context) : base(context)
        {
        }

        public void Editar(Leitor leitorEditado)
        {
            Leitor leitor = bibliotecaContext.Leitores.Find(leitorEditado.Id);
            leitor.Nome = leitorEditado.Nome;
            leitor.Senha = leitorEditado.Senha;
            leitor.Livro_Id = leitorEditado.Livro_Id;
            bibliotecaContext.SaveChanges();
        }
    }
}
