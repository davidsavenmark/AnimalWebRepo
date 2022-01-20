using System;
using System.Collections.Generic;
using System.Linq;
using AnimalCollection.DTOs;
using AnimalCollection.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalCollection.Repo
{
    public class AnimalTypeRepo: IAnimalTypeRepo
    {
        private ApplicationContext _context;


        public AnimalTypeRepo(ApplicationContext context)
        {
            _context = context;
        }

        public AnimalType CreateAnimalType(CreateAnimalTypeDTO createAnimalTypeDTO)
        {

            AnimalType animaltype = new AnimalType();

            animaltype.Name = createAnimalTypeDTO.Name;

            animaltype.ID = _context.AnimalTypes.Max(x => x.ID) + 1;

            _context.AnimalTypes.Add(animaltype);
            _context.SaveChanges();
            return animaltype;
        }

        public void DeleteAnimalType(int id)
        {
            _context.AnimalTypes.Remove(GetAnimalTypeByID(id));
            _context.SaveChanges();
        }


        public List<AnimalType> GetAllAnimalTypes()
        {
            return _context.AnimalTypes.ToList();

        }


        public AnimalType GetAnimalTypeByID(int id)
        {
            AnimalType animalType = _context.AnimalTypes.Find(id);
            return animalType;
        }


        public AnimalType UpdateAnimalType(AnimalType animaltype)
        {
            AnimalType existingAnimalType = _context.AnimalTypes
                                            .FirstOrDefault
                                            (x => x.ID == animaltype.ID);
            if (existingAnimalType != null)
            {
                existingAnimalType.Name = animaltype.Name;
            }
            _context.SaveChanges();
            return existingAnimalType;

        }
    }
}
