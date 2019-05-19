using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi_Tutorial.Data;
using WebApi_Tutorial.Dtos;
using WebApi_Tutorial.Models;

namespace WebApi_Tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository repo;
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository repo, IMapper _mapper)
        {
            this.repo = repo;
            this._mapper = _mapper;
        }

        // GET api/person
        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            var people = await repo.GetPeople();
            return Ok(people);
        }


        // GET api/person/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var person = await repo.GetPerson(id);
            return Ok(person);
        }

        //Post api/person
        [HttpPost]
        public async Task<IActionResult> CreatePerson(Person person)
        {
            //illik azért egy csekk itt plusz egy Dto
            repo.Add(person);
            if (await repo.SaveAll())
                return StatusCode(201);

            throw new Exception("Nem Sikerült a hozzáadás");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, PersonForUpdateDto personForUpdateDto)
        {
            var personFromRepo = await repo.GetPerson(id);
            _mapper.Map(personForUpdateDto, personFromRepo);

            if (await repo.SaveAll())
                return NoContent();

            throw new Exception("Nem Sikerült a a frissítés");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var personFromRepo = await repo.GetPerson(id);
            repo.Deleted(personFromRepo);

            if (await repo.SaveAll())
                return StatusCode(201);

            throw new Exception("Nem Sikerült a a frissítés");
        }
    }
}