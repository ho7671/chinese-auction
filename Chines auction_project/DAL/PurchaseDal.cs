using AutoMapper;
using Chines_auction_project.Modells;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Chines_auction_project.DAL
{
    public class PurchaseDal : IPurchaseDal
    {
        private readonly AuctionContex auctionContex;
        public PurchaseDal(AuctionContex auctionContex)
        {
            this.auctionContex = auctionContex;
        }
        public async Task<List<Purchase>> GetAllPurchase()
        {
            try
            {
                return await auctionContex.Purchase.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Purchase>> GetAllPurchaseById(int userId)
        {
            try
            {
                var purchases = await auctionContex.Purchase.Where(c => c.UserId == userId & c.Status == true).ToListAsync();
                if (purchases == null)
                    throw new Exception($"user {userId} not found");
                return purchases;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Purchase> GetShoppingCartById(int userId)
        {
            try
            {
                var purchases = await auctionContex.Purchase.FirstOrDefaultAsync(c => c.UserId == userId & c.Status == false);
                if (purchases == null)
                {
                    //    var p=
                    //    var d = mapper.Map<Purchase>(p);
                    //var t=new Purchase()
                    //add null purchase...
                    throw new Exception($"user {userId} not found");
                }
                return purchases;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Purchase> AddPurchase(Purchase purchase)//change thr status and pay
        {
            try
            {
                var purchases = await auctionContex.Purchase.FirstOrDefaultAsync(c => c.Id == purchase.Id & c.Status == false);

                purchases.Status = true;
                auctionContex.SaveChanges();
                return purchase;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<Purchase>> GetPurchaseByPresent(Present present)
        {
            try
            {

                List<Purchase> purchases1 = await auctionContex.Purchase
                .Where(p => p.Tickets.Any(t => t.PresentId == present.Id))
                .ToListAsync();
                return purchases1;
                //var p=await auctionContex.Purchase.Include(Ticket).Where(c => c.PresentId == present.Id)

            }
            catch (Exception)
            {

                throw;
            }
        }
            
       // {
       //     try
       //     {
       //     var c = await auctionContex.Purchase.include(Ticket).Where(c => c.PresentId == present.id)
       //     var present = await auctionContex.Purchase.Where(c => c.PresentId == present.id);
       //     }
       //     catch(Exception)
       //     {
       //         throw;
       //     }
       //}

     }
}
