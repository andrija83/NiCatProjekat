using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NiCATPortal.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Morate uneti lozinku")]
        [MaxLength(50, ErrorMessage = "Maksimalna dužina lozinke je 50 karaktera")]
        [Display(Name = "Lozinka")]
        public string password { get; set; }
        [Required(ErrorMessage = "Morate uneti ime i prezime")]
        [MaxLength(100,ErrorMessage ="Maksimalna dužina imena i prezimena je 100 karaktera")]
        [Display(Name ="Ime i prezime")]
        public string FullName { get; set; }
    }

    public class Administrator : Person
    {

    }

    public class Teacher : Person
    {
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Literature> Literature { get; set; }
    }

    public class Student : Person
    {
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Homework> Homework { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
    }
}
