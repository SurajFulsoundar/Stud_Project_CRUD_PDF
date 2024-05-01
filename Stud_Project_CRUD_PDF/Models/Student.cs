using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stud_Project_CRUD_PDF.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Roll_Number { get; set; }
        [Required]
        public string? Stud_Name { get; set; }
        [Required]
        public string Grade { get; set; }
        [Required]
        public int Stud_Fees_Record { get; set; }
        [Required]
        public int Academic_Year { get; set; }
        [Required]
        public string? Standard { get; set; }
    }
}
