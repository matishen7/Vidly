using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNews { get; set; }
        public MembershipType MembershipType { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}