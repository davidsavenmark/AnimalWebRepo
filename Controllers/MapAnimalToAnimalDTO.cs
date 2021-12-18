using System;
using AnimalCollection.DTOs;
using AnimalCollection.Entities;

namespace AnimalCollection.Controllers
{
    internal class MapAnimalToAnimalDTO: AnimalDTO
    {
        private Animal animal;



        public MapAnimalToAnimalDTO(Animal animal)
        {
            this.animal = animal;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }


    }
}
