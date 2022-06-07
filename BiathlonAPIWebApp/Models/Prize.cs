using System.ComponentModel.DataAnnotations;

namespace BiathlonAPIWebApp.Models
{
    public class Prize
    {
        public Prize()
        {
            BiathlonistCupPrizes = new List<BiathlonistCupPrize>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Нагорода")]
        public string Name { get; set; }
        public virtual ICollection<BiathlonistCupPrize> BiathlonistCupPrizes { get; set; }
    }
}
