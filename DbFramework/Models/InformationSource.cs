using System;
using System.Collections.Generic;

namespace DbFramework.Models
{
    public partial class InformationSource
    {
        public InformationSource()
        {
            PersonalInformation = new HashSet<PersonalInformation>();
        }

        public int InfoSourceId { get; set; }
        public string InfoSourceDescription { get; set; }

        public ICollection<PersonalInformation> PersonalInformation { get; set; }
    }
}
