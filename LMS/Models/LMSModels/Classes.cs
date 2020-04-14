using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Classes
    {
        public Classes()
        {
            AssignmentCategories = new HashSet<AssignmentCategories>();
            EnrollmentGrades = new HashSet<EnrollmentGrades>();
        }

        public uint Year { get; set; }
        public uint ClassId { get; set; }
        public string Season { get; set; }
        public string Location { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public uint CourseId { get; set; }
        public string UId { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Professors U { get; set; }
        public virtual ICollection<AssignmentCategories> AssignmentCategories { get; set; }
        public virtual ICollection<EnrollmentGrades> EnrollmentGrades { get; set; }
    }
}
