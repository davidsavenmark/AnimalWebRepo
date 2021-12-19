using System;
using Microsoft.EntityFrameworkCore;

namespace AnimalCollection.Entities
{
    public class ApplicationContext: DbContext
    {
        DbSet<Animal> Animals { get; set; }


        private string _connectionString = "server=localhost; database=AnimalCollection; user=root; password=xxxxxx";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(
                _connectionString,
                ServerVersion.AutoDetect(_connectionString));

        }





    }
}
