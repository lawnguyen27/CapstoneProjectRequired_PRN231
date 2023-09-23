using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class StudentInSemester
    {
        public int Id { get; set; }
        public bool? Status { get; set; }
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }
        public int? SemesterId { get; set; }

        public virtual Semester? Semester { get; set; }
        public virtual Account? Student { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
