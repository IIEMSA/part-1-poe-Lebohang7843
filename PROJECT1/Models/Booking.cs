using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJECT1.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public int EventID { get; set; }

        [Required]
        public int VenueID { get; set; }

        public Event? Event { get; set; } // Navigation property to Event
    }
}

