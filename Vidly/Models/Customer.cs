using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//This model folder is purly for our domain classes
namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //Navigation Property to load object and it related object togather
        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}