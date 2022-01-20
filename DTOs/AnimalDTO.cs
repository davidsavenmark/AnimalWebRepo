using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AnimalCollection.Entities;

namespace AnimalCollection.DTOs
{
    public class AnimalDTO
    {
        public int ID { get; set; }
        public AnimalTypeDTO AnimalType { get; set; }
        public string Name { get; set; }
    }

    public static class AnimalDTOExtenstions
    {
        public static AnimalDTO MapToAnimalDTO(this Animal animal)
        {
            return new AnimalDTO
            {
                ID = animal.ID,
                AnimalType = animal.AnimalType.MapToAnimalTypeDTO(),
                Name = animal.Name
            };

        }

        public static List<AnimalDTO> MapToAnimalDTOs(this List<Animal> animals)
        {
            return animals.Select(animal => animal.MapToAnimalDTO()).OrderBy(animal => animal.ID).ToList();
        }

    }



}
