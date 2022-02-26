using Demo.Membership.Contexts;
using Demo.Membership.Entities;
using DevSkill.Data;

namespace Demo.Membership.Repositories
{
    public class ProductRepository : Repository<Product, int , MembershipDbContext>, IProductRepository
    {
        public ProductRepository(IMembershipDbContext dbContext)
            : base((MembershipDbContext)dbContext)
        {
        }
    }
}