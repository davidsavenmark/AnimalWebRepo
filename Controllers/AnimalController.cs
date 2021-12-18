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
        [Route("api/animal")]

        public IActionResult GetAnimals()
        {
            var animals = _repo.
                 GetAll()
                .Select(a => new AnimalDTO
                {
                    Id = a.Id,
                    Name = a.Name,
                    Type = a.Type,
               
                })
                .OrderBy(x => x.Id)
                ;
            return Ok(animals);
        }

       
        [HttpGet("api/animal/{id}")]

        public IActionResult GetAnimalByID(int id)
        {

            Animal animal = _repo.GetByID(id);
            if (animal is null)
            {
                return NotFound("Could not find vinyl with ID " + id);


            }
            AnimalDTO animalDTO = MapAnimalToAnimalDTO(animal);

            return Ok(animalDTO);
        }


        [HttpPost("api/animal")]
        public IActionResult CreateAnimal([FromBody] CreateAnimalDTO createAnimalDTO)
        {
            Animal createdAnimal = _repo.CreateAnimal(createAnimalDTO);
            AnimalDTO animalDTO = MapAnimalToAnimalDTO(createdAnimal);

            return CreatedAtAction(nameof(GetAnimalByID),
            new { id = animalDTO.Id },
            createdAnimal);

        }

        [HttpPut("api/animal/{id}")]
        public IActionResult UpdateVinyl([FromBody] Animal animal)
        {
            Animal updatedAnimal = _repo.UpdateAnimal(animal);
            AnimalDTO animalDTO = MapAnimalToAnimalDTO(updatedAnimal);
            return Ok(animalDTO);
        }

        [HttpDelete("api/animal/{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            _repo.DeleteAnimal(id);
            return NoContent();
        }


        private AnimalDTO MapAnimalToAnimalDTO(Animal animal)
        {
            return new AnimalDTO
            {
                Id = animal.Id,
                Name = animal.Name,
                Type = animal.Type

            };
        }


    }
}
