using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteDotNet.MVC.Models
{
    public class Mensagens
    {
        public enum DialogType : short
        {
            Info = 0,
            Sucesso = 1,
            Atencao = 2,
            Erro = 3
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public DialogType @Type { get; set; }

        public override string ToString() => $"{{ \"title\": \"{Title}\", \"content\": \"{Content}\", \"type\": \"{@Type.ToString().ToLower()}\" }}";
    }
}