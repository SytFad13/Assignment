using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonApp.Domain.POCO; 
using PersonApp.Services.Abstractions;

namespace PersonApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly IPersonService _personService;

		public PersonController(IPersonService personService)
		{
			_personService = personService;
		}

		[HttpGet]
		public async Task<ActionResult<ICollection<Person>>> GetAll()
		{
			var persons = await _personService.GetAllAsync();

			return Ok(persons);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<Person>> GetById(int id)
		{
			var person = await _personService.GetByIdAsync(id);

			if (person == null)
			{
				return NotFound();
			}

			return Ok(person);
		}

		[HttpPost]
		public async Task<ActionResult<Person>> Create(Person person)
		{
			await _personService.CreateAsync(person);

			if (person == null)
			{
				return new BadRequestObjectResult("Person with given name already exists");
			}

			return Ok(person);
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<ActionResult<Person>> Update(int id, Person person)
		{
			person.PersonId = id;

			var result = await _personService.UpdateAsync(person);

			if (result == null)
			{
				return new BadRequestObjectResult("Person not exists");
			}

			return Ok(person);
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var response = await _personService.DeleteAsync(id);

			if (!response)
			{
				return StatusCode(404);
			}

			return Ok();
		}

		[HttpGet]
		[Route("{text}/" + nameof(GetByPart))]
		public async Task<ActionResult> GetByPart(string text)
		{
			var person = await _personService.GetByText(text);

			if (person == null)
			{
				return new BadRequestObjectResult("Person not exists");
			}

			return Ok(person);
		}
	}
}
