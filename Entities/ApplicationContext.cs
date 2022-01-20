using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AnimalCollection.Entities
{

    // dotnet ef migrations add XXXXXX
    // dotnet ef migrations delete
    // dotnet ef database update



    public class ApplicationContext: DbContext
    {
        public DbSet<Animal> Animals { get; set; }

        public DbSet<AnimalType> AnimalTypes { get; set; }


        private string _connectionString = "server=localhost; database=AnimalCollection; user=root; password=simpaticus12341";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

                options.UseMySql(
                _connectionString,
                ServerVersion.AutoDetect(_connectionString));
                


        }




        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<AnimalType>().HasData(
               new AnimalType
               {
                   ID = 1,
                   Name = "Mammal",
                  

               },

               new AnimalType
               {
                   ID = 2,
                   Name = "Bird",
                  

               },


               new AnimalType
               {
                   ID = 3,
                   Name = "Fish",


               },

                new AnimalType
                {
                    ID = 4,
                    Name = "Reptile",


                },

                 new AnimalType
                 {
                     ID = 5,
                     Name = "Insect",


                 },

               new AnimalType
               {
                   ID = 6,
                   Name = "Amphibian",
                 

               });



            builder.Entity<Animal>().HasData(
                new Animal
                {
                    ID = 1,
                    Name = "Dog",
                    AnimalTypeID = 1

                },
                new Animal
                {
                    ID = 2,
                    Name = "Raven",
                    AnimalTypeID = 2

                },
                new Animal
                {
                    ID = 3,
                    Name = "Salmon",
                    AnimalTypeID = 3

                },
                new Animal
                {
                    ID = 4,
                    Name = "Bearded Dragon",
                    AnimalTypeID = 4
                },
                new Animal
                {
                    ID = 5,
                    Name = "Ladybird",
                    AnimalTypeID = 5

                },
                new Animal
                {
                    ID = 6,
                    Name = "Frog",
                    AnimalTypeID = 6

                });




        }



    }
}
