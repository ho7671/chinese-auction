﻿namespace Chines_auction_project.Modells
{
    public class Ticket
    {
        public int Id { get; set; }
        public int? PresentId { get; set; }
        public int? PurchaseId { get; set; }
        public Present? Present { get; set; }
        public Purchase? purchase { get; set; }

    }
}
