using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteDotNet.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        public const string SystemMessage = "MY_DIALOG";

        protected void ShowMessage(string htmlContent, string htmlTitle = "Mensagem do Sistema", Models.Mensagens.DialogType type = Models.Mensagens.DialogType.Info)
        {
            this.ShowMessage(new Models.Mensagens { Title = htmlTitle, Content = htmlContent, @Type = type });
        }

        protected void ShowMessage(Models.Mensagens dialog)
        {
            this.TempData[SystemMessage] = dialog.ToString();
        }
    }
}