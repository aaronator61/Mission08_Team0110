using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_Team0110.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int taskId { get; set; }
        [Required]
        public string task {get; set; }
        public string DueDate { get; set; }
        [Required]
        public byte Quadrant { get; set; }
        public bool Completed  { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
