using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class LeitorController : Controller
    {
        RepositoryFacede repositoryFacede = new RepositoryFacede();
        
        // GET: Leitor

        private void CarregarDropDownListLivros()
        {              
            List<Livro> livros = repositoryFacede.LivroRepository.Livros();
            ViewBag.Livro_Id = new SelectList(livros, "Id", "Nome");
        }


        private ActionResult ObterLeitores()
        {
            var listaDeLeitores = repositoryFacede.LeitorRepository.Leitores();
            return View("Index", listaDeLeitores);
        }

        public ActionResult Index()
        {
            return ObterLeitores();
        }    

        // GET: Leitor/Create
        public ActionResult Criar()
        {
            CarregarDropDownListLivros();
            return View("Criar_Editar");
        }

        // POST: Leitor/Create
        [HttpPost]
        public ActionResult Criar(Leitor leitor)
        {
            try
            {
                repositoryFacede.LeitorRepository.Adicionar(leitor);
                return ObterLeitores();
            }
            catch
            {
                return View("Criar_Editar");
            }
        }

        // GET: Leitor/Edit/5
        public ActionResult Editar(int id)
        {
            CarregarDropDownListLivros();
            Leitor leitor = repositoryFacede.LeitorRepository.Buscar(id);            
            return View("Criar_Editar" , leitor);
        }

        // POST: Leitor/Edit/5
        [HttpPost]
        public ActionResult Editar(Leitor leitor)
        {
            try
            {
                repositoryFacede.LeitorRepository.Editar(leitor);
                return ObterLeitores();
            }
            catch
            {
                return View();
            }
        }

        // GET: Leitor/Delete/5
        public ActionResult Deletar(int id)
        {
            Leitor leitor = repositoryFacede.LeitorRepository.Buscar(id);
            return View(leitor);
        }

        // POST: Leitor/Delete/5
        [HttpPost]
        public ActionResult Deletar(Leitor leitor)
        {
            try
            {
                repositoryFacede.LeitorRepository.Excluir(leitor.Id);
                return ObterLeitores();
            }
            catch
            {
                return View("Deletar" , "????");
            }
        }
    }
}
