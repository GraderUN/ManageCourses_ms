using ManageCourses_ms.Domain.Models;

namespace ManageCourses_ms.Domain.Services.Communication
{
    public class EstudiantesResponse : BaseResponse
    {
        public Estudiantes Estudiante { get; private set; }

        private EstudiantesResponse(bool success, string message, Estudiantes estudiante) : base(success, message)
        {
            Estudiante = estudiante;
        }

        public EstudiantesResponse(Estudiantes estudiante) : this(true, string.Empty, estudiante)
        { }

        public EstudiantesResponse(string message) : this(false, message, null)
        { }
    }
}