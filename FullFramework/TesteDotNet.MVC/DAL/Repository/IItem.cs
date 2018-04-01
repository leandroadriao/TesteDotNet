using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDotNetXP.MVC.Models;

namespace TesteDotNetXP.MVC.DAL
{
    public interface Iitem
    {
        bool Insere(Item item);
        Item Detalhe(int id);
        IEnumerable<Item> Lista();
        IEnumerable<Item> Lista(string search, string search2);
        bool Excluir(int id);
        bool Editar(Item item);


    }
}
