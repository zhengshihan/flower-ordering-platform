using AutoMapper;
using FlowerWebsite.Common;
using FlowerWebsite.Model.Entitys;
using FlowerWebsite.Model.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerWebsite.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly EFDbContext _context;

        public UserService(IMapper mapper, EFDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public UserRes GetUsers(UserReq req)
        {
            var user = _context.Users
                .FirstOrDefault(p => p.UserName == req.UserName && p.Password == req.Password);

            if (user != null)
            {
                return _mapper.Map<UserRes>(user);
            }

            return new UserRes();
        }

        // Implementing the method from IUserService interface
        public UserRes RegisterUser(RegisterReq req, ref string msg)
        {
            // This method is synchronous, so the async method can be called synchronously if needed
            // However, to match the interface signature, we implement it as synchronous.
            var existingUser = _context.Users
                .FirstOrDefault(p => p.UserName == req.UserName);

            if (existingUser != null)
            {
                msg = "账号已存在！";
                return _mapper.Map<UserRes>(existingUser);
            }

            try
            {
                User newUser = _mapper.Map<User>(req);
                newUser.CreateTime = DateTime.Now;
                newUser.UserType = (int)EnumUserType.普通用户;

                _context.Users.Add(newUser);
                _context.SaveChanges();

                var createdUser = _context.Users
                    .FirstOrDefault(p => p.UserName == req.UserName && p.Password == req.Password);

                return _mapper.Map<UserRes>(createdUser);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return new UserRes();
            }
        }
    }
}
