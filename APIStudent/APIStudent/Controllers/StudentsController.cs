using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using DataObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIStudent.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private string _conn { get; set; }
        private Student_BL bl { get; set; }
        public StudentsController() 
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            _conn = configuration.GetConnectionString("SQLiteConnection");
            bl = new Student_BL(_conn);
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<StudentModel> Get()
        {
            return bl.GetAllStudents();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public StudentModel Get(int id)
        {
            return bl.GetStudentById(id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] StudentModel student)
        {
            bl.InsertStudent(student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut]
        public void Put(StudentModel student)
        {
            bl.UpdateStudent(student);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.DeleteStudent(id);
        }
    }
}
