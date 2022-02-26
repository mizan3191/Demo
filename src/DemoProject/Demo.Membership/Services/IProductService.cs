using Demo.Membership.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Membership.Services
{
    public interface IProductService
    {
        Task CreateProductAsync(Product product);
        Task<(IList<Product> records, int total, int totalDispaly)> GetUserDataAsync(
            int pageIndex, int pageSize, string searchText, string sortText);
        Task<Product> LoadDataAsync(int id);
        Task UpdateProductAsync(Product product);
        Task DeleteAsync(int id);
    }
}