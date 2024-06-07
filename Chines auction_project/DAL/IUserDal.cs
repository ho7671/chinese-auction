﻿using Chines_auction_project.Modells;

namespace Chines_auction_project.DAL
{
    public interface IUserDal
    {
        Task<List<User>> GetAllusers();
        Task<User> Register(User user);
        //Task<User> Login(string userName,string password);

        Task<User> RemoveUser(int id);
        Task<User> UpdateUser(User user, int id);
    }
}