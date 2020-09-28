using System.ComponentModel.DataAnnotations;


namespace ManageCourses_ms.Resources
{
    public class UpdateEstudiante
    {
        [Required]
        public string id_curso { get; set; }
    }
}
