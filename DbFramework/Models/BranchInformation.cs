using System;
using System.Collections.Generic;

namespace DbFramework.Models
{
    public partial class BranchInformation
    {
        public BranchInformation()
        {
            PersonalInformation = new HashSet<PersonalInformation>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public ICollection<PersonalInformation> PersonalInformation { get; set; }
    }
}
