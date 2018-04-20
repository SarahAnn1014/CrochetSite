using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyCooksApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HappyCooksApi.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly HappyCooksContext _context;

        public ProjectController(HappyCooksContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Projects> GetAll()
        {
            return _context.Projects.ToList();
        }

        [HttpGet("{id}", Name="GetProject")]
        public IActionResult GetById(int id)
        {
            var project = _context.Projects.FirstOrDefault(t => t.Id == id);
            if(project == null)
            {
                return NotFound();
            }
            return new ObjectResult(project);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Projects project)
        {
            if(project == null)
            {
                return BadRequest();
            }
            _context.Projects.Add(project);
            _context.SaveChanges();
            return CreatedAtRoute("GetProject", new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Projects project)
        {
            if(project == null || project.Id != id)
            {
                return BadRequest();
            }
            var savedProject = _context.Projects.FirstOrDefault(t => t.Id == id);
            if(savedProject == null)
            {
                return NotFound();
            }

            savedProject.MakeTime = project.MakeTime;
            savedProject.Description = project.Description;
            savedProject.DifficultyId = project.DifficultyId;
            savedProject.DisplayName = project.DisplayName;
            savedProject.Pattern = project.Pattern;
            savedProject.Steps = project.Steps;
            savedProject.TagLine = project.TagLine;
            _context.Projects.Update(savedProject);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var project = _context.Projects.FirstOrDefault(t => t.Id == id);
            if(project == null)
            {
                return NotFound();
            }
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}