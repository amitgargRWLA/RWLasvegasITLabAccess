using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QRCoder;
using RWLasvegasITLabAccess.ViewModels;
using ITLabAccess.Service;
using ITLabAccess.Core.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RWLasvegasITLabAccess.Pages
{
    public class SignoffModel : PageModel
    {
        private readonly ILogger<SignoffModel> _logger;
        private readonly IConfiguration _configuration;
         [BindProperty]
        public SignoffViewModel SignoffUser { get; set; }

        [BindProperty]
        public IEnumerable<LabAccess> DataRecords { get; set; }

        [TempData]
        public string SignoffMessage {get;set;}

        [TempData]
        public string AccessCardId {get;set;}


          private readonly ILabAccessService labaccessService;

        public SignoffModel(ILogger<SignoffModel> logger, IConfiguration configuration,ILabAccessService labaccessService)
        {
            _logger = logger;
            _configuration=configuration;
             this.labaccessService = labaccessService;
             //DataRecords=new List<LabAccess>();
        }

        

        public void OnGet()
        {
          //AccessCardId="0";
          if(TempData.Keys != null)
          {
            if(TempData.ContainsKey("AccessCardId"))
           {

            AccessCardId= TempData["AccessCardId"].ToString(); 
            DataRecords= labaccessService.GetRecordsByAccssCard(AccessCardId);
           }
            if(TempData.ContainsKey("SignoffMessage"))
           {
            SignoffMessage=TempData["SignoffMessage"].ToString();
           }

          }
        }

        
         public IActionResult OnPost()
        {
          bool UpdateStatus=false;
          if(!ModelState.IsValid)
          {
            return Page();
          }
          
           
          TempData["AccessCardId"]=SignoffUser.AccessCard; 

          if(!string.IsNullOrEmpty(SignoffUser.SelectedRecords))
          {
          var signoffRecords = JsonSerializer.Deserialize<List<SignoffRecord>>(SignoffUser.SelectedRecords);
          
          foreach(var record in signoffRecords)
          {
            if(record.Id != "0")
            {
           LabAccess tempuser=labaccessService.GetUser(Convert.ToInt32(record.Id));
           tempuser.SignOutStatus=true;
           tempuser.ModifiedDate=Utility.GetPacificStandardTime();
           labaccessService.UpdateUser(tempuser);
           UpdateStatus=true;
            }
          }

          }

          if(UpdateStatus)
          {
           TempData["SignoffMessage"]="Selected member/vendor has been signed out successfully.";
          }
          return RedirectToPage("/signoff");

        }

        
    }
}
