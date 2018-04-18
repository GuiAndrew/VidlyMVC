using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyMVC.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        //Property of navigation:
        public MembershipType MembershipType { get; set; } //One to.

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } //To use as a foreign key.
    }
}