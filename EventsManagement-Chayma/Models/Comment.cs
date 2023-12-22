using System.ComponentModel.DataAnnotations;

namespace EventsManagement_Chayma.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        [Required(ErrorMessage = "The comment date is required !!!")]
        [RegularExpression(@"^(0[1-9]|1[0-9]|2[0-9]|3[0-1])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "You must set a valid date")]
        public string CommentDate { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; } = null!;
    }
}
