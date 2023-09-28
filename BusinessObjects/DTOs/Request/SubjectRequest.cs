using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTOs.Request
{
    public class SubjectRequest
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool? IsPrerequisite { get; set; }
        public int? SpecializationId { get; set; }
    }
}
