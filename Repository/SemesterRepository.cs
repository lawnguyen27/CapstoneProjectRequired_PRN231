using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SemesterRepository : ISemesterRepository
    {
        public void Create(Semester semester) => SemesterDAO.Instance.Create(semester);

        public Semester GetSemesterByID(int? Id) => SemesterDAO.Instance.GetSemesterByID(Id);

        public IEnumerable<Semester> GetSemesters() => SemesterDAO.Instance.GetSemesters();

        public void Update(int Id) => SemesterDAO.Instance.Update(Id);
    }
}
