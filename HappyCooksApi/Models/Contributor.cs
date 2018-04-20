using System;
using System.Collections.Generic;

namespace HappyCooksApi.Models
{
    public partial class Contributor
    {
        public Contributor()
        {
            ProjectContributors = new HashSet<ProjectContributors>();
        }

        public int Id { get; set; }
        public Guid? Guid { get; set; }
        public string ScreenName { get; set; }
        public string Bio { get; set; }

        public ICollection<ProjectContributors> ProjectContributors { get; set; }
    }
}
