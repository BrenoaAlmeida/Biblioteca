using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LeitorRepository
    {
        BibliotecaContext bibliotecaContext;
        public LeitorRepository(BibliotecaContext context)
        {
            this.bibliotecaContext = context;
        }

        public List<Leitor> Leitores()
        {            
                return bibliotecaContext.Leitores.ToList();
        }

        public void Adicionar(Leitor leitor)
        {
            bibliotecaContext.Leitores.Add(leitor);
            Salvar();
        }

        public void Excluir(int id)
        {
            Leitor leitor = Buscar(id);
            bibliotecaContext.Leitores.Remove(leitor);
            Salvar();
        }

        public Leitor Buscar(int id)
        {
            return bibliotecaContext.Leitores.Find(id);
        }
        
        public void Salvar()
        {            
            bibliotecaContext.SaveChanges();
        }

        public void Editar(Leitor leitorEditado)
        {
            Leitor leitor = Buscar(leitorEditado.Id);
            leitor.Nome = leitorEditado.Nome;
            leitor.Senha = leitorEditado.Senha;
            leitor.Livro_Id = leitorEditado.Livro_Id;
            Salvar();
        }
    }
}
