namespace ApplicationCore.Dtos
{
    public class MoviePurchaseCountDto
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public int PurchaseCount { get; set; }
    }
}
