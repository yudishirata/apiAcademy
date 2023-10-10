using System.Diagnostics;
using ApiAcademy.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiAcademy.Controllers;

[Route("[controller]")]
public class PersonController : Controller
{
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetListPerson()
    {
        List<PersonModel> persons = new List<PersonModel>();
        persons.Add(new PersonModel(1, "Yudi"));
        persons.Add(new PersonModel(2, "João"));
        persons.Add(new PersonModel(3, "Maria"));
        persons.Add(new PersonModel(4, "José"));
        persons.Add(new PersonModel(5, "Antonio"));
        persons.Add(new PersonModel(6, "Luisa"));
        return Ok(persons);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (id == 0)
        {
            return BadRequest("Invalid Id");
        }
        return Ok();
    }

    [HttpPost]
    public IActionResult Create([FromBody] PersonModel personModel)
    {
        personModel.Name = "Teste Post";
        return StatusCode(StatusCodes.Status201Created, personModel.Id);
    }

    [HttpPut]
    public IActionResult Update([FromBody] PersonModel personModel)
    {
        if (personModel == null || personModel.Id == 0)
        {
            return BadRequest("Invalid requisition");
        }
        personModel.Name = "Teste Put";
        return Ok(personModel);
    }
}


