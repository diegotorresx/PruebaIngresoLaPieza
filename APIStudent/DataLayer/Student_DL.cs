using Dapper;
using DataObjects;
using Microsoft.Data.Sqlite;
using System.Data;

namespace DataLayer
{
    public class Student_DL
    {
        private string _conn { get; set; }
        public Student_DL(string coon) 
        {
            _conn= coon;
        }

        public void InsertStudent(StudentModel student)
        {
            using (IDbConnection db = new SqliteConnection(_conn))
            {
                string sqlQuery = "INSERT INTO Student (Username, FirstName, LastName, Age, Career) VALUES (@Username, @FirstName, @LastName, @Age, @Career)";
                db.Execute(sqlQuery, student);
            }
        }
        public List<StudentModel> GetAllStudents()
        {
            using (IDbConnection db = new SqliteConnection(_conn))
            {
                return db.Query<StudentModel>("SELECT * FROM Student").ToList();
            }
        }
        public StudentModel GetStudentById(int id)
        {
            using (IDbConnection db = new SqliteConnection(_conn))
            {
                return db.Query<StudentModel>("SELECT * FROM Student WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
        public void UpdateStudent(StudentModel student)
        {
            using (IDbConnection db = new SqliteConnection(_conn))
            {
                string sqlQuery = "UPDATE Student SET Username = @Username, FirstName = @FirstName, LastName = @LastName, Age = @Age, Career = @Career WHERE Id = @Id";
                db.Execute(sqlQuery, student);
            }
        }
        public void DeleteStudent(int id)
        {
            using (IDbConnection db = new SqliteConnection(_conn))
            {
                string sqlQuery = "DELETE FROM Student WHERE Id = @Id";
                db.Execute(sqlQuery, new { Id = id });
            }
        }
    }
}