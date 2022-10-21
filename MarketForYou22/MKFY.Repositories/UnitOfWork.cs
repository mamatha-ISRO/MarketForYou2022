using MKFY.Repositories.Repositoies;
using MKFY.Repositories.Repositoies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKFY.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable

    {
        private readonly MKFYApplicationDbContext _context;

        public IMKFYitemRepository MKFYListItems { get; private set; }

        public UnitOfWork(MKFYApplicationDbContext context)
        {
            _context = context;

            MKFYListItems = new MKFYItemRepository(context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
