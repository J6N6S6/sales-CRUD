using Microsoft.EntityFrameworkCore;

namespace Sales_CRUD.Context
{
    public class SalesCRUDDbContext : DbContext
    {
        public SalesCRUDDbContext(DbContextOptions<SalesCRUDDbContext> options) : base (options) { }
    }
}
