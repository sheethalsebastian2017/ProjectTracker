namespace ProjectTracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Project
    {
        public int ProjectId { get; set; }

        [StringLength(255)]
        public string ProjectName { get; set; }

        [StringLength(8000)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Details { get; set; }

        public int? SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
