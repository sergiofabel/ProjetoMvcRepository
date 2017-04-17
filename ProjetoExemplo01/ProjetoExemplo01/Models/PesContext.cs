using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ProjetoExemplo01.Migrations;

namespace ProjetoExemplo01.Models
{
    public class PesContext : DbContext
    {
        public PesContext() : base("name=DatabaseTeste")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PesContext,Configuration>());
        }
        
        public virtual DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}