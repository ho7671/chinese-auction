using Chines_auction_project.Modells;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Chines_auction_project.DAL
{
    public class UserDal : IUserDal
    {
        private readonly AuctionContex auctionContex;
        public UserDal(AuctionContex auctionContex)
        {
            this.auctionContex = auctionContex;
        }
        public async Task<List<User>> GetAllusers() 
        {
            try
            {
                return await auctionContex.User.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<User> Register(User user)
        {
            try
            {
                var exist = await auctionContex.User.FirstOrDefaultAsync(c => c == user);
                if (exist != null)
                {
                   
                }
                await auctionContex.User.AddAsync(user);
                await auctionContex.SaveChangesAsync();
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //if (users.Exists(user => user.UserId == newUser.UserId))
        //        return Results.Conflict(new Exception("User already exists"));
        //    users.Add(newUser);
        //    DataService.SaveUsers(users);
        //    return Results.Ok();
        //public async Task<User> Login(string userName,string password)
        //{
        //{
            //try
            //{

            //    await auctionContex.User.AddAsync(user);
            //    await auctionContex.SaveChangesAsync();
            //    return user;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        //}
        public async Task<User> RemoveUser(int id)
        {
            try
            {
                var user = await auctionContex.User.FirstOrDefaultAsync(c => c.Id == id);
                if (user == null)
                {
                    throw new Exception($"user {id} not found");
                }
                auctionContex.User.Remove(user);
                await auctionContex.SaveChangesAsync();
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<User> UpdateUser(User user, int id)
        {
            user.Id = id;
            var donor1 = await auctionContex.User.FirstOrDefaultAsync(c => c.Id == id);
            if (donor1 == null)
            {
                throw new Exception($"donor {id} not found");
            }
            //בדיקות אם לא נל 
            if (user.FullName != "string") user.FullName = user.FullName;
            if (user.Address != "string") user.Address = user.Address;
            if (user.Email != "string") user.Email = user.Email;
            if (user.Phone != "string") user.Phone = user.Phone;
            if (user.Password != "string") user.Phone = user.Phone;
            if (user.UserName != "string") user.UserName = user.UserName;

            //auctionContex.Donor.Update(donor);
            await auctionContex.SaveChangesAsync();
            return donor1;
        }
    }
}
