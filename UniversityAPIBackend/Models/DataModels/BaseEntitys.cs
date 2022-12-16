﻿
using System.ComponentModel.DataAnnotations;

namespace UniversityAPIBackend.Models.DataModels
{
    public class BaseEntitys
    {
        [Required]
        [Key]
        public int Id { get; set; }

        //public int UserID { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public string UpdatedBy { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public string DeletedBy { get; set; } = string.Empty;

        public DateTime? DeletedAt { get; set; }

        public bool IsDeleted { get; set; } = false;





    }
}
