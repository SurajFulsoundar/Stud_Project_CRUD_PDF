using Microsoft.AspNetCore.Mvc;
using Stud_Project_CRUD_PDF.Data;
using Stud_Project_CRUD_PDF.Models;
using System.Diagnostics;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Stud_Project_CRUD_PDF.Repository
{
    public class StudentRepository : IStudentRepository
    {      
        ApplicationDbContext db;
        public StudentRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddStudent(Student student)
        {
            db.Stud.Add(student);
            int result = db.SaveChanges();
            return result;
        }

        public int DeleteStudent(int id)
        {
            int res = 0;
            var result = db.Stud.Where(x => x.Roll_Number == id).FirstOrDefault();

            if (result != null)
            {
                db.Stud.Remove(result);
                res = db.SaveChanges();
            }
            return res;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return db.Stud.ToList();
        }

        public Student GetStudentById(int id)
        {
            var res = db.Stud.Where(option => option.Roll_Number == id).SingleOrDefault();
            return res;
        }

        public IEnumerable<Student> GetStudentByTitle(string Accept, string SearchBy)
        {
            var accept = Accept;
            IEnumerable<Student> result = null;

            if (SearchBy == "Stud_Name")
            {
                result = from s in db.Stud
                         where s.Stud_Name.Contains(Accept)
                         select s;
            }
           else if (SearchBy == "Grade")
            {
                result = from s in db.Stud
                         where s.Grade.Contains(Accept)
                         select s;
            }
          else if (SearchBy == "Academic_Year")
            {
                result = from s in db.Stud
                         where s.Academic_Year == Convert.ToInt32(accept)
                         select s;
            }
            else if (SearchBy == "Standard")
            {
                result = from s in db.Stud
                         where s.Standard == accept
                         select s;
            }
            return result.ToList();            
        }

        public int updateStudent(Student student)
        {
            int result = 0;
            var model = db.Stud.Where(option => option.Roll_Number == student.Roll_Number).FirstOrDefault();
            if (model != null)
            {
                model.Stud_Name = student.Stud_Name;
                model.Grade = student.Grade;
                model.Stud_Fees_Record = student.Stud_Fees_Record;
                model.Academic_Year = student.Academic_Year;
                model.Standard = student.Standard;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}

