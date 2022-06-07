using System.ComponentModel.DataAnnotations;

namespace BiathlonAPIWebApp.Models
{
    public class Biathlonist
    {
        public Biathlonist()
        {
            BiathlonistCupPrizes = new List<BiathlonistCupPrize>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Дата народження")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Країна")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Статус")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Номер у рейтингу")]
        [Range(0, 100)]
        public int Rating { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Стать")]
        public string Sex { get; set; }
        public virtual ICollection<BiathlonistCupPrize> BiathlonistCupPrizes { get; set; }

    }
}
