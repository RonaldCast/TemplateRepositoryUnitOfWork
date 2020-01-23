using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel.Models
{
    public class UserProduct
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public long ProductId { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
    }
}
