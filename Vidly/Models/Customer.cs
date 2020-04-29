using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//This model folder is purly for our domain classes
namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //Navigation Property to load object and it related object togather
        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}