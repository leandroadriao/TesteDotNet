using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TesteDotNetXP.MVC.DAL
{
    public class ItemContext : DbContext
    {
        public ItemContext()
            : base("name=TesteDotNetCnn")
        {
        }
        public DbSet<Models.Item> Items { get; set; }
    }
}