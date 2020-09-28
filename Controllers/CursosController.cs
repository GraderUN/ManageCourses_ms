using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using ManageCourses_ms.Domain.Models;
using ManageCourses_ms.Domain.Services;
using ManageCourses_ms.Resources;
using ManageCourses_ms.Extensions;

namespace ManageCourses_ms.Controllers
{
    [Route("/[controller]")]
    public class CursosController : Controller
    {
        private readonly IEstudiantesService _estudiantesService;
        private readonly ICursosService _cursosService;
        private readonly IMapper _mapper;
        
        public CursosController(IEstudiantesService estudiantesService, ICursosService cursosService, IMapper mapper)
        {
            _cursosService = cursosService;
            _mapper = mapper;
            _estudiantesService = estudiantesService;
        }

        [HttpGet]
        public async Task<IEnumerable<CursosResource>> GetAllAsync()
        {
            var cursos = await _cursosService.ListAsync();
            var cursoResource = _mapper.Map<IEnumerable<Cursos>, IEnumerable<CursosResource>>(cursos);
            return cursoResource;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(string id)
        {
            var curso = await _cursosService.GetAsync(id);
            var result = _mapper.Map<Cursos,CursosEstudiantesResource>(curso.Curso);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCursosResource resource)
        {
            if (!ModelState.IsValid)
		        return BadRequest(ModelState.GetErrorMessages());
            
            var curso = _mapper.Map<SaveCursosResource, Cursos>(resource);
            
            var result = await _cursosService.SaveAsync(curso);

            if (!result.Success)
                return BadRequest(result.Message);

            var cursoResource = _mapper.Map<Cursos, CursosResource>(result.Curso);
            return Ok(cursoResource);
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] SaveCursosResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var curso = _mapper.Map<SaveCursosResource, Cursos>(resource);
            var result = await _cursosService.UpdateAsync(id, curso);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Curso);
        }*/

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var cursoDelete = await _cursosService.GetAsync(id);
            if (!cursoDelete.Success)
                return BadRequest(cursoDelete.Message);

            var result = await _cursosService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            foreach (string Id in cursoDelete.Curso.id_estudiante) 
            {
                var res = await _estudiantesService.DeleteAsync(Id);
                if (!res.Success)
                    return BadRequest(res.Message);
            }

            return Ok(result.Curso);
        }
    }
}