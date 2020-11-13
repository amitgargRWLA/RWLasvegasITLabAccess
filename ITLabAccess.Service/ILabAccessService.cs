using System;
using System.Collections.Generic;
using ITLabAccess.Core.Models;

namespace ITLabAccess.Service
{
    public interface ILabAccessService
    {
        IEnumerable<LabAccess> GetRecordsByAccssCard( string AccessCardNumber);
        LabAccess GetUser(long id);
        void InsertUser(LabAccess user);
        void UpdateUser(LabAccess user);
        void DeleteUser(long id);
    }
}
