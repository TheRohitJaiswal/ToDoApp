using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
namespace ToDoApp.Models
{
    public class Priority
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Provide the name of priority")]
        [StringLength(15)]
        public string PriorityName { get; set; }
        [Required]
        public string ColorCode { get; set; }
    }
}
