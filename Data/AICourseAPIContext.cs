using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AICourseAPI.Models;

namespace AICourseAPI.Data
{
    public class AICourseAPIContext : DbContext
    {
        public AICourseAPIContext (DbContextOptions<AICourseAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AICourseAPI.Models.Course> Course { get; set; }

        public DbSet<AICourseAPI.Models.Teacher> Teacher { get; set; }

        public DbSet<AICourseAPI.Models.Feedback> Feedback { get; set; }

        public DbSet<AICourseAPI.Models.Iteration> Iteration { get; set; }

        public DbSet<AICourseAPI.Models.LearningOutcome> LearningOutcome { get; set; }
    }
}
