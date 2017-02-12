using System.Collections.Generic;
using NiCATPortal.Models;

namespace NiCATPortal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NiCATPortal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NiCATPortal.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            //UNCOMMENT
            var admin = new Administrator { Id = 1, FullName = "Admin", password = "admin" };
            var student1 = new Student { Id = 2, FullName = "Ana Antic", password = "anapass", Courses = new List<Course>(), Homework = new List<Homework>(), Evaluations = new List<Evaluation>() };
            var student2 = new Student { Id = 3, FullName = "Pera Peric", password = "perapass", Courses = new List<Course>(), Homework = new List<Homework>(), Evaluations = new List<Evaluation>() };
            var cv1 = new CV { Id = 1, FileName = "CV_Ana_Antic.doc", Student = student1 };
            var cv2 = new CV { Id = 2, FileName = "CV_Pera_Peric.doc", Student = student2 };
            var teacher1 = new Teacher { Id = 4, FullName = "Mika Mikic", password = "mikapass", Courses = new List<Course>(), Literature = new List<Literature>() };
            var teacher2 = new Teacher { Id = 5, FullName = "Petar Petrovic", password = "petarpass", Courses = new List<Course>(), Literature = new List<Literature>() };

            var course1 = new Course { Id = 1, Name = "Metodologije i alati za razvoj softvera", Year = DateTime.Parse("01/01/2016"), Students = new List<Student>(), Teachers = new List<Teacher>(), Literatures = new List<Literature>(), Homework = new List<Homework>(), Evaluations = new List<Evaluation>() };
            var course2 = new Course { Id = 2, Name = "Objektno orijentisano programiranje", Year = DateTime.Parse("01/02/2016"), Students = new List<Student>(), Teachers = new List<Teacher>(), Literatures = new List<Literature>(), Homework = new List<Homework>(), Evaluations = new List<Evaluation>() };
            var course3 = new Course { Id = 3, Name = "Baze podataka", Year = DateTime.Parse("01/03/2016"), Students = new List<Student>(), Teachers = new List<Teacher>(), Literatures = new List<Literature>(), Homework = new List<Homework>(), Evaluations = new List<Evaluation>() };

            student1.Courses.Add(course1);
            student1.Courses.Add(course2);
            student2.Courses.Add(course1);
            student2.Courses.Add(course2);
            student2.Courses.Add(course3);
            course1.Students.Add(student1);
            course2.Students.Add(student2);
            course1.Teachers.Add(teacher1);
            course2.Teachers.Add(teacher1);
            course3.Teachers.Add(teacher2);
            teacher1.Courses.Add(course1);
            teacher1.Courses.Add(course2);
            teacher2.Courses.Add(course3);

            var literature1 = new Literature { Id = 1, FileName = "Metodologije za RSW", Course = course1, Teacher = teacher1 };
            var literature2 = new Literature { Id = 2, FileName = "OOP_Readings", Course = course2, Teacher = teacher1 };
            var literature3 = new Literature { Id = 3, FileName = "Uvod u baze podataka - Skripta", Course = course3, Teacher = teacher2 };

            course1.Literatures.Add(literature1);
            course2.Literatures.Add(literature2);
            course3.Literatures.Add(literature3);
            teacher1.Literature.Add(literature1);
            teacher1.Literature.Add(literature2);
            teacher2.Literature.Add(literature3);

            var hw1 = new Homework { Id = 1, FileName = "Domaci.rar", Course = course1, Student = student1 };
            var hw2 = new Homework { Id = 2, FileName = "Domaci_baze.rar", Course = course3, Student = student1 };
            var hw3 = new Homework { Id = 3, FileName = "Domaci_OOP_1.rar", Course = course2, Student = student2 };
            var hw4 = new Homework { Id = 4, FileName = "Domaci_OOP_Ana.rar", Course = course2, Student = student1 };

            student1.Homework.Add(hw1);
            student1.Homework.Add(hw2);
            student1.Homework.Add(hw4);
            student2.Homework.Add(hw3);
            course1.Homework.Add(hw1);
            course2.Homework.Add(hw3);
            course2.Homework.Add(hw4);
            course3.Homework.Add(hw2);

            context.Persons.AddOrUpdate(admin);
            context.Courses.AddOrUpdate(course1);
            context.Courses.AddOrUpdate(course2);
            context.Courses.AddOrUpdate(course3);
            context.CVs.AddOrUpdate(cv1);
            context.CVs.AddOrUpdate(cv2);

        }
    }
}
