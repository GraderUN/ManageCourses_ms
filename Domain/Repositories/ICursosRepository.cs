
using System.Collections.Generic;
using System.Threading.Tasks;

using ManageCourses_ms.Domain.Models;

namespace ManageCourses_ms.Domain.Repositories
{
    public interface ICursosRepository
    {
        Task<IEnumerable<Cursos>> ListAsync();
        Task AddAsync(Cursos curso);
        Task<Cursos> FindByIdAsync(string id);
	    void Update(Cursos newCurso);
        void Remove(Cursos deleteCurso);
    }
}