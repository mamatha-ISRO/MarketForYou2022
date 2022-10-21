using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Models.ViewModels
{
    public class MKFYlistVM
    {

        // Default constructor to allow creation of an empty ListingVM
        public MKFYlistVM() { }

        // Constructor for populating a new ListingVM from a Listing entity
        public  MKFYlistVM(Entities.MKFYList src)
        {
            Id = src.Id;
            ItemName = src.ItemName;
            Description = src.ItemDescription;
            Created = src.Created;
            ItemPrice = src.ItemPrice;
            PickAddress = src.PickAddress;
            ItemCity = src.ItemCity;
        }

        public Guid Id { get; set; }

        public string ItemName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string PickAddress { get; set; } = string.Empty;

        public string ItemCity { get; set; } = string.Empty;

        public DateTime Created { get; set; }

        public decimal ItemPrice { get; set; }

    }
}
