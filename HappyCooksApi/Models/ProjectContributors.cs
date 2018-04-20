using System;
using System.Collections.Generic;

namespace HappyCooksApi.Models
{
    public partial class ProjectContributors
    {
        public int Id { get; set; }
        public int ContributorId { get; set; }
        public int ProjectId { get; set; }

        public Contributor Contributor { get; set; }
        public Projects Project { get; set; }
    }
}
