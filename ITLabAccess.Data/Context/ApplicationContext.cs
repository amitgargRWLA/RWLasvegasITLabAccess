using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ITLabAccess.Core.Models;
using ITLabAccess.Core.Map;


namespace ITLabAccess.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new LabAccessMap(modelBuilder.Entity<LabAccess>());
            
        }
    }
}
