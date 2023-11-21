using DataLayer;
using DataObjects;
using System.Data;

namespace BusinessLogic
{
    public class Student_BL
    {
        private string _conn { get; set; }
        private Student_DL dl { get; set; }
        public Student_BL(string coon)
        {
            _conn = coon;
            dl = new Student_DL(_conn);
        }

        public void InsertStudent(StudentModel student)
        {
            dl.InsertStudent(student);
        }
        public List<StudentModel> GetAllStudents()
        {
            return dl.GetAllStudents();
        }
        public StudentModel GetStudentById(int id)
        {
            return dl.GetStudentById(id);
        }
        public void UpdateStudent(StudentModel student)
        {
            dl.UpdateStudent(student);
        }
        public void DeleteStudent(int id)
        {
            dl.DeleteStudent(id);
        }
    }
}