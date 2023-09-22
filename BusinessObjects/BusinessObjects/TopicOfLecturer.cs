using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class TopicOfLecturer
    {
        public int Id { get; set; }
        public bool IsSuperLecturer { get; set; }
        public int? LecturerId { get; set; }
        public int? TopicId { get; set; }

        public virtual Account? Lecturer { get; set; }
        public virtual Topic? Topic { get; set; }
    }
}
