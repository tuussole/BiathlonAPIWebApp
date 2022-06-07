using System.ComponentModel.DataAnnotations;

namespace BiathlonAPIWebApp.Models
{
    public class Cup
    {
        public Cup() {
            Races = new List<Race>();
            BiathlonistCupPrizes = new List<BiathlonistCupPrize>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Місце проведення")]
        public string Place { get; set; }
        [Display(Name = "Дата початку")]
        [DataType(DataType.DateTime)]
        public DateTime? BeginDate { get; set; }
        [Display(Name = "Дата закінчення")]
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Статус")]
        public string Status { get; set; }

        public virtual ICollection<Race> Races { get; set; }
        public virtual ICollection<BiathlonistCupPrize> BiathlonistCupPrizes { get; set; }


    }
}
