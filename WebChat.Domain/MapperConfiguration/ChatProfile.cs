using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.Domain.ChatModels;

namespace WebChat.Domain.MapperConfiguration
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            CreateMap<CreateChatModel, Chat>().ForMember(c => c.Id, opt => opt.Ignore()).ForMember(c => c.Name, opt => opt.MapFrom(m => m.Name)).ForMember(c => c.IsActive, opt => opt.MapFrom(m => bool.TrueString));
            CreateMap<(CreateChatModel model, int chatId), ChatUser>().ForMember(c => c.UserId, opt => opt.MapFrom(data => data.model.UserId)).ForMember(c => c.ChatId, opt => opt.MapFrom(data => data.chatId));
            CreateMap<AddUserToChatModel, ChatUser>();
        }
    }
}
