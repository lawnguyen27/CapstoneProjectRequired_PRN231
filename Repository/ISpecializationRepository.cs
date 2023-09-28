using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ISpecializationRepository
    {
        void UpdateStatus(int id);
        void Create(Specialization s);
        Specialization GetSpecializationByID(int? ID);
        IEnumerable<Specialization> GetSpecializations();
    }
}
