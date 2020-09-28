using System.Collections.Generic;

namespace ManageCourses_ms.Resources
{
    public class CursosEstudiantesResource
    {
        public int grado { get; set; }
        public string letra { get; set; }
        public IList<int> id_estudiante { get; set; } = new List<int>();
    }
}