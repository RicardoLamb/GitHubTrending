using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GitHubTrendings.Models
{
    public class GitHubContext : DbContext
    {

        //Construtor verifica se a base ja existe ou nao (Trending sera o nome da string de conexao).
        public GitHubContext() : base("TrendHub")
        {
            Database.CreateIfNotExists();
        }

        //cria um dbset tipado com classe trending. vai representar a tabela respositorio no sistema
        public DbSet<Trending> Trending { get; set; }
    }
}