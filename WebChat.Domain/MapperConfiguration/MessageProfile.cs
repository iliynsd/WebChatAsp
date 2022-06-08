using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.Domain.MessageModels;

namespace WebChat.Domain.MapperConfiguration
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<AddMessageModel, Message>().ForMember(mes => mes.Text, opt => opt.MapFrom(mod => mod.Text)).ForMember(mes => mes.UserId, opt => opt.MapFrom(mod => mod.UserId)).ForMember(mes => mes.ChatId, opt => opt.MapFrom(mod => mod.ChatId)).ForMember(mes => mes.IsActive, opt => opt.MapFrom(mod => bool.TrueString)).ForMember(mes => mes.IsViewed, opt => opt.MapFrom(mod => bool.FalseString)).ForMember(mes => mes.Time, opt => opt.MapFrom(mod => DateTime.Now));
            CreateMap<EditMessageModel, Message>().ForMember(mes => mes.Id, opt => opt.MapFrom(mod => mod.MesId)).ForMember(mes => mes.Text, opt => opt.MapFrom(mod => mod.Text)).ForMember(mes => mes.IsViewed, opt => opt.MapFrom(mod => bool.FalseString)).ForMember(mes => mes.IsActive, opt => opt.MapFrom(mod => bool.TrueString)).ForMember(mes => mes.Time, opt => opt.MapFrom(mod => DateTime.Now)).ForMember(mes => mes.UserId, opt => opt.MapFrom(mod => mod.UserId)).ForMember(mes => mes.ChatId, opt => opt.MapFrom(mod => mod.ChatId));
            CreateMap<(Message message, User user), MessageResponse>().ForMember(res => res.IsViewed, opt => opt.MapFrom(data => data.message.IsViewed)).ForMember(res => res.Time, opt => opt.MapFrom(data => data.message.Time)).ForMember(res => res.Text, opt => opt.MapFrom(data => data.message.Text)).ForMember(res => res.Author, opt => opt.MapFrom(data => data.user.Name));
        }
    }
}
