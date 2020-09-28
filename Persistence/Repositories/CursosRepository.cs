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
    public class CursosRepository : BaseRepository, ICursosRepository 
    {

        public CursosRepository() : base(){ }

        public async Task<IEnumerable<Cursos>> ListAsync()
        {
            return await _cursos.Find(curso => true).ToListAsync();
        }

        public async Task AddAsync(Cursos curso)
	    {
		    await _cursos.InsertOneAsync(curso);
	    }

        public async Task<Cursos> FindByIdAsync(string id)
        {
            return await _cursos.Find<Cursos>(curso => curso.id == id).FirstOrDefaultAsync();
        }
        
	    public void Update(Cursos newCurso)
        {
            _cursos.ReplaceOneAsync(curso => curso.id == newCurso.id, newCurso);
        }

        public void Remove(Cursos deleteCurso)
        {
            _cursos.DeleteOne(curso => curso.id == deleteCurso.id);
        }
    }
}