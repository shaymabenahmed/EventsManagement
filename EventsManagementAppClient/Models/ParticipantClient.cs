using System.ComponentModel.DataAnnotations;

namespace EventsManagementAppClient.Models
{
    public class ParticipantClient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        [Required(ErrorMessage = "The registration date is required !!!")]
        [RegularExpression(@"^(0[1-9]|1[0-9]|2[0-9]|3[0-1])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "You must set a valid date")]
        public string RegistrationDate { get; set; }
    }
}
