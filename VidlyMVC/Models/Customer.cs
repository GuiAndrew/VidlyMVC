using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyMVC.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        //Property of navigation:
        public MembershipType MembershipType { get; set; } //One to.
        public byte MembershipTypeId { get; set; } //To use as a foreign key.
    }
}