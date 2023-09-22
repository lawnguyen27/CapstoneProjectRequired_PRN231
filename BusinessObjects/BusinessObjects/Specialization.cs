using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Specialization
    {
        public Specialization()
        {
            Subjects = new HashSet<Subject>();
            Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
