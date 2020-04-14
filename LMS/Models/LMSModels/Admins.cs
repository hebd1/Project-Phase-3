using System;
using System.Collections.Generic;

namespace LMS.Models.LMSModels
{
    public partial class Admins
    {
        public string UId { get; set; }
        public DateTime Dob { get; set; }

        public virtual Users U { get; set; }
    }
}
