using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using Model;
using Bussines;

namespace Biblioteca.Controllers
{
    public class EditoraController : Controller
    {
        RepositoryFacade repositoryFacede = new RepositoryFacade();
        BibliotecaContext context;
        // GET: Editora
        public ActionResult Index()
        {
            return ObterEditoras();
        }

        private ActionResult ObterEditoras()
        {
            var editoras = repositoryFacede.Editora.GetAll();
            return View("Index", editoras);
        }

        // GET: Editora/Create
        public ActionResult Criar()
        {
            return View("Criar_Editar");
        }

        // POST: Editora/Create
        [HttpPost]
        public ActionResult Criar(Editora editora)
        {
            try
            {
                // TODO: Add insert logic here
                repositoryFacede.Editora.Add(editora);
                return ObterEditoras();
            }
            catch
            {
                return View();
            }
        }

        // GET: Editora/Edit/5
        public ActionResult Editar(int id)
        {
            Editora editora = repositoryFacede.Editora.FindById(id);
            return View("Criar_Editar", editora);
        }

        // POST: Editora/Edit/5
        [HttpPost]
        public ActionResult Editar(Editora editora)
        {
            try
            {
                // TODO: Add update logic here
                    repositoryFacede.Editora.Edit(editora , editora.Id);
                return ObterEditoras();
            }
            catch(ViolacaoRegraDeNegocio msg)
            {
                return View("Criar_Editar" , msg);
            }
        }

        // GET: Editora/Delete/5
        public ActionResult Deletar(int id)
        {
            Editora editora = repositoryFacede.Editora.FindById(id);
            return View(editora);
        }

        // POST: Editora/Delete/5
        [HttpPost]
        public ActionResult Deletar(Editora editora)
        {
            try
            {
                // TODO: Add delete logic here
                repositoryFacede.Editora.Delete(editora.Id);
                return ObterEditoras();
            }
            catch
            {
                return View();
            }
        }
    }
}
