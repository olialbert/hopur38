using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mooshak_2._0.Models
{
    public class AddCourseViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { set; get; }
    }
}