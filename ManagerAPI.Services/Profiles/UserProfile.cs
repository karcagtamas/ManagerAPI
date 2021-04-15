using AutoMapper;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;

namespace ManagerAPI.Services.Profiles
{
    /// <summary>
    /// User profile for auto mapper
    /// </summary>
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<User, UserDto>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore())
                .ForMember(dest => dest.GenderId,
                    opt => opt.MapFrom(src => src.Gender == null ? null : (int?)src.Gender.Id))
                .ForMember(dest => dest.LastLogin, opt => opt.MapFrom(src => src.LastLogin))
                .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => src.RegistrationDate));

            this.CreateMap<UserModel, User>();
            this.CreateMap<User, UserShortDto>();
        }
    }
}