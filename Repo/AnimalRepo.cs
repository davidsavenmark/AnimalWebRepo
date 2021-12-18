using System;
using System.Collections.Generic;
using System.Linq;
using AnimalCollection.DTOs;
using AnimalCollection.Entities;

namespace AnimalCollection.Repo
{
    public class AnimalRepo : IAnimalRepo
    {


        private List<Animal> _animals;
        private Animal animal;


        public AnimalRepo()
        {
            _animals = PopulateAnimalData();

        }




        public Animal CreateAnimal(CreateAnimalDTO createdAnimalDTO)
        {

            Animal animal = new Animal();

            animal.Name = createdAnimalDTO.Name;

            animal.Type = createdAnimalDTO.Type;

            animal.Id = _animals.Max(x => x.Id) + 1;

            _animals.Add(animal);
            return animal;

        }

       

        public List<Animal> GetAll()
        {
            return _animals;
        }

        public Animal GetByID(int id)
        {
            Animal animal = _animals.Find(x => x.Id == id);
            return animal;
        }

        public Animal UpdateAnimal(Animal animal)
        {
            Animal existingAnimal = _animals.FirstOrDefault(x => x.Id == animal.Id);
            if (existingAnimal != null)
            {
                existingAnimal.Name = animal.Name;
                existingAnimal.Type = animal.Type;
            }
            return existingAnimal;

        }

        public void DeleteAnimal(int id)
        {
            _animals.Remove(GetByID(id));
        }

        private List<Animal> PopulateAnimalData()
        {
            return

            new List<Animal>
            {

                new Animal
                {
                    Id = 1,
                    Name= "Dog",
                    Type="Mammal",
                },

                new Animal
                {
                    Id = 2,
                    Name= "Raven",
                    Type="Bird",
                },

                new Animal
                {
                    Id = 3,
                    Name= "Cat",
                    Type="Mammal",
                },

                new Animal
                {
                    Id = 4,
                    Name= "Bearded Dragon",
                    Type="Reptile",
                },

                new Animal
                {
                    Id = 5,
                    Name= "Frog",
                    Type="Amphibian",
                },

                new Animal
                {
                    Id = 6,
                    Name= "Salmon",
                    Type="Fish",
                },
            };

        }


    }   
}