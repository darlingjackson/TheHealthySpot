using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheHealthySpot.ViewModels
{
    public class ContactViewModel//this is a convinient way to store and access our contact form properires
    {
        //Set the model for your views.

        //Validaton
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [MaxLength(500)]
        public string Message { get; set; }
    }
}
