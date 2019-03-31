using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTracker.Models
{
    public class IDataSubjects : IMockSubjects
    {
        //db connection
        private DbModel db = new DbModel();
        public IQueryable<Subject> Subjects { get { return db.Subjects; } }

        public void Delete(Subject subject)
        {
            db.Subjects.Remove(subject);
            db.SaveChanges();
        }

        public Subject Save(Subject subject)
        {
            if (subject.SubjectId == 0)
            {
                db.Subjects.Add(subject);
            }
            else
            {
                db.Entry(subject).State = System.Data.Entity.EntityState.Modified;

            }
            db.SaveChanges();
            return subject;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}