namespace MVC.ViewModels
{
    public class MovieCardViewModel
    {
        public string? Title { get; set; } = string.Empty;
        public int? Id { get; set; }
        public string? ImageUrl { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public Guid? PurchaseId { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public decimal? PurchasedPrice { get; set; }
    }
}
