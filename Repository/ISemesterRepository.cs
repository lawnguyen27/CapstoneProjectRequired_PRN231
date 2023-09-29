using BusinessObjects;
using BusinessObjects.DTOs.Request;
using BusinessObjects.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ISemesterRepository
    {
        void Update(int Id);
        void Create(SemesterRequest semester);
        Semester GetSemesterByID(int? Id);
        IEnumerable<SemesterResponse> GetSemesters();
    }
}
