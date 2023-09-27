using BusinessObjects;
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
        public void Create(Subject s) => SubjectDAO.Instance.Create(s);

        public Subject GetSubjectByID(int? Id) => SubjectDAO.Instance.GetSubjectByID(Id);

        public IEnumerable<Subject> GetSubjectBySpecializationId(int id) => SubjectDAO.Instance.GetSubjectBySpecializationId((int)id);  

        public IEnumerable<Subject> GetSubjectIsPrerequisite(int id) => SubjectDAO.Instance.GetSubjectIsPrerequisite((int) id);

        public void Update(int Id) => SubjectDAO.Instance.Update(Id);
    }
}
