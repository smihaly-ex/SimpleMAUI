using System.ComponentModel.DataAnnotations;

namespace SimpleMAUI.BLL.Models
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Text { get; set; }
        public required string Image { get; set; }
    }
}
