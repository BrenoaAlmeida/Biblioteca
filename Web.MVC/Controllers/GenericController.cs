using System;
using Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.MVC.Controllers
{
    public class GenericController<TModel> : Controller where TModel : class
    {
        GenericRepository<TModel> genericRepository;
        public ActionResult ObterListaGenerica()
        {
            var lista = genericRepository.GetAll();
            return View("Index", lista);
        }
        // GET: Generic
        public ActionResult Index()
        {
            return ObterListaGenerica();
        }
        
        // GET: Generic/Create
        public ActionResult Criar()
        {
            return View();
        }

        // POST: Generic/Create
        [HttpPost]
        public ActionResult Criar(TModel model)
        {
            try
            {
                genericRepository.Add(model);
                return ObterListaGenerica();
            }
            catch
            {
                return View();
            }
        }

        // GET: Generic/Edit/5
        public ActionResult Editar(int id)
        {
            TModel model = genericRepository.FindById(id);
            return View("Criar_Editar" , model);
        }

        // POST: Generic/Edit/5
        [HttpPost]
        public ActionResult Editar(TModel model)
        {
            try
            {
                //Deveria retornar um editar Generico                
                return ObterListaGenerica();
            }
            catch
            {
                return View();
            }
        }

        // GET: Generic/Delete/5
        public ActionResult Deletar(int id)
        {
            TModel model = genericRepository.FindById(id);
            return View(model);
        }

        // POST: Generic/Delete/5
        [HttpPost]
        public ActionResult Delete(int model)
        {
            try
            {
                genericRepository.Delete(model);
                return ObterListaGenerica();
            }
            catch
            {
                return View();
            }
        }
    }
}
