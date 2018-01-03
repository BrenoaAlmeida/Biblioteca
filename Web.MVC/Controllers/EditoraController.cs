using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repository;
using Model;
namespace Biblioteca.Controllers
{
    public class EditoraController : Controller
    {
        RepositoryFacede repositoryFacede = new RepositoryFacede();
        // GET: Editora
        public ActionResult Index()
        {
            return ObterEditoras();
        }

        private ActionResult ObterEditoras()
        {
            var editoras = repositoryFacede.EditoraRepository.ObterEditoras();
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
                repositoryFacede.EditoraRepository.Adicionar(editora);
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
            Editora editora = repositoryFacede.EditoraRepository.Buscar(id);
            return View("Criar_Editar" , editora);
        }

        // POST: Editora/Edit/5
        [HttpPost]
        public ActionResult Editar(Editora editora)
        {
            try
            {
                // TODO: Add update logic here
                repositoryFacede.EditoraRepository.Editar(editora);
                return ObterEditoras();
            }
            catch
            {
                return View();
            }
        }

        // GET: Editora/Delete/5
        public ActionResult Deletar(int id)
        {
            Editora editora = repositoryFacede.EditoraRepository.Buscar(id);
            return View(editora);
        }

        // POST: Editora/Delete/5
        [HttpPost]
        public ActionResult Deletar(Editora editora)
        {
            try
            {
                // TODO: Add delete logic here
                repositoryFacede.EditoraRepository.Deletar(editora.Id);
                return ObterEditoras();
            }
            catch
            {
                return View();
            }
        }
    }
}
