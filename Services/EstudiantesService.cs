using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using ManageCourses_ms.Domain.Models;
using ManageCourses_ms.Domain.Services;
using ManageCourses_ms.Domain.Repositories;
using ManageCourses_ms.Domain.Services.Communication;
using AutoMapper;
using ManageCourses_ms.Resources;

namespace ManageCourses_ms.Services
{
    public class EstudiantesService : IEstudiantesService
    {

        private readonly IEstudiantesRepository _estudiantesRepository;
        private readonly IMapper _mapper;

        public EstudiantesService(IEstudiantesRepository estudiantesRepository, IMapper mapper)
        {
            _estudiantesRepository = estudiantesRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Estudiantes>> ListAsync()
        {
            return await _estudiantesRepository.ListAsync();
        }

        public async Task<EstudiantesResponse> GetAsync(string id){
            var existingEstudiante = await _estudiantesRepository.FindByIdAsync(id);

            if (existingEstudiante == null)
                return new EstudiantesResponse("Student not found.");

            return new EstudiantesResponse(existingEstudiante);
        }

        public async Task<EstudiantesResponse> SaveAsync(Estudiantes estudiante){
            try
            {
                var curso = await _estudiantesRepository.FindCourseAsync(estudiante.id_curso);
                if (curso == null)
                    return new EstudiantesResponse("Course not found.");

                estudiante.curso = _mapper.Map<Cursos, CursoNoIdResource>(curso);
                await _estudiantesRepository.AddAsync(estudiante);
                
                return new EstudiantesResponse(estudiante);
            }
            catch (Exception ex)
            {
                return new EstudiantesResponse($"An error occurred when saving the student: {ex.Message}");
            }
        }

        public async Task<EstudiantesResponse> UpdateAsync(string id, Estudiantes estudiante)
        {
            var existingStudent = await _estudiantesRepository.FindByIdAsync(id);

            if (existingStudent == null)
                return new EstudiantesResponse("Student not found.");

            var updateCurso = await _estudiantesRepository.FindCourseAsync(estudiante.id_curso);
            if (updateCurso == null)
                return new EstudiantesResponse("Course Updated not found.");

            existingStudent.id_curso = estudiante.id_curso;
            existingStudent.curso = _mapper.Map<Cursos, CursoNoIdResource>(updateCurso);

            try
            {
                _estudiantesRepository.Update(existingStudent);

                return new EstudiantesResponse(existingStudent);
            }
            catch (Exception ex)
            {
                return new EstudiantesResponse($"An error occurred when updating the student: {ex.Message}");
            }
        }

        public async Task<EstudiantesResponse> DeleteAsync(string id) {
            var existingStudent = await _estudiantesRepository.FindByIdAsync(id);

            if (existingStudent == null)
                return new EstudiantesResponse("Course not found.");

            try
            {
                _estudiantesRepository.Remove(existingStudent);
                return new EstudiantesResponse(existingStudent);
            }
            catch (Exception ex)
            {
                return new EstudiantesResponse($"An error occurred when deleting the course: {ex.Message}");
            }
        }

    }
}