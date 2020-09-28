using ManageCourses_ms.Domain.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;
using System;

namespace ManageCourses_ms.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly MongoClient _client;
        protected readonly IMongoCollection<Cursos> _cursos;
        protected readonly IMongoCollection<Estudiantes> _estudiantes;


        public BaseRepository()
        {
            _client = new MongoClient(Environment.GetEnvironmentVariable("DB_Connection"));
            _cursos = _client.GetDatabase("GraderDB").GetCollection<Cursos>("Courses");
            _estudiantes = _client.GetDatabase("GraderDB").GetCollection<Estudiantes>("Students");
        }
    }
}