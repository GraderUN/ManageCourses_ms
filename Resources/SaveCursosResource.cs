using System.ComponentModel.DataAnnotations;

namespace ManageCourses_ms.Resources
{
    public class SaveCursosResource
    {
        [Required]
        public int grado { get; set; }
        
        [Required]
        [MaxLength(2)]
        public string letra { get; set; }
        
    }
}