using AutoMapper;
using ManageCourses_ms.Domain.Models;
using ManageCourses_ms.Resources;

namespace ManageCourses_ms.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCursosResource, Cursos>();
            CreateMap<SaveEstudiantesResource, Estudiantes>();
            CreateMap<UpdateEstudiante, Estudiantes>();
        }
    }
}