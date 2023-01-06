using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MKFY.Models.ViewModels;

namespace MKFY.Models.Entities
{
    public class UserLog
    {
        public UserLog() { }

        

        [Key]
        public string Id { get; set; } = String.Empty;
        [Required]
        public string UserName { get; set; } = String.Empty;
        [Required]
        public DateTime LogCreated { get; set; } = DateTime.Now;
        [Required]
        public string SearchString { get; set; } = String.Empty;
        [Required]
        public string SearchCategory { get; set; } = String.Empty;
       
       
    }

}
