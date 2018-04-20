using System;
using System.Collections.Generic;

namespace HappyCooksApi.Models
{
    public partial class DifficultyLevels
    {
        public DifficultyLevels()
        {
            Projects = new HashSet<Projects>();
        }

        public int Id { get; set; }
        public int Value { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public ICollection<Projects> Projects { get; set; }
    }
}
