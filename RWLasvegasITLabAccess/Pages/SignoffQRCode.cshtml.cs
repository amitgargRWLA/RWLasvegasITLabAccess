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

namespace RWLasvegasITLabAccess.Pages
{
    public class SignoffQRCodeModel : PageModel
    {
        private readonly ILogger<QRCodeModel> _logger;
        private readonly IConfiguration _configuration;
        [BindProperty]
        public  byte[] BarcodeBytes{ get; set;}

        public SignoffQRCodeModel(ILogger<QRCodeModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration=configuration;
        }

         private static Byte[] BitmapToBytesCode(Bitmap image)      
     {      
       using (MemoryStream stream = new MemoryStream())      
       {      
         image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);      
         return stream.ToArray();      
       }      
     }

        public void OnGet()
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();      
       QRCodeData _qrCodeData = _qrCode.CreateQrCode(_configuration["ApplicationSettings:SignoutURL"],QRCodeGenerator.ECCLevel.Q);      
       QRCode qrCode = new QRCode(_qrCodeData);      
       Bitmap qrCodeImage = qrCode.GetGraphic(20);      
        BarcodeBytes= BitmapToBytesCode(qrCodeImage); 
        }
    }
}
