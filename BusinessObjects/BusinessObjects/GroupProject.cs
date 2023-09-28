using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class GroupProject
    {
        public GroupProject()
        {
            StudentInGroups = new HashSet<StudentInGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? TopicId { get; set; }
        public bool? Status { get; set; }

        public virtual Topic? Topic { get; set; }
        public virtual ICollection<StudentInGroup> StudentInGroups { get; set; }
    }
}
