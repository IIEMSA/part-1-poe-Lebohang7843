using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace PROJECT1.Models
{
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }

        [Required]
        
        public string VenueName { get; set; }

        [Required]
        public string VenueLocation { get; set; } // Fixed the naming issue here

        [Required]
        public int VenueCapacity { get; set; }

        [Required]
        public string imageUrl { get; set; } // Fixed the naming issue here

    }
}
