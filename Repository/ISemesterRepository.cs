using BusinessObjects;
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
        void Create(Semester semester);
        Semester GetSemesterByID(int? Id);
        IEnumerable<Semester> GetSemesters();
    }
}
