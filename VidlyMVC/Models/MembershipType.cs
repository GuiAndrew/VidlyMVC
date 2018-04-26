using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyMVC.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        //// This are the reference we are working in the class Min18YearsIfAMember, because he are working 
        //// only with the 0(Unknown) and the 1(PayAsYouGo), we do not need to put the all references.
        //// The alternative to the static properties, is to create a enum, and he have to cast to byte
        //// in the class Min18YearsIfAMember.
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}