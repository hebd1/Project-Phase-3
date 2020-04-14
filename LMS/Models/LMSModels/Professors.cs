using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Professors
    {
        public Professors()
        {
            Classes = new HashSet<Classes>();
        }

        public string UId { get; set; }
        public DateTime Dob { get; set; }
        public string DeptAbbreviation { get; set; }

        public virtual Departments DeptAbbreviationNavigation { get; set; }
        public virtual Users U { get; set; }
        public virtual ICollection<Classes> Classes { get; set; }
    }
}
