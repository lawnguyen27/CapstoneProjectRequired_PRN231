using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SpecializationDAO
    {
        private static SpecializationDAO instance = null;
        public static readonly object instanceLock = new object();
        public static SpecializationDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SpecializationDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Specialization> GetSpecializations()
        {
            var specializations = new List<Specialization>();
            try
            {
                using var context = new CPRContext();
                specializations = context.Specializations.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return specializations;
        }

        public Specialization GetSpecializationByID(int? ID)
        {
            Specialization s = null;
            try
            {
                using var context = new CPRContext();
                s = context.Specializations.SingleOrDefault(m => m.Id == ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return s;
        }

        public void Create(Specialization s)
        {
            try
            {
                Specialization _s = GetSpecializationByID(s.Id);
                if (_s== null)
                {
                    using var context = new CPRContext();
                    context.Specializations.Add(s);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Specialization is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateStatus(int id)
        {
            try
            {
                Specialization _s = GetSpecializationByID(id);
                if (_s != null)
                {
                    using var context = new CPRContext();
                    _s.Status = false;
                    context.Specializations.Update(_s);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Specialization does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
