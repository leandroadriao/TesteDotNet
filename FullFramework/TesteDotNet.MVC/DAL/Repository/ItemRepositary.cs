
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TesteDotNetXP.MVC.Models;

namespace TesteDotNetXP.MVC.DAL
{
    public class ItemRepositary : Iitem
    {
        ItemContext db = new ItemContext();
        public Item Detalhe(int id)
        {
            return db.Items.Find(id);
        }

        public bool Editar(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public bool Excluir(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return true;
        }

        public bool Insere(Item item)
        {
            if (db.Items.ToList().Where(x => x.Nome.ToLower().Contains(item.Nome.ToLower())).Count() > 0)
                return false;

            item.Data = DateTime.Now;
            db.Items.Add(item);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Item> Lista()
        {
            return db.Items.ToList().OrderBy(x => x.Nome);
        }

        public IEnumerable<Item> Lista(string search, string search2)
        {
            List<Item> ListaItems = new List<Item>();

            if (string.IsNullOrEmpty(search) && string.IsNullOrEmpty(search2))
                return (db.Items.ToList().OrderBy(x => x.Nome));

            if (!string.IsNullOrEmpty(search))
                return (db.Items.ToList().Where(x => x.Nome.ToLower().Contains(search.ToLower())).OrderBy(x => x.Nome));

            ListaItems.AddRange(db.Items.ToList().Where(x => x.Codigo.ToString().Contains(search2)));
            ListaItems.AddRange(db.Items.ToList().Where(x => x.Nome.ToLower().Contains(search2.ToLower())));
            ListaItems.AddRange(db.Items.ToList().Where(x => x.Categoria.ToLower().Contains(search2.ToLower())));
            ListaItems.AddRange(db.Items.ToList().Where(x => x.Data.ToShortDateString().Contains(search2)));
            return (ListaItems.Union(ListaItems).OrderBy(x => x.Nome));
        }
    }
}
