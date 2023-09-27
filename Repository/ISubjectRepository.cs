using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ISubjectRepository
    {
        void Update(int Id);
        void Create(Subject s);
        Subject GetSubjectByID(int? Id);
        IEnumerable<Subject> GetSubjectIsPrerequisite(int id);
        IEnumerable<Subject> GetSubjectBySpecializationId(int id);
    }
}
