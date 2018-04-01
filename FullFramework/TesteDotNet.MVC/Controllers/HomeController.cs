using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteDotNetXP.MVC.DAL;
using TesteDotNetXP.MVC.Models;

namespace TesteDotNet.MVC.Controllers
{
    public class HomeController : BaseController
    {
        Iitem _item;

        public HomeController() : this(new ItemRepositary()) { }
        public HomeController(ItemRepositary itemRepositary)
        {
            _item = itemRepositary;
        }
        //private ItemContext db = new ItemContext();
        public ActionResult Index()
        {
            return View(_item.Lista());
        }

        [HttpPost]
        public ActionResult Index(string search, string search2)
        {
            return View(_item.Lista(search, search2));
        }

        public ActionResult Cadastro()
        {
            ViewBag.Message = false;

            return View(new Item());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro([Bind(Include = "Codigo,Nome,Descricao,Categoria,Data")] Item item)
        {
            int retorno;
            ViewBag.Message = false;
            if (ModelState.IsValid)
            {
                retorno = _item.Insere(item);

                if (retorno == 0)
                {
                    this.ShowMessage("Já existe um Item com este nome!");
                    ViewBag.Message = true;
                    return View("CadastroExistente", item);
                }
                else if (retorno == 1)
                {
                    this.ShowMessage("Cadastro do item, realizado com sucesso!");
                    ViewBag.Message = true;
                    return RedirectToAction("Index");
                }
                else
                    return View(item);
            }

            return View(item);
        }
        public ActionResult Detalhe(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = _item.Detalhe(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View("Detalhe", item);
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = _item.Detalhe(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Codigo,Nome,Descricao,Categoria,Data")] Item item)
        {
            if (ModelState.IsValid)
            {
                if (_item.Editar(item))
                {
                    this.ShowMessage("Alteração do item, realizado com sucesso!");
                    ViewBag.Message = true;
                    return RedirectToAction("Index");
                }
            }
            return View(item);
        }

        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = _item.Detalhe(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmed(int id)
        {
            if (_item.Excluir(id))
            {
                this.ShowMessage("Item excluído, com sucesso!");
                ViewBag.Message = true;
            }
            return RedirectToAction("Index");
        }
    }
}