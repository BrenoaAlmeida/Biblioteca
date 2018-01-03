using Model;
using System.Collections.Generic;
using Repository;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {

        RepositoryFacede repositoryFacede = new RepositoryFacede();

        private ActionResult ObterLivros()
        {
            var livros = repositoryFacede.LivroRepository.Livros();
            return View("Index", livros);
        }


        // GET: Livro
        public ActionResult Index()
        {
            return ObterLivros();
        }

        // GET: Livro/Create
        public ActionResult Criar()
        {
            CarregarDropDownListDeLivros();
            return View("Criar_Editar");
        }

        private void CarregarDropDownListDeLivros()
        {
            var editoras = repositoryFacede.EditoraRepository.ObterEditoras();
            ViewBag.Editora_Id = new SelectList(editoras, "id", "Nome");
        }

        // POST: Livro/Create
        [HttpPost]
        public ActionResult Criar(Livro livro)
        {
            try
            {
                // TODO: Add insert logic here                                
                repositoryFacede.LivroRepository.Adicionar(livro);
                return ObterLivros();

            }
            catch(Exception msg)
            {
                return View("Criar_Editar" , "Ocorreu o seguinte erro: " + msg);
            }
        }

        // GET: Livro/Edit/5
        public ActionResult Editar(int id)
        {
            Livro livro = repositoryFacede.LivroRepository.Buscar(id);
            CarregarDropDownListDeLivros();
            return View("Criar_Editar" , livro);
        }

        // POST: Livro/Edit/5
        [HttpPost]
        public ActionResult Editar(Livro livro)
        {
            try
            {
                // TODO: Add update logic here
                repositoryFacede.LivroRepository.Editar(livro);
                return ObterLivros();
            }
            catch(Exception msg)
            {
                string mensagem = msg.ToString();
                return View("Index" , "Ocorreu o seguinte erro : " + mensagem);
            }
        }        

        // GET: Livro/Delete/5
        public ActionResult Deletar(int id) 
        {
            Livro livro = repositoryFacede.LivroRepository.Buscar(id);
            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost]
        public ActionResult Deletar(Livro livro)
        {
            try
            {
                // TODO: Add delete logic here                
                repositoryFacede.LivroRepository.Excluir(livro.Id);
                return ObterLivros();
            }
            catch(Exception msg)
            {
                return View("Deletar" , "Ocorreu o seguinte erro: " + msg);
            }
        }
    }
}
