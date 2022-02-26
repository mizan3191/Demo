using Demo.Membership.BusinessObjects;
using Demo.Membership.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Membership.Services
{
    public class ProductService : IProductService
    {
        private readonly IMembershipUnitOfWork _unitOfWork;

        public ProductService(IMembershipUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateProductAsync(Product product)
        {
            if (product == null)
                throw new Exception("Product must be provide");

            if (product.Name == null)
                throw new Exception("Product name must be provide");

            await _unitOfWork.ProductRepository.AddAsync(
                new Entities.Product()
                {
                    Name = product.Name,
                    Price = product.Price
                });

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 0)
                throw new Exception("Product id must be provide");

            await _unitOfWork.ProductRepository.RemoveAsync(id);
            await _unitOfWork.SaveAsync();

        }

        public async Task<(IList<Product> records, int total, int totalDispaly)> GetUserDataAsync(
            int pageIndex, int pageSize, string searchText, string sortText)
        {
            var userList = await _unitOfWork.ProductRepository.GetDynamicAsync(
               string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
               sortText, null, pageIndex, pageSize);

            var result = (from user in userList.data
                          select new Product()
                          {
                              Name = user.Name,
                              Price = user.Price,
                              Id = user.Id
                          }).ToList();

            return (result, userList.total, userList.totalDisplay);
        }

        public async Task<Product> LoadDataAsync(int id)
        {
           var entity = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Failed to load data");

            return new Product()
            {
                Name = entity.Name,
                Price = entity.Price,
                Id = entity.Id
            };
        }

        public async Task UpdateProductAsync(Product product)
        {
            var entity = await _unitOfWork.ProductRepository.GetByIdAsync(product.Id);

            if (entity != null)
            {
                entity.Price = product.Price;
                entity.Name = product.Name;

                await _unitOfWork.SaveAsync();
            }
        }
    }
}