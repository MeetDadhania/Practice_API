using Microsoft.AspNetCore.Mvc;
using Model;

namespace Practice_API.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentsController : ControllerBase
    {
        //Creating Dummy Students list
        private List<Students> students = new List<Students>()
        {
            new Students(1,"Meet",22,"meetptl@gmail.com",9962738672),
            new Students(2,"Leet",30,"leetcdl@gmail.com",8928736738),
            new Students(3,"Jeet",20,"jeetclk@gmail.com",9726794936),
            new Students(4,"Geet",19,"geetkip@gmail.com",9873637478),
        };


        /// <summary>
        /// Get Details of all the students
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetStudentsDetails")]
        public List<Students> GetStudentsDetails()
        {
            return students;
        }

        /// <summary>
        /// upload the Details of the student
        /// </summary>
        /// <returns></returns>
        [HttpPost("PostStudentDetails")]
        public List<Students> UploadStudentDetails(Students student)
        {
            students.Add(student);
            return students;
        }

        /// <summary>
        /// Update the Details of the student
        /// </summary>
        /// <returns></returns>
        [HttpPut(Name = "UpdateStudentDetails")]
        public List<Students> UpdateStudentDetails(Students student)
        {
            students[0] = student;
            return students;
        }

        /// <summary>
        /// Delete the Details of the student
        /// </summary>
        /// <returns></returns>
        [HttpDelete(Name  = "DeleteStudentDetails")]
        public List<Students> DeleteStudentDetails()
        {
            students.RemoveAt(0);
            return students;
        }
    }
}
    