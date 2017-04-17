using ProjetoExemplo01.Controllers;
using ProjetoExemplo01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;
using Moq;

namespace ProjetoExemplo01.Tests.Controllers
{
    [TestFixture]
    class PessoaControllerTests
    {
        private PessoaController controller;

        /// <summary>
        /// cria uma coleção de mocks
        /// </summary>
        /// <returns></returns>
        public Mock<IPessoaRepository> CreateMocks()
        {
            Mock<IPessoaRepository> mock = new Mock<IPessoaRepository>();

            mock.Setup(m => m.Pessoas).Returns(new Pessoa[]
                {
                    new Pessoa {PessoaId = 1,First_name="Herman",Last_name="Munster",Idade = 21},
                    new Pessoa {PessoaId = 2,First_name="Rocky",Last_name="Squirrel",Idade = 22},
                    new Pessoa {PessoaId = 3,First_name="George",Last_name="Washington",Idade = 23}
            }.AsQueryable());
            return mock;
        }

        [Test]
        public void Pessoa_Index_View_Contains_ListOfPessoa_model()
        {
            PessoaController controller = new PessoaController(CreateMocks().Object);
            var actual = (List<Pessoa>)controller.Index().Model;
            Assert.IsInstanceOf<List<Pessoa>>(actual);
        }

        [Test]
        public void Pessoa_Create_View_Pessoa_model()
        {
            controller = new PessoaController();
            var result = controller.Create();
            Assert.IsNotNull(result,"Pessoa não cadastrada");
        }

        [Test]
        public void Pessoa_Details_View_Pessoa_model()
        {
            controller = new PessoaController(CreateMocks().Object);
            var result = controller.Details(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public void Pessoa_Edit_View_Pessoa_model()
        {
            controller = new PessoaController(CreateMocks().Object);
            var result = controller.Edit(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public void Pessoa_DeleteConfirmed_View_Pessoa_model()
        {
            controller = new PessoaController(CreateMocks().Object);
            var result = controller.DeleteConfirmed(1);
            Assert.IsNotNull(result);
        }
    }
}
