﻿using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface ICourseServices
    {
        CourseViewModel GetCourses();

        Course GetCourseById(int Id);
    }
}
