using System.ComponentModel.DataAnnotations;

namespace UniversityAPIBackend.Models.DataModels
{
    public class Chapter : BaseEntitys
    {
        [Required]
        public string Chapeters { get; set; } = string.Empty;

        public int CourseId { get; set; }

        public virtual Course Course {get; set;} = new Course();
    }
}
