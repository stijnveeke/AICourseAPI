using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AICourseAPI.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Insertion { get; set; }
        public string Lastname { get; set; }
        public Collection<Course> Courses { get; set; }
    }
}
