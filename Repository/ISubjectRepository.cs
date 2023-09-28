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
    public interface ISubjectRepository
    {
        void UpdateStatus(int Id);
        void Create(SubjectRequest s);
        Subject GetSubjectByID(int? Id);
        IEnumerable<SubjectResponse> GetSubjectBySpecializationId(int id);
        IEnumerable<SubjectResponse> GetSubjectIsPrerequisite(int id);
    }
}
