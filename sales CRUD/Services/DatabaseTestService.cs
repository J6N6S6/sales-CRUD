using Microsoft.EntityFrameworkCore;
using Sales_CRUD.Context;
using System;
using System.Threading.Tasks;

namespace Sales_CRUD.Services
{
    public class DatabaseTestService
    {
        private readonly SalesCRUDDbContext _context;

        public DatabaseTestService(SalesCRUDDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CanConnectAsync()
        {
            try
            {
                return await _context.Database.CanConnectAsync();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
