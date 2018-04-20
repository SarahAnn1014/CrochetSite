using System;
using System.Collections.Generic;

namespace HappyCooksApi.Models
{
    public partial class Projects
    {
        public Projects()
        {
            ProjectContributors = new HashSet<ProjectContributors>();
        }

        public int Id { get; set; }
        public Guid? Guid { get; set; }
        public string DisplayName { get; set; }
        public string Steps { get; set; }
        public string Pattern { get; set; }
        public string TagLine { get; set; }
        public string Description { get; set; }
        public decimal? MakeTime { get; set; }
        public int DifficultyId { get; set; }
        public DateTime? CreateTime { get; set; }

        public DifficultyLevels Difficulty { get; set; }
        public ICollection<ProjectContributors> ProjectContributors { get; set; }
    }
}
