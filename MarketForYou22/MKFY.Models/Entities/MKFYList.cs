using MKFY.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Models.Entities
{
    public class MKFYList
    {
        // Default constructor to allow creation of an empty item entity
        public MKFYList()
        {
        }

        // Constructor used to create a new Game from a item  model
        public MKFYList(MKFYListAddVM src, string userId)
        {
            ItemName  = src.ItemName;
            ItemDescription = src.ItemDescription;
            PickAddress = src.PickAddress;
            ItemCity = src.ItemCity;
            ItemPrice = src.ItemPrice;
            ItemCategory = src.ItemCategory;                             
            UserID = userId;
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string ItemName{ get; set; } = string.Empty;

        [Required]
        public string ItemDescription { get; set; } = string.Empty;

        [Required]
        public string ItemCondition { get; set; } = string.Empty;
        [Required]
        public string ItemCategory { get; set; } = string.Empty;

        [Required]
        public string PickAddress { get; set; } = string.Empty;
         public bool IsSold { get; set; } 
        // list items city name and find the items with city name 
        [Required]
        public string ItemCity { get; set; } = string.Empty;

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public decimal ItemPrice { get; set; }

        public string? BuyerId { get; set; }

        // Relationships 
        [Required]
        public string UserID { get; set; } = String.Empty;
        public string? UserId { get; internal set; }

        public User? User { get; set; }

    }
}
