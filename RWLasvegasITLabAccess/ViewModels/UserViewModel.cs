using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace RWLasvegasITLabAccess.ViewModels
{
   public class UserViewModel
    {
        // [HiddenInput]
        // public Int64 Id { get; set; }
        // [Display(Name = "First Name:")]
        // [Required]
        // public string FirstName { get; set; }
        // [Display(Name = "Last Name:")]
        // [Required]
        // public string LastName { get; set; }

        //  [Display(Name = "Vendor Name:")]
        // [Required]
        public string VendorList { get; set; }
    //     public string Name { get; set; }
        [Display(Name = "Purpose of visit :")]
         public string PurposeofVisit { get; set; }
        [Display(Name = "TM Access Card#")]
        [Required]
        public string AccessCard { get; set; }
    //    [Display(Name = "Email Address")]
    //     [Required]
    //     public string Email { get; set; }


        [Display(Name = "Accompanying Vendor")]
         public bool IscompanyVendor { get; set; }

        
        [Display(Name = "How many vendor(s)?")]
         public int NumberofVendors {get;set;}
    //     [Display(Name = "Added Date")]
    //     public DateTime AddedDate { get; set; }
    }
}