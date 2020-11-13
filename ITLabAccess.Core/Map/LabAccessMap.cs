using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ITLabAccess.Core.Models;

namespace ITLabAccess.Core.Map
{
    public class LabAccessMap
    {
        public LabAccessMap(EntityTypeBuilder<LabAccess> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.VendorName);
            entityBuilder.Property(t => t.FirstName);
            entityBuilder.Property(t => t.LastName);
            entityBuilder.Property(t => t.Purposeofvisit);
            entityBuilder.Property(t => t.AccessCard).IsRequired();
            entityBuilder.Property(t => t.Email);
            entityBuilder.Property(t => t.SignOutStatus);
            
        }
    }
}
