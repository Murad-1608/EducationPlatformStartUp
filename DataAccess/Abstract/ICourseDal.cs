﻿using Castle.DynamicProxy.Contributors;
using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICourseDal : IRepositoryBase<Course>
    {
        List<CourseForListDto> GetCoursesForStarters();
        List<CourseForListDto> GetCoursesBestSelling();
    }
}