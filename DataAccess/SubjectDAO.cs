using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SubjectDAO
    {
        private static SubjectDAO instance = null;
        public static readonly object instanceLock = new object();
        public static SubjectDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SubjectDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Subject> GetSubjectIsPrerequisite(int id)
        {
            var subjects = new List<Subject>();
            try
            {
                using var context = new CPRContext();
                subjects = context.Subjects.Where(c => c.SpecializationId == id).Where(c => c.IsPrerequisite.Equals(true)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return subjects;
        }

        public IEnumerable<Subject> GetSubjectBySpecializationId(int id)
        {
            var subjects = new List<Subject>();
            try
            {
                using var context = new CPRContext();
                subjects = context.Subjects.Where(c => c.SpecializationId == id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return subjects;
        }

        public Subject GetSubjectByID(int? Id)
        {
            Subject subject = null;
            try
            {
                using var context = new CPRContext();
                subject = context.Subjects.SingleOrDefault(m => m.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return subject;
        }

        public int GetSubjectIdByCode(string? code)
        {
            int id;
            Subject subject = null;
            try
            {
                using var context = new CPRContext();
                subject = context.Subjects.SingleOrDefault(m => m.Code.Equals(code));
                if (subject != null)
                {
                    id = subject.Id;
                }
                else id = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return id;
        }

        public void Create(Subject s)
        {
            try
            {
                Subject _s = new Subject();
                _s.Id = GetSubjectIdByCode(s.Code);
                if (_s.Id == 0)
                {
                    using var context = new CPRContext();
                    context.Subjects.Add(s);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Subject is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(int Id)
        {
            try
            {
                Subject _s = GetSubjectByID(Id);
                if (_s != null)
                {
                    using var context = new CPRContext();
                    if (_s.IsPrerequisite.Equals(true)) _s.IsPrerequisite = false;
                    else _s.IsPrerequisite = true;
                    context.Subjects.Update(_s);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The semester does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
