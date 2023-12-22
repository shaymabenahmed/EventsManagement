using System.ComponentModel.DataAnnotations;

namespace EventsManagementAppClient.Models
{
    public class OrganizerClient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The organizer name is required !!!")]
        public string Name { get; set; } = null!;

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You must set a valid email")]
        public string Email { get; set; } = null!;

        [RegularExpression(@"^[0-9\s\-\(\)]+$", ErrorMessage = "You must set a valid phone number")]
        public string Phone { get; set; } = null!;

        public virtual ICollection<EventClient> Events { get; set; } = new List<EventClient>();
    }
}
