using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }

        //To make code more readable
        //We can use enum as well but require additonal type convertion
        public static readonly byte Unknown = 0;

        public static readonly byte PayAsYouGo = 1;
    }
}