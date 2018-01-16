using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace Repository
{
    public class EditoraRepository : GenericRepository<Editora>
    {
        BibliotecaContext bibliotecaContext;
        public EditoraRepository(BibliotecaContext context) : base(context)
        {
        }

        //    public void Editar(Editora editoraEditada)
        //    {
        //        Editora editora = bibliotecaContext.Editoras.Find(editoraEditada.Id);
        //        editora.Nome = editoraEditada.Nome;
        //        bibliotecaContext.SaveChanges();
        //    }
        //}
    }
}
