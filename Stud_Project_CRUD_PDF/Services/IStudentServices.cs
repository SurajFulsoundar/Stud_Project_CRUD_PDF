﻿using Stud_Project_CRUD_PDF.Models;

namespace Stud_Project_CRUD_PDF.Services
{
    public interface IStudentServices
    {
        int AddStudent(Student student);
        IEnumerable<Student> GetStudentByTitle(string Accept, string SearchBy);
        IEnumerable<Student> GetAllStudent();
        int DeleteStudent(int id);
        Student GetStudentById(int id);
        int updateStudent(Student student);
    }
}
