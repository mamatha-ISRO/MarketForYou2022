using MKFY.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Models.Entities
{
    public class User
    {
        public User() { }

        public User(UserAddVM src)
        {
            Id = src.Id;
            FirstName = src.FirstName;
            LastName = src.LastName;
            Email = src.Email;
            Phone = src.Phone;
        }

        public User(UserUpdateVM src)
        {
            Id = src.Id;
            FirstName = src.FirstName;
            LastName = src.LastName;
            Phone = src.Phone;
        }

        [Required]
        [Key]
        public string Id { get; set; } = String.Empty;

        [Required]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        public string LastName { get; set; } = String.Empty;

        [Required]
        public string Email { get; set; } = String.Empty;

        [Required]
        public string Phone { get; set; } = String.Empty;

        public string UserAddress { get; set; }=String.Empty;
        public string UserCity { get; set; }=String.Empty;

        //  market item items  user created
        public ICollection<MKFYList> MKFYListItems { get; set; } = new List<MKFYList>();
    }
}
