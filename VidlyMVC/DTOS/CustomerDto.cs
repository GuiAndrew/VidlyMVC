﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyMVC.Models;

namespace VidlyMVC.DTOS
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a valid name!")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public byte MembershipTypeId { get; set; } //To use as a foreign key.
    }
}