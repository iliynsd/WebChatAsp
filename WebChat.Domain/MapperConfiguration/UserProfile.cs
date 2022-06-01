using AutoMapper;
using WebChat.DAL.Entities;
using WebChat.Domain.Models;

namespace WebChat.Domain.MapperConfiguration
{
    public class UserProfile:Profile
    {
        public UserProfile()
        { 
            CreateMap<(User user, string token), AuthenticateResponse>().ForMember(resp => resp.Email, opt => opt.MapFrom(data => data.user.Email)).ForMember(resp => resp.Name, opt => opt.MapFrom(data => data.user.Name)).ForMember(resp => resp.Token, opt => opt.MapFrom(data => data.token));
            CreateMap<LoginModel, User>();
        }
    }
}
