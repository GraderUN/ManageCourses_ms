using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using ManageCourses_ms.Domain.Models;
using ManageCourses_ms.Domain.Services;
using ManageCourses_ms.Resources;
using ManageCourses_ms.Extensions;
using System;

namespace ManageCourses_ms.Controllers
{
    [Route("/[controller]")]
    public class EstudiantesController : Controller
    {
        private readonly IEstudiantesService _estudiantesService;
        private readonly ICursosService _cursosService;
        private readonly IMapper _mapper;
        
        public EstudiantesController(IEstudiantesService estudiantesService, ICursosService cursosService, IMapper mapper)
        {
            _estudiantesService = estudiantesService;
            _cursosService = cursosService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Estudiantes>> GetAllAsync()
        {
            return await _estudiantesService.ListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneAsync(string id)
        {
            var result = await _estudiantesService.GetAsync(id);
            
            return Ok(result.Estudiante);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveEstudiantesResource resource)
        {
            if (!ModelState.IsValid)
		        return BadRequest(ModelState.GetErrorMessages());

            var existe = await _estudiantesService.GetAsync(resource.id_estudiante);
            if(existe.Success)
                return BadRequest("El id de estudiante ingresado ya existe");

            var estudiante = _mapper.Map<SaveEstudiantesResource, Estudiantes>(resource);
            var updateCurso = await _cursosService.AddStudent(estudiante.id_curso, estudiante.id_estudiante);
            if (!updateCurso.Success)
                return BadRequest(updateCurso.Message);


            var result = await _estudiantesService.SaveAsync(estudiante);
            if (!result.Success) {
                await _cursosService.RemoveStudent(estudiante.id_curso, estudiante.id_estudiante);
                return BadRequest(result.Message);
            }

            var cursoResource = _mapper.Map<Estudiantes, EstudianteResource>(result.Estudiante);
            return Ok(cursoResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] UpdateEstudiante resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var estudiante = await _estudiantesService.GetAsync(id);
            var result = await _estudiantesService.UpdateAsync(id, _mapper.Map<UpdateEstudiante, Estudiantes>(resource));

            if (!result.Success)
                return BadRequest(result.Message);

            var cursoAnterior = await _cursosService.RemoveStudent(estudiante.Estudiante.id_curso, id);
            if (!cursoAnterior.Success)
                return BadRequest(result.Message);

            var cursoSiguiente = await _cursosService.AddStudent(result.Estudiante.id_curso, id);
            if (!cursoSiguiente.Success)
                return BadRequest(result.Message);

            return Ok(result.Estudiante);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var idCurso = (await _estudiantesService.GetAsync(id)).Estudiante.id_curso;

            var result = await _estudiantesService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var curso = await _cursosService.RemoveStudent(idCurso, id);
            if (!curso.Success)
                return BadRequest(result.Message);

            return Ok(result.Estudiante);
        }
    }
}