using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Repository
{
    public class EditoraRepository
    {
        BibliotecaContext bibliotecaContext;
        public EditoraRepository(BibliotecaContext ctx)
        {
           this.bibliotecaContext = ctx;
        }        

        public void Salvar()
        {
            bibliotecaContext.SaveChanges();
        }

        public Editora Buscar(int id)
        {
            Editora editora = bibliotecaContext.Editoras.Find(id);
            return editora;
        }

        public void Adicionar(Editora editora)
        {
            bibliotecaContext.Editoras.Add(editora);
            Salvar();
        }

        public void Editar(Editora editoraEditada)
        {
            Editora editora = Buscar(editoraEditada.Id);
            editora.Nome = editoraEditada.Nome;
            Salvar();
        }

        public void Deletar(int id)
        {
            Editora editora = Buscar(id);
            bibliotecaContext.Editoras.Remove(editora);
            Salvar();
        }

        public List<Editora> ObterEditoras()
        {
                return bibliotecaContext.Editoras.ToList();            
        }
    }
}
