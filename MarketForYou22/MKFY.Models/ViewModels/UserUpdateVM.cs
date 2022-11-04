using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Models.ViewModels
{
    public class UserUpdateVM
    {
        [Required]
        public string Id { get; set; } = String.Empty;

        [Required]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        public string LastName { get; set; } = String.Empty;

        [Required]
        public string Phone { get; set; } = String.Empty;

        [Required]
        public string UserAddress { get; set; } = String.Empty;
        [Required]
        public string UserCity { get; set; }= String.Empty;
    }
}
