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
    public class SubjectRepository : ISubjectRepository
    {
        public void Create(SubjectRequest s) => SubjectDAO.Instance.Create(s);

        public Subject GetSubjectByID(int? Id) => SubjectDAO.Instance.GetSubjectByID(Id);

        public IEnumerable<SubjectResponse> GetSubjectBySpecializationId(int id) => SubjectDAO.Instance.GetSubjectBySpecializationId(id);

        public IEnumerable<SubjectResponse> GetSubjectIsPrerequisite(int id) => SubjectDAO.Instance.GetSubjectIsPrerequisite(id);

        public void UpdateStatus(int Id) => SubjectDAO.Instance.UpdateStatus(Id);
    }
}
