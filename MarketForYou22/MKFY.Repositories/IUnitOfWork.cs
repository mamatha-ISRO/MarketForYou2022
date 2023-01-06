
using MKFY.Repositories.Repositoies.Interfaces;
using MKFY.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Repositories
{
    public interface IUnitOfWork
    {
        // Repositories
        IMKFYitemRepository MKFYListItems { get; }
        IUserRepository Users { get; }
        IUserLogRepository UserLogs { get;}
        // Save Method
        Task SaveAsync();
        
    }
}
