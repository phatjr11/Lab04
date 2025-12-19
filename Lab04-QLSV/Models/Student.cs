namespace Lab04_QLSV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [StringLength(10)]
        public string StudentID { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public double AverageScore { get; set; }

        public int? FacultyID { get; set; }
        
        [StringLength(10)]
        public string Gender { get; set; } // "Nam" hoặc "Nữ"

        public DateTime? BirthDate { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}
