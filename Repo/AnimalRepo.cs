using System;
using System.Collections.Generic;
using System.Linq;
using AnimalCollection.DTOs;
using AnimalCollection.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalCollection.Repo
{
    public class AnimalRepo : IAnimalRepo
    {
        private ApplicationContext _context;
        //private ApplicationContext _db;

        public AnimalRepo(ApplicationContext context)
        {
            _context = context;

        }

        public Animal CreateAnimal(CreateAnimalDTO createdAnimalDTO)
        {

            Animal animal = new Animal();

            animal.Name = createdAnimalDTO.Name;

            animal.AnimalTypeID = createdAnimalDTO.AnimalTypeID;


            _context.Animals.Add(animal);
            _context.SaveChanges();

            return animal;
        }

        public List<Animal> GetAll()
        {
            return _context
                   .Animals
                   .Include(v => v.AnimalType)
                   .ToList();
        }

        public Animal GetByID(int id)
        {
            Animal animal = _context
                 .Animals
                 .Include(v => v.AnimalType)
                 .SingleOrDefault(x => x.ID == id);
            return animal;
        }

        public Animal UpdateAnimal(Animal animal, int id)
        {
            Animal existingAnimal = _context.Animals.FirstOrDefault(x => x.ID == animal.ID);
            if (existingAnimal != null)
            {
                existingAnimal.Name = animal.Name;
                existingAnimal.AnimalType = animal.AnimalType;
            }

            _context.SaveChanges();
            return existingAnimal;
        }

        public void DeleteAnimal(int id)
        {
            _context.Animals.Remove(GetByID(id));
            _context.SaveChanges();
        }
    }   
}
