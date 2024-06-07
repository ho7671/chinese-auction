using Chines_auction_project.DAL;
using Chines_auction_project.Modells;

namespace Chines_auction_project.BLL
{
    public class PurchaseService: IPurchaseService
    {
        private readonly IPurchaseDal _purchaseDal;
        public PurchaseService(IPurchaseDal _purchaseDal)
        {
            this._purchaseDal = _purchaseDal;
        }

        public async Task<List<Purchase>> GetAllPurchase()
        {
            return await _purchaseDal.GetAllPurchase();
        }
        //public Purchase GetPurchaseByPresent(Present present);
        public async Task<List<Purchase>> GetAllPurchaseById(int userId)
        {
            return await _purchaseDal.GetAllPurchaseById(userId);
        }
        public async Task<Purchase> GetShoppingCartById(int userId)
        {
            return await _purchaseDal.GetShoppingCartById(userId);
        }
        public async Task<Purchase> AddPurchase(Purchase purchase)//change thr status and pay
        {
            return await _purchaseDal.AddPurchase(purchase);
        }
        //Task<List<Purchase> GetPurchaseByPresent(Present present);
        //Task<Purchase> AddNullPurchase(Purchase purchase);
    

    }
}
