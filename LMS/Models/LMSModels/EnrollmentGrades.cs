using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class EnrollmentGrades
    {
        public string Grade { get; set; }
        public string UId { get; set; }
        public uint ClassId { get; set; }
        public uint EnrollmentId { get; set; }

        public virtual Classes Class { get; set; }
        public virtual Students U { get; set; }
    }
}
