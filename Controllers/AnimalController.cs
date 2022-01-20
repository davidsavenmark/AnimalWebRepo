using System;
using System.Linq;
using AnimalCollection.DTOs;
using AnimalCollection.Entities;
using AnimalCollection.Repo;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace AnimalCollection.Controllers
{
    public class AnimalController: Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly IAnimalRepo _repo;

        public AnimalController(IAnimalRepo repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        [Route("api/animals")]
        public IActionResult GetAnimals()
        {
            var animals = _repo.
                 GetAll()
                .ToList()
                .MapToAnimalDTOs();
                return Ok(animals);
        }
        
        [HttpGet("api/animals/{id}")]
        public IActionResult GetAnimalByID(int id)
        {

            Animal animal = _repo.GetByID(id);
            if (animal == null)
            {
                return NotFound("Could not find vinyl with ID " + id);          
            }
            AnimalDTO animalDTO = MapToAnimalDTOs(animal);
            return Ok(animalDTO);
        }

        [HttpPost("api/animals")]
        public IActionResult CreateAnimal([FromBody] CreateAnimalDTO createAnimalDTO)
        {
            Animal createdAnimal = _repo.CreateAnimal(createAnimalDTO);
            //VinylDTO vinylDTO = createdVinyl.MapToVinylDTO();

            AnimalDTO animalSavedDTO = _repo
                .GetByID(createdAnimal.ID)
                .MapToAnimalDTO();

            return CreatedAtAction(
                nameof(GetAnimalByID),
                new { id = animalSavedDTO.ID },
                animalSavedDTO);

        }

        [HttpPut("api/animals/{id}")]
        public IActionResult UpdateAnimal([FromBody] Animal animal, int id)
        {
            Animal updatedAnimal = _repo.UpdateAnimal(animal, id);

            AnimalDTO animalDTO = _repo.GetByID(id).MapToAnimalDTO();
              
            return Ok(animalDTO);
        }

        [HttpDelete("api/animals/{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            _repo.DeleteAnimal(id);
            return NoContent();
        }

        public AnimalDTO MapToAnimalDTOs(Animal animal)
        {
            return new AnimalDTO
            {
                ID = animal.ID,
                Name = animal.Name,
                AnimalType = animal.AnimalType.MapToAnimalTypeDTO(),
            };
        }
    }
}
