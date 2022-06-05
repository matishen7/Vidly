using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dto
{
    public class CustomerDto
    {

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNews { get; set; }

        public int MembershipTypeId { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}