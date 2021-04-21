using AutoMapper;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using System;
using System.Linq;

namespace ManagerAPI.Services.Profiles
{
    /// <summary>
    /// Task profile for auto mapper
    /// </summary>
    public class TaskProfile : Profile
    {
        /// <summary>
        /// Task Mapper
        /// </summary>
        public TaskProfile()
        {
            this.CreateMap<Task, TaskDto>();
            this.CreateMap<IGrouping<DateTime, Task>, TaskDateDto>()
                .ForMember(dest => dest.Deadline, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.TaskList, opt => opt.MapFrom(src => src.ToList()))
                .ForMember(dest => dest.OutOfRange,
                    opt => opt.MapFrom(src =>
                        src.Key < DateTime.Now && src.Count(x => !x.IsSolved) != 0))
                .ForMember(dest => dest.AllSolved,
                    opt => opt.MapFrom(src => src.ToList().All(x => x.IsSolved)));
            this.CreateMap<TaskModel, Task>()
                .ForMember(dest => dest.Deadline, opt => opt.MapFrom(src => (DateTime)src.Deadline));
            this.CreateMap<Task, TaskListDto>();
        }
    }
}