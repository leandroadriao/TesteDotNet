using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteDotNet.MVC.Controllers;
using System.Web.Mvc;
using TesteDotNetXP.MVC.DAL;
using System.Web;
using System.Web.Routing;
using System.Security.Principal;
using TesteDotNetXP.MVC.Models;
using System.Collections.Generic;

namespace TesteDotNet.MVC.UnitTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TesteIndex()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TesteCadastroExistente()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Simply executing a method during a unit test does just that - executes a method, and no more. 
            // The MVC pipeline doesn't run, so binding and validation don't run.
          
            Item item1 = new Item("Item 1", "Item 1");

            // Act
            ViewResult result = (ViewResult)controller.Cadastro(item1);

            // Assert
            Assert.AreEqual("Cadastro", result.ViewName);
        }

        [TestMethod]
        public void TesteCadastro()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Simply executing a method during a unit test does just that - executes a method, and no more. 
            // The MVC pipeline doesn't run, so binding and validation don't run.

            Item item1 = new Item("CDI", "Item 1");

            // Act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Cadastro(item1);

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void TesteDetalhe()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Detalhe(1) as ViewResult;
            Assert.AreEqual("Detalhe", result.ViewName);

        }

        [TestMethod]
        public void Excluir()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Simply executing a method during a unit test does just that - executes a method, and no more. 
            // The MVC pipeline doesn't run, so binding and validation don't run.

            // Act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.ExcluirConfirmed(1);

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
