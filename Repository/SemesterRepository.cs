using BusinessObjects;
using BusinessObjects.DTOs.Request;
using BusinessObjects.DTOs.Response;
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

        public void Create(SemesterRequest semester) => SemesterDAO.Instance.Create(semester);

        public Semester GetSemesterByID(int? Id) => SemesterDAO.Instance.GetSemesterByID(Id);

        public void Update(int Id) => SemesterDAO.Instance.Update(Id);

        IEnumerable<SemesterResponse> ISemesterRepository.GetSemesters() => SemesterDAO.Instance.GetSemesters();
    }
}
