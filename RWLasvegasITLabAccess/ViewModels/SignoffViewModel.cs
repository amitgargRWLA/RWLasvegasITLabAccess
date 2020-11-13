using System.ComponentModel.DataAnnotations;
namespace RWLasvegasITLabAccess.ViewModels
{
    public class SignoffViewModel
    {
        [Display(Name = "TM Access Card#")]
        [Required]
        public string AccessCard { get; set; }

        public string SelectedRecords {get;set;}
        
    }
}