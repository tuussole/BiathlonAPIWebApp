using System.ComponentModel.DataAnnotations;

namespace BiathlonAPIWebApp.Models
{
    public class Race
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Тип гонки")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Категорія гонки за статтю")]
        public string Sex { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Статус")]
        public string Status { get; set; }

        public int CupId { get; set; }

        public virtual Cup Cup { get; set; }
    }
}
