using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SpecializationRepository : ISpecializationRepository
    {
        public void Create(Specialization s) => SpecializationDAO.Instance.Create(s);

        public Specialization GetSpecializationByID(int? ID) => SpecializationDAO.Instance.GetSpecializationByID(ID);

        public IEnumerable<Specialization> GetSpecializations() => SpecializationDAO.Instance.GetSpecializations();

        public void UpdateStatus(int id) => SpecializationDAO.Instance.UpdateStatus(id);
    }
}
