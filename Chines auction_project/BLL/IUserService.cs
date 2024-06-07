using Chines_auction_project.Modells;

namespace Chines_auction_project.BLL
{
    public interface IUserService
    {
        Task<List<User>> GetAllusers();
        Task<User> Register(User user);
        //Task<User> Login(User user);

        Task<User> RemoveUser(int id);
        Task<User> UpdateUser(User user, int id);
    }
}