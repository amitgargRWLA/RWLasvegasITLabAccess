using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITLabAccess.Core.Models;
using ITLabAccess.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RWLasvegasITLabAccess.ViewModels;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace RWLasvegasITLabAccess.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ILabAccessService labaccessService;
        

         [BindProperty]
        public UserViewModel NewUser { get; set; }

         [TempData]
        public string Message {get;set;}

        public IndexModel(ILogger<IndexModel> logger,ILabAccessService labaccessService )
        {
            _logger = logger;
            this.labaccessService = labaccessService;
           
        }

        public void OnGet()
        {

           if(!TempData.ContainsKey("AddMessage") || TempData["AddMessage"] ==null )
           {
            TempData["AddMessage"]="default";
            Message=TempData["AddMessage"].ToString();
           }
           else
           {
            Message=TempData["AddMessage"].ToString();
           }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
            TempData["AddMessage"]="default";  
            Message=TempData["AddMessage"].ToString();  
            return Page();
            } 
            var tempdate= Utility.GetPacificStandardTime();  
            if(NewUser.IscompanyVendor)
            {
                var vendors = JsonSerializer.Deserialize<List<Vendor>>(NewUser.VendorList);
                
                foreach(var vendor in vendors)
                 {
            LabAccess labaccessEntity = new LabAccess
            {
                AccessCard=NewUser.AccessCard,
                VendorName =vendor.VendorName,
                Email = vendor.Email,
                AddedDate =tempdate,
                ModifiedDate = tempdate,
                IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                FirstName = vendor.FirstName,
                LastName = vendor.LastName,
                Purposeofvisit = vendor.PurposeofVisit,
                SignOutStatus=false
                             
            };
            labaccessService.InsertUser(labaccessEntity);
            if (labaccessEntity.Id > 0)
            {
               TempData["AddMessage"]="Thank you, sign in has been registered successfully.";
                
            }

            }

            return RedirectToPage("/index");
            }          
           else
           {
                LabAccess labaccessEntity = new LabAccess
            {
                AccessCard=NewUser.AccessCard,
                VendorName =null,
                Email = null,
                AddedDate = tempdate,
                ModifiedDate = tempdate,
                IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                FirstName = null,
                LastName = null,
                Purposeofvisit = NewUser.PurposeofVisit,
                SignOutStatus=false
                             
            };
            labaccessService.InsertUser(labaccessEntity);
            if (labaccessEntity.Id > 0)
            {
               TempData["AddMessage"]="Thank you, sign in has been registered successfully.";
                return RedirectToPage("/index");
            }

           }
        
            
            return RedirectToPage("/index");  

        }


    }
}
