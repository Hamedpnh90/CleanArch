using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface ICourseRepository
    {
        public IEnumerable<Course> GetCourses();

        public Course GetCourseById(int id);    
    }
}
