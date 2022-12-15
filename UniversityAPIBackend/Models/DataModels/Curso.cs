using System.ComponentModel.DataAnnotations;

namespace UniversityAPIBackend.Models.DataModels
{
    public class Curso
    {
        [Required, StringLength(100)]
        public string? Name { get; set; }
        [Required]
        public string? Public { get; set; }
        [Required]
        public string? FullDescription { get; set; }
        [Required, StringLength(280)]
        public string? FullShortDescription { get; set;}
        [Required]
        public string? Objetive { get; set; }
        [Required]
        public string? Required { get; set; }


    }
}
