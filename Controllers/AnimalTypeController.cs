using System;
using System.Linq;
using AnimalCollection.DTOs;
using AnimalCollection.Entities;
using AnimalCollection.Repo;
using Microsoft.AspNetCore.Mvc;

namespace AnimalCollection.Controllers
{
    public class AnimalTypeController : Microsoft.AspNetCore.Mvc.ControllerBase
    {

        private readonly IAnimalTypeRepo _repo;

        public AnimalTypeController(IAnimalTypeRepo repo)
        {
            _repo = repo;
        }

        //Get/api/animaltypes
        [HttpGet("api/animaltypes")]


        public IActionResult GetAnimalType()
        {
            var animalTypes = _repo.
                 GetAllAnimalTypes()
                .Select(a => new AnimalTypeDTO
                {
                    ID = a.ID,
                    Name = a.Name,
                })
                .OrderBy(x => x.ID)
                ;
            return Ok(animalTypes);
        }

        //GET/api/artist/id
        [HttpGet("api/animaltypes/{id}")]

        public IActionResult GetAnimalTypeByID(int id)
        {

            AnimalType animalType = _repo.GetAnimalTypeByID(id);
            if (animalType is null)
            {
                return NotFound("Could not find animaltype with ID " + id);


            }
            AnimalTypeDTO animalTypeDTO = MapAnimalTypeToAnimalTypeDTO(animalType);

            return Ok(animalTypeDTO);
        }


        [HttpPost("api/animaltypes")]
        public IActionResult CreateAnimalType([FromBody] CreateAnimalTypeDTO createAnimalTypeDTO)
        {
            AnimalType createdAnimalType = _repo.CreateAnimalType(createAnimalTypeDTO);
            AnimalTypeDTO animalTypeDTO = MapAnimalTypeToAnimalTypeDTO(createdAnimalType);

            return CreatedAtAction(nameof(GetAnimalTypeByID),
            new { id = animalTypeDTO.ID },
            animalTypeDTO);

        }


        [HttpPut("api/animaltypes/{id}")]
        public IActionResult UpdateArtist([FromBody] AnimalType animalType)
        {
            AnimalType updatedAnimalType = _repo.UpdateAnimalType(animalType);
            AnimalTypeDTO animalTypeDTO = MapAnimalTypeToAnimalTypeDTO(updatedAnimalType);
            return Ok(animalTypeDTO);
        }

        [HttpDelete("api/animaltypes/{id}")]
        public IActionResult DeleteAnimalType(int id)
        {
            _repo.DeleteAnimalType(id);
            return NoContent();
        }



        private AnimalTypeDTO MapAnimalTypeToAnimalTypeDTO(AnimalType animalType)
        {
            return new AnimalTypeDTO
            {

                ID = animalType.ID,
                Name = animalType.Name,
                


            };
        }


    }
}
