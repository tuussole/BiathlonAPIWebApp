namespace BiathlonAPIWebApp.Models
{
    public class BiathlonistCupPrize
    {
        public int Id { get; set; }
        public int BiathlonistId { get; set; }
        public int PrizeId { get; set; }
        public int CupId { get; set; }

        public virtual Cup Cup { get; set; }
        public virtual Prize Prize { get; set; }
        public virtual Biathlonist Biathlonist { get; set; }
    }
}
