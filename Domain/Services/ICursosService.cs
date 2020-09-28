using System.Collections.Generic;
using System.Threading.Tasks;

using ManageCourses_ms.Domain.Models;
using ManageCourses_ms.Domain.Services.Communication;

namespace ManageCourses_ms.Domain.Services
{
    public interface ICursosService
    {
        Task<IEnumerable<Cursos>> ListAsync();
        Task<CursosResponse> SaveAsync(Cursos cursos);
        Task<CursosResponse> AddStudent(string id, string studentId);
        Task<CursosResponse> RemoveStudent(string id, string studentId);
        Task<CursosResponse> GetAsync(string id);
        Task<CursosResponse> DeleteAsync(string id);
    }
}