using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Models.ViewModels
{
    public class MKFYListAddVM
    {
        [Required]
        public string ItemName { get; set; } = string.Empty;

        [Required]
        public string ItemDescription { get; set; } = string.Empty;

        [Required]
        public decimal ItemPrice { get; set; }

        [Required]
        public string PickAddress { get; set; } = string.Empty;

        [Required]
        public string ItemCity { get; set; } = string.Empty;
    }
}
