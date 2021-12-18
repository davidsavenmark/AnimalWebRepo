using System;
using System.Collections.Generic;
using AnimalCollection.DTOs;
using AnimalCollection.Entities;

namespace AnimalCollection.Repo
{
    public interface IAnimalRepo
    {


        List<Animal> GetAll();

        Animal GetByID(int id);


        Animal CreateAnimal(CreateAnimalDTO animal);

        Animal UpdateAnimal(Animal animal);

        void DeleteAnimal(int id);

    }
}
