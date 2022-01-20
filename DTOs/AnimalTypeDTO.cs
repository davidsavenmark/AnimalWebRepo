using System;
using System.Collections.Generic;
using System.Linq;
using AnimalCollection.Entities;

namespace AnimalCollection.DTOs
{

    public class AnimalTypeDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        

      
    }

    public static class AnimalTypeDTOExtensions
    {

        public static AnimalTypeDTO MapToAnimalTypeDTO(this AnimalType animaltype)
        {
            return new AnimalTypeDTO
            {
                ID = animaltype.ID,
                Name = animaltype.Name
            };


        }

        public static List<AnimalTypeDTO> MapToAnimalTypeDTOs(this List<AnimalType> animaltypes)
        {
            return animaltypes.Select(a => a.MapToAnimalTypeDTO()).ToList();
        }

    }





}
