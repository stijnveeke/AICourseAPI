using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AICourseAPI.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public Iteration Iteration { get; set; }
        public Teacher Teacher { get; set; }
        public LearningOutcome LearningOutcome { get; set; }
        public string Message { get; set; }
    }
}
