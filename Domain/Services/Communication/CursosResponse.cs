using ManageCourses_ms.Domain.Models;

namespace ManageCourses_ms.Domain.Services.Communication
{
    public class CursosResponse : BaseResponse
    {
        public Cursos Curso { get; private set; }

        private CursosResponse(bool success, string message, Cursos curso) : base(success, message)
        {
            Curso = curso;
        }

        public CursosResponse(Cursos curso) : this(true, string.Empty, curso)
        { }

        public CursosResponse(string message) : this(false, message, null)
        { }
    }
}