using Stud_Project_CRUD_PDF.Models;
using Stud_Project_CRUD_PDF.Repository;

namespace Stud_Project_CRUD_PDF.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository repository;
        public StudentServices(IStudentRepository repository)
        {
            this.repository = repository;
        }
        public int AddStudent(Student student)
        {
           return repository.AddStudent(student);
        }

        public int DeleteStudent(int id)
        {
            return repository.DeleteStudent(id);
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return repository.GetAllStudent();
        }

        public Student GetStudentById(int id)
        {
            return repository.GetStudentById(id);
        }

        public IEnumerable<Student> GetStudentByTitle(string Accept, string SearchBy)
        {
            return repository.GetStudentByTitle(Accept, SearchBy);
        }

        public int updateStudent(Student student)
        {
            return repository.updateStudent(student);
        }
    }
}
