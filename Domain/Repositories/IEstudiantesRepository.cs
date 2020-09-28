using System.Collections.Generic;
using System.Threading.Tasks;

using ManageCourses_ms.Domain.Models;

namespace ManageCourses_ms.Domain.Repositories
{
    public interface IEstudiantesRepository
    {
        Task<IEnumerable<Estudiantes>> ListAsync();
        Task AddAsync(Estudiantes estudiante);
        Task<Estudiantes> FindByIdAsync(string id);
        Task<Cursos> FindCourseAsync(string id);
        void Update(Estudiantes newEstudiante);
        void Remove(Estudiantes deleteEstudiante);
    }
}