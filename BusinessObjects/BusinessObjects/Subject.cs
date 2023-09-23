using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Subject
    {
        public Subject()
        {
            StudentInSemesters = new HashSet<StudentInSemester>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool? IsPrerequisite { get; set; }
        public int? SpecializationId { get; set; }

        public virtual Specialization? Specialization { get; set; }
        public virtual ICollection<StudentInSemester> StudentInSemesters { get; set; }
    }
}
