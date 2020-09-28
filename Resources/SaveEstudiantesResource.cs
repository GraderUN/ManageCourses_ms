using System.ComponentModel.DataAnnotations;


namespace ManageCourses_ms.Resources
{
    public class SaveEstudiantesResource
    {
        [Required]
        public string id_estudiante { get; set; }
        [Required]
        public string id_curso { get; set; }
    }
}