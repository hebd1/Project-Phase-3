using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Students
    {
        public Students()
        {
            EnrollmentGrades = new HashSet<EnrollmentGrades>();
            Submissions = new HashSet<Submissions>();
        }

        public string UId { get; set; }
        public DateTime Dob { get; set; }
        public string DeptAbbreviation { get; set; }

        public virtual Departments DeptAbbreviationNavigation { get; set; }
        public virtual Users U { get; set; }
        public virtual ICollection<EnrollmentGrades> EnrollmentGrades { get; set; }
        public virtual ICollection<Submissions> Submissions { get; set; }
    }
}
