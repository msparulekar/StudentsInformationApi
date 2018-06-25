using System;
using System.Collections.Generic;

namespace DbFramework.Models
{
    public partial class PersonalInformation
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public int MobileNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public int CollegeId { get; set; }
        public int BranchId { get; set; }
        public string YearId { get; set; }
        public string PassingYear { get; set; }
        public int InfoSourceId { get; set; }

        public BranchInformation Branch { get; set; }
        public CollegeInformation College { get; set; }
        public InformationSource InfoSource { get; set; }
    }
}
