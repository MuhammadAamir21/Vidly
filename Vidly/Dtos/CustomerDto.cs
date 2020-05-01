using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    //Since the Customer model is our domain model
    //And it is called the implementaion details which change frequently
    //So due to those changes arries the api of might break
    //Hacker can pass additional data as well to the domain object
    //To prevent this from happing we create a Dto(Data Transfer Object) as a contract of this api
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}