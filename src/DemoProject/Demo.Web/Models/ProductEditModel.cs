using Autofac;
using AutoMapper;
using Demo.Membership.BusinessObjects;
using Demo.Membership.Services;
using System;
using System.Threading.Tasks;

namespace Demo.Web.Models
{
    public class ProductEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        private ILifetimeScope _scope;
        private IProductService _service;
        private IMapper _mapper;

        public ProductEditModel(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public ProductEditModel()
        {
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<IProductService>();
            _mapper = _scope.Resolve<IMapper>();
        }

        public async Task LoadDataAsync(int id)
        {
            var data = await _service.LoadDataAsync(id);
            _mapper.Map(data, this);
        }

        public async Task UpdateAsync()
        {
            var product = _mapper.Map<Product>(this);
            await _service.UpdateProductAsync(product);
        }
    }
}