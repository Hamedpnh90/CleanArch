using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CourseServices : ICourseServices
    {
        ICourseRepository _courseRepository;

        public CourseServices(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;   
        }

        public Course GetCourseById(int Id)
        {
            return _courseRepository.GetCourseById(Id); 
        }

        public CourseViewModel GetCourses()
        {
            return new CourseViewModel()
            {
                courses = _courseRepository.GetCourses()   
            };
        }
    }
}
