using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class RepositoryFacede
    {
        BibliotecaContext bibliotecaContext = new BibliotecaContext();
        private LivroRepository livroRepository;
        private EditoraRepository editoraRepository;
        private LeitorRepository leitorRepository;

        public LivroRepository LivroRepository
        {
            get
            {
                if (livroRepository == null)
                {
                    livroRepository = new LivroRepository(bibliotecaContext);
                }
                return livroRepository;
            }
        }

        public EditoraRepository EditoraRepository
        {
            get
            {
                if (editoraRepository == null)
                {
                    editoraRepository = new EditoraRepository(bibliotecaContext);
                }
                return editoraRepository;
            }
        }

        public LeitorRepository LeitorRepository
        {
            get
            {
                if (leitorRepository == null)
                {
                    leitorRepository = new LeitorRepository(bibliotecaContext);
                }
                return leitorRepository;
            }
        }

    }
}
