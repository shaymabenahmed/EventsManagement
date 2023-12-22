using System.ComponentModel.DataAnnotations;

namespace EventsManagementAppClient.Models
{
    public class EventClient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The event title is required !!!")]
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Location { get; set; } = null!;

        [Required(ErrorMessage = "The event start date is required !!!")]
        [RegularExpression(@"^(0[1-9]|1[0-9]|2[0-9]|3[0-1])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "You must set a valid date")]
        public string StartDate { get; set; } = null!;

        [Required(ErrorMessage = "The event end date is required !!!")]
        [RegularExpression(@"^(0[1-9]|1[0-9]|2[0-9]|3[0-1])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "You must set a valid date")]
        public string EndDate { get; set; } = null!;

        public int OrganizerId { get; set; }

        public virtual OrganizerClient? Organizer { get; set; } = null!;

        public virtual ICollection<CommentClient> ?Comments { get; set; } = new List<CommentClient>();
    }
}
