using AutoMapper;
using ManageCourses_ms.Domain.Models;
using ManageCourses_ms.Resources;

namespace ManageCourses_ms.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Cursos, CursosResource>();
            CreateMap<Cursos, CursosEstudiantesResource>();
            CreateMap<Cursos, CursoNoIdResource>();
            CreateMap<Estudiantes, EstudianteResource>();
        }
    }
}