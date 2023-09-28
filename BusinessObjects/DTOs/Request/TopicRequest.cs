using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Request
{
    public class TopicRequest
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string SemesterCode { get; set; } = null!;
        public string SpecializationName { get; set; } = null!;
        public string SuperLecturerEmail { get; set; } = null!;
    }
}
