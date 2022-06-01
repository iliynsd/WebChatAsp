using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebChat.DAL.Entities;
using WebChat.DAL.Repositories;
using WebChat.Domain.Models;
using WebChat.IdentityServer;

namespace WebChat.Domain.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IIdentityService _identityService;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IIdentityService identityService, IMapper mapper)
        {
            _userRepository = userRepository;
            _identityService = identityService;
            _mapper = mapper;
        }
        public async Task<AuthenticateResponse> Authenticate(LoginModel model)
        {
            var user = await _userRepository.Get(model.Email);
            if (user == null)
            {
                //add logger
                return null;
            }

            var token = _identityService.GenerateJwtToken(user);
            return _mapper.Map<AuthenticateResponse>((user, token));
        }

        public async Task<AuthenticateResponse> Register(LoginModel model)
        {
            var user = _mapper.Map<User>(model);
            await _userRepository.Add(user);
            var authenticateResponse =  await Authenticate(model);
            return authenticateResponse;
        }
    }
}