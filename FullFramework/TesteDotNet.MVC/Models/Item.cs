using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteDotNetXP.MVC.Models
{
    public class Item
    {
        [Key]
        [Display(Name = "Código")]
        public int Codigo { get; set; }
        [Required(AllowEmptyStrings = true, ErrorMessage = "Campo de preenchimento obrigátorio.")]
        [MaxLength(100)]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }

        [Display(Name = "Data Validade")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        //[Required(AllowEmptyStrings = true, ErrorMessage = "Campo de preenchimento obrigátorio.")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Data { get; set; }

        public Item(){}
        public Item(string nome, string categoria)
        {
            this.Nome = nome;
            this.Categoria = categoria;
            this.Data = DateTime.Now;
        }
    }
}