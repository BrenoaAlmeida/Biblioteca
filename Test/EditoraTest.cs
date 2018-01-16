using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Repository;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class EditoraTest
    {
        private RepositoryFacade repositoryFacade;
        private EditoraRepository editoraRepository;
        private BibliotecaContext context;
        [TestInitialize]
        public void Initialize()    
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            context = new BibliotecaContext(connection);
            editoraRepository = new EditoraRepository(context);
        }

        public Editora PreencherObjeto()
        {
            Editora edt = new Editora();
            edt.Id = 1;
            edt.Nome = "Breno";
            return edt;
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestarObrigatoriedadeDosCampos()
        {
            //arrange
            Editora editora = null;
            //act
            repositoryFacade.Editora.Add(editora);
            //assert
            Assert.AreEqual(typeof(ArgumentNullException), typeof(ArgumentNullException));
        }

        [TestMethod]
        public void TestarOperaçaoDesalvar()
        {
            //arrange            
            Editora editora = PreencherObjeto();
            //act            
            repositoryFacade.Editora.Add(editora);
            //assert
            Assert.AreEqual(1, context.Editoras.Count());
        }


        [TestMethod]
        public void TestOperaçãoDeExclusao()
        {
            //arrange
            Editora editora = PreencherObjeto();
            repositoryFacade.Editora.Add(editora);
            //Act
            repositoryFacade.Editora.Delete(editora.Id);           
            //Assert
            Assert.AreEqual(0 , context.Editoras.Count());
        }

        [TestMethod]
        public void TestarBuscar()
        {
            //arrange
            Editora edt = new Editora();
            edt.Id = 1;
            edt.Nome = "Breno";
            Editora edt2 = new Editora();
            edt2.Id = 2;
            edt2.Nome = "Jeova";
            Editora edt3 = new Editora();
            edt3.Id = 3;
            edt3.Nome = "Evelyn";
            repositoryFacade.Editora.Add(edt);
            repositoryFacade.Editora.Add(edt2);
            repositoryFacade.Editora.Add(edt3);

            //Act
            Editora editoraBuscada = new Editora();
            editoraBuscada = repositoryFacade.Editora.FindById(2);
            //Assert
            Assert.AreEqual("Jeova", editoraBuscada.Nome);
        }
    }

}
 