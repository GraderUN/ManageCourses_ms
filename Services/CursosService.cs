using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using ManageCourses_ms.Domain.Models;
using ManageCourses_ms.Domain.Services;
using ManageCourses_ms.Domain.Repositories;
using ManageCourses_ms.Domain.Services.Communication;

namespace ManageCourses_ms.Services
{
    public class CursosService : ICursosService
    {

        private readonly ICursosRepository _cursosRepository;

        public CursosService(ICursosRepository cursosRepository)
        {
            _cursosRepository = cursosRepository;
        }
        public async Task<IEnumerable<Cursos>> ListAsync()
        {
            return await _cursosRepository.ListAsync();
        }

        public async Task<CursosResponse> AddStudent(string id, string studentId)
        {
            var existingCourse = await _cursosRepository.FindByIdAsync(id);

            if (existingCourse == null)
                return new CursosResponse("The student must have an existing course id");

            Console.Write(existingCourse);

            existingCourse.id_estudiante.Add(studentId);

            try
            {
                _cursosRepository.Update(existingCourse);
                return new CursosResponse(existingCourse);
            }
            catch (Exception ex)
            {
                return new CursosResponse($"An error occurred adding the student to the course: {ex.Message}");
            }
        }

        public async Task<CursosResponse> RemoveStudent(string id, string studentId)
        {
            var existingCourse = await _cursosRepository.FindByIdAsync(id);

            if (existingCourse == null)
                return new CursosResponse("The course you're looking for doesn't exist");

            existingCourse.id_estudiante.Remove(studentId);

            try
            {
                _cursosRepository.Update(existingCourse);
                return new CursosResponse(existingCourse);
            }
            catch (Exception ex)
            {
                return new CursosResponse($"An error occurred removing the student from the course: {ex.Message}");
            }
        }

        public async Task<CursosResponse> SaveAsync(Cursos curso){
            try
            {
                await _cursosRepository.AddAsync(curso);
                return new CursosResponse(curso);
            }
            catch (Exception ex)
            {
                return new CursosResponse($"An error occurred when saving the course: {ex.Message}");
            }
        }

        /*public async Task<CursosResponse> UpdateAsync(string id, Cursos curso)
        {
            var existingCourse = await _cursosRepository.FindByIdAsync(id);

            if (existingCourse == null)
                return new CursosResponse("Course not found.");

            existingCourse.grado = curso.grado;
            existingCourse.letra = curso.letra;

            try
            {
                _cursosRepository.Update(existingCourse);
                return new CursosResponse(existingCourse);
            }
            catch (Exception ex)
            {
                return new CursosResponse($"An error occurred when updating the Course: {ex.Message}");
            }
        }*/

        public async Task<CursosResponse> GetAsync(string id){
            var existingCourse = await _cursosRepository.FindByIdAsync(id);

            if (existingCourse == null)
                return new CursosResponse("Course not found.");

            return new CursosResponse(existingCourse);
        }

        public async Task<CursosResponse> DeleteAsync(string id){
            var existingCurso = await _cursosRepository.FindByIdAsync(id);

            if (existingCurso == null)
                return new CursosResponse("Course not found.");

            try
            {
                _cursosRepository.Remove(existingCurso);
                return new CursosResponse(existingCurso);
            }
            catch (Exception ex)
            {
                return new CursosResponse($"An error occurred when deleting the course: {ex.Message}");
            }
        }
    }
}