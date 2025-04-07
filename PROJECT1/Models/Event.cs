using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PROJECT1.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        
        public string Description { get; set; }

        [Required]
        public int VenueID { get; set; }

        public Venue Venue { get; set; } // Navigation property to Venue    
    }
}
