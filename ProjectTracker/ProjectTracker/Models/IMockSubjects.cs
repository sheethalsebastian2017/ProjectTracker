using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Models
{
    public interface IMockSubjects
    {
        IQueryable<Subject> Subjects { get; }

        Subject Save(Subject subject);

        void Delete(Subject subject);

        void Dispose();

    }
}
