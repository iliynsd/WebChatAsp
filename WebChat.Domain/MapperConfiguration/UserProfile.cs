using AutoMapper;
using WebChat.DAL.Entities;
using WebChat.Domain.AuthenticationModels;

namespace WebChat.Domain.MapperConfiguration
{
    public class UserProfile:Profile
    {
        public UserProfile()
        { 
            CreateMap<(User user, string token), AuthenticateResponse>().ForMember(resp => resp.Name, opt => opt.MapFrom(data => data.user.Name)).ForMember(resp => resp.Token, opt => opt.MapFrom(data => data.token));
            CreateMap<LoginModel, User>().ForMember(u => u.Name, opt => opt.MapFrom(m => m.UserName)).ForMember(u => u.Password, opt => opt.MapFrom(m => m.Password)).ForMember(u => u.IsActive, opt => opt.MapFrom(x => bool.TrueString)).ForMember(u => u.Type, opt => opt.MapFrom(x => "user")).ForMember(u => u.Role, opt => opt.MapFrom(x => "user")).ForMember(u => u.Id, opt => opt.Ignore());
        }
    }
}
