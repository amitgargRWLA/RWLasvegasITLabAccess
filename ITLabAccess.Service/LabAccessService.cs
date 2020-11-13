using System;
using System.Linq;
using System.Collections.Generic;
using ITLabAccess.Core;
using ITLabAccess.Core.Models;
using ITLabAccess.Data.Repository;


namespace ITLabAccess.Service
{
    public class UserService : ILabAccessService
    {
        private IRepository<LabAccess> labaccessRepository;
        
        public UserService(IRepository<LabAccess> labaccessRepository)
        {
            this.labaccessRepository = labaccessRepository;
            
           
        }

        public IEnumerable<LabAccess> GetRecordsByAccssCard( string AccessCardNumber)
        {
         
         //var tempDate=Utility.GetPacificStandardTime();
            return labaccessRepository.GetAll().Where(s => s.AccessCard==AccessCardNumber && s.SignOutStatus==false && s.ModifiedDate>ServiceUtility.GetPacificStandardTime()).OrderByDescending(s =>s.ModifiedDate);

        }

        public LabAccess GetUser(long id)
        {
            return labaccessRepository.Get(id);
        }

        public void InsertUser(LabAccess user)
        {
            labaccessRepository.Insert(user);
        }
        public void UpdateUser(LabAccess user)
        {
            labaccessRepository.Update(user);
        }

        public void DeleteUser(long id)
        {
            
            LabAccess user = GetUser(id);
            labaccessRepository.Remove(user);
            labaccessRepository.SaveChanges();
        }
    }
}
