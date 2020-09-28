using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using ManageCourses_ms.Domain.Models;
using ManageCourses_ms.Domain.Repositories;

using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;

namespace ManageCourses_ms.Persistence.Repositories
{
    public class EstudiantesRepository : BaseRepository, IEstudiantesRepository
    {
        public EstudiantesRepository() : base(){ }

        public async Task<IEnumerable<Estudiantes>> ListAsync()
        {
            return await _estudiantes.Find(estudiante => true).ToListAsync();
        }

        public async Task AddAsync(Estudiantes estudiante)
	    {
            await _estudiantes.InsertOneAsync(estudiante);
        }

        public async Task<Estudiantes> FindByIdAsync(string id)
        {
            return await _estudiantes.Find<Estudiantes>(estudiante => estudiante.id_estudiante == id).FirstOrDefaultAsync();
        }

        public async Task<Cursos> FindCourseAsync(string id)
        {
            return await _cursos.Find<Cursos>(curso => curso.id == id).FirstOrDefaultAsync();
        }

        public void Update(Estudiantes newEstudiante)
        {
            _estudiantes.ReplaceOneAsync(estudiante => estudiante.id == newEstudiante.id, newEstudiante);
        }

        public void Remove(Estudiantes deleteEstudiante)
        {
            _estudiantes.DeleteOne(estudiante => estudiante.id_estudiante == deleteEstudiante.id_estudiante);
        }
    }
}