using System;
using System.Collections.Generic;

namespace BusinessObjects
{
    public partial class Topic
    {
        public Topic()
        {
            GroupProjects = new HashSet<GroupProject>();
            TopicOfLecturers = new HashSet<TopicOfLecturer>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public int? SemesterId { get; set; }
        public int? SpecializationId { get; set; }
        public int? GroupId { get; set; }

        public virtual GroupProject? Group { get; set; }
        public virtual Semester? Semester { get; set; }
        public virtual Specialization? Specialization { get; set; }
        public virtual ICollection<GroupProject> GroupProjects { get; set; }
        public virtual ICollection<TopicOfLecturer> TopicOfLecturers { get; set; }
    }
}
