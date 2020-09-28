using System.Collections.Generic;
using System.Threading.Tasks;

using ManageCourses_ms.Domain.Models;
using ManageCourses_ms.Domain.Services.Communication;

namespace ManageCourses_ms.Domain.Services
{
    public interface IEstudiantesService
    {
        Task<IEnumerable<Estudiantes>> ListAsync();
        Task<EstudiantesResponse> SaveAsync(Estudiantes estudiantes);
        Task<EstudiantesResponse> UpdateAsync(string id, Estudiantes estudiante);
        Task<EstudiantesResponse> GetAsync(string id);
        Task<EstudiantesResponse> DeleteAsync(string id);
    }
}