using System;
using System.Collections.Generic;
using System.Text;

namespace ITLabAccess.Core.Models
{
    public class LabAccess : BaseEntity
    {
        public string AccessCard { get; set; }
        public string VendorName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Purposeofvisit { get; set; }
        
        public bool SignOutStatus { get; set; }
       
    }
}
