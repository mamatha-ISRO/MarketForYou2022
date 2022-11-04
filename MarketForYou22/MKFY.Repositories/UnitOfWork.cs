using MKFY.Repositories.Repositoies;
using MKFY.Repositories.Repositoies.Interfaces;
using MKFY.Repositories.Repositories;
using MKFY.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Repositories
{
    //project repositories

    public class UnitOfWork : IUnitOfWork, IDisposable

    {
        private readonly MKFYApplicationDbContext _context;

        public IMKFYitemRepository MKFYListItems { get; private set; }
       
        public IUserRepository Users { get; private set; }
        public UnitOfWork(MKFYApplicationDbContext context)
        {
            _context = context;

            MKFYListItems = new MKFYItemRepository(context);
            Users = new UserRepository(context);

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        //impliment  the Idisposable interface application DB context disposal
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
