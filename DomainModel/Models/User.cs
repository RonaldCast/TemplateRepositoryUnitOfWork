using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel.Models
{
    public class User : Entity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public IList<UserProduct> UserProduct { get; set; }

        public string IdentityId { get; set; }
    }
}
