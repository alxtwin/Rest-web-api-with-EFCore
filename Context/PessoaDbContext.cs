using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using trabalhows.Models;


//Essa classe é usada para armazenar parte dos procedimentos referentes ao acesso a database.


namespace trabalhows.Context
{
    public class PessoaDbContext : DbContext
    {
        public PessoaDbContext(DbContextOptions<PessoaDbContext> options) : base(options)
        {
            
        }

        public DbSet<Pessoa> pessoas {get; set;}

//Override serve para que seja acessível a connectionstring da database 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));

        }
    }
    
}
//A connection string está colocada no appsettings.json 