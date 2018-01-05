using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TrainingHub.Dtos;
using TrainingHub.Models;

namespace TrainingHub.App_Start
{
    public class MappingProfile : Profile
    {


        public MappingProfile()
        {

            Mapper.CreateMap<Course, CourseDto>();
            Mapper.CreateMap<CourseDto, Course>();

        }
    }
}