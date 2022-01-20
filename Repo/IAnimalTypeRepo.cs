using System;
using System.Collections.Generic;
using AnimalCollection.DTOs;
using AnimalCollection.Entities;

namespace AnimalCollection.Repo
{
    public interface IAnimalTypeRepo
    {
        List<AnimalType> GetAllAnimalTypes();

        AnimalType GetAnimalTypeByID(int id);

        AnimalType CreateAnimalType(CreateAnimalTypeDTO animaltype);

        AnimalType UpdateAnimalType(AnimalType animaltype);

        void DeleteAnimalType(int id);


    }
}
