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
        RepositoryFacade repositoryFacede = new RepositoryFacade();

        // GET: Leitor

        private void CarregarDropDownListLivros()
        {
            RepositoryFacade repositoryFacede = new RepositoryFacade();
            List<Livro> livros = repositoryFacede.Livro.GetAll();
            ViewBag.Livro_Id = new SelectList(livros, "Id", "Nome");
        }


        private ActionResult ObterLeitores()
        {
            var listaDeLeitores = repositoryFacede.Leitor.GetAll();
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
                repositoryFacede.Leitor.Add(leitor);
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
            Leitor leitor = repositoryFacede.Leitor.FindById(id);
            return View("Criar_Editar", leitor);
        }

        // POST: Leitor/Edit/5
        [HttpPost]
        public ActionResult Editar(Leitor leitor)
        {
            try
            {
                repositoryFacede.Leitor.Editar(leitor);
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
            Leitor leitor = repositoryFacede.Leitor.FindById(id);
            return View(leitor);
        }

        // POST: Leitor/Delete/5
        [HttpPost]
        public ActionResult Deletar(Leitor leitor)
        {
            try
            {
                repositoryFacede.Leitor.Delete(leitor.Id);
                return ObterLeitores();
            }
            catch
            {
                return View("Deletar", "????");
            }
        }
    }
}
