using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {

        private UnivercityDbContext _Context;
        public CourseRepository(UnivercityDbContext Context)
        {
            _Context = Context; 
        }

        public Course GetCourseById(int id)
        {
            return _Context.Courses.Find(id);  
        }

        public IEnumerable<Course> GetCourses()
        {
            return _Context.Courses;

        }
    }
}
