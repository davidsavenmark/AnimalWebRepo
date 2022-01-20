using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AnimalCollection.DTOs;

namespace AnimalCollection.Entities
{
    public class AnimalType
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Animal> Animals { get; set; }

    }
}
