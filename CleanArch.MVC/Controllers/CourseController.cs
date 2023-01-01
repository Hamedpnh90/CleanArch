using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.Controllers
{
    public class CourseController : Controller
    {
        ICourseServices _courseServices;
        public CourseController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }
        public IActionResult Index()
        {
            CourseViewModel Model = _courseServices.GetCourses();
            return View(Model);
        }

        public IActionResult GetCourse(int id)
        {
            Course course = _courseServices.GetCourseById(id);

            return View(course);    
        }
    }
}
