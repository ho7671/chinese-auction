using Chines_auction_project.Modells;

namespace Chines_auction_project.BLL
{
    public interface IPurchaseService
    {
        Task<List<Purchase>> GetAllPurchase();
        //public Purchase GetPurchaseByPresent(Present present);
        Task<List<Purchase>> GetAllPurchaseById(int userId);
        Task<Purchase> GetShoppingCartById(int userId);
        Task<Purchase> AddPurchase(Purchase purchase);//change thr status and pay
        //Task<List<Purchase> GetPurchaseByPresent(Present present);
        //Task<Purchase> AddNullPurchase(Purchase purchase);
    }
}