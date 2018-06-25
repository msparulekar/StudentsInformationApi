using System;
using System.Collections.Generic;

namespace DbFramework.Models
{
    public partial class CollegeInformation
    {
        public CollegeInformation()
        {
            PersonalInformation = new HashSet<PersonalInformation>();
        }

        public int CollegeId { get; set; }
        public string CollegeName { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public ICollection<PersonalInformation> PersonalInformation { get; set; }
    }
}
