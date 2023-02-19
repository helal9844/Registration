using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace BL
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        public UserManager(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public List<UserDTO> GetAllUsers()
        {
            var dbuser = _userRepo.GetAll();
            var dtouser = _mapper.Map<List<UserDTO>>(dbuser);
            return dtouser;
        }
        public UserDTO? GetUser(int id)
        {
            var dbuser = _userRepo.GetById(id);
            if (dbuser == null)
                return null;
            return _mapper.Map<UserDTO>(dbuser);
        }
        public UserDTO AddUser(UserDTO user)
        {
            var dbuser = _mapper.Map<User>(user);
            if (user.LastName == "")
                return user;
            _userRepo.Add(dbuser);
            _userRepo.SaveChanges();
            return _mapper.Map<UserDTO>(dbuser);
        }
        public bool UpdateUser(UserDTO userDTO)
        {
            var dbuser = _userRepo.GetById(userDTO.Id);
            if (dbuser == null)
                return false;
            _mapper.Map(userDTO, dbuser);
            _userRepo.Update(dbuser);
            _userRepo.SaveChanges();
            return true;
        }

        public void DeleteUser(int id)
        {
            var dbuser = _userRepo.GetById(id);
            if (dbuser == null)
                return;
            _userRepo.Delete(dbuser);
            _userRepo.SaveChanges();
        }

        public List<UserWriteDTO> GetUsersWithCountry()
        {
            var dbusers = _userRepo.GetUsersWithCountry();
            var users = _mapper.Map<List<UserWriteDTO>>(dbusers);
            return users;

        }
    }
}
