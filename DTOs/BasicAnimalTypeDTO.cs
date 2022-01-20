using System;
using System.Collections.Generic;
using System.Linq;
using AnimalCollection.Entities;

namespace AnimalCollection.DTOs
{


    public class BasicAnimalTypeDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }




    }

    public static class BasicAnimalTypeDTOExtensions
    {

        public static BasicAnimalTypeDTO MapToBasicAnimalTypeDTO(this AnimalType animaltype)
        {
            return new BasicAnimalTypeDTO
            {
                ID = animaltype.ID,
                Name = animaltype.Name

            };


        }

        public static List<BasicAnimalTypeDTO> MapToBasicAnimalTypeDTOs(this List<AnimalType> animaltypes)
        {
            return animaltypes.Select(a => a.MapToBasicAnimalTypeDTO()).ToList();
        }

    }


}
