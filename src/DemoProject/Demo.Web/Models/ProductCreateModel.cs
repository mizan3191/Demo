using Autofac;
using AutoMapper;
using Demo.Membership.BusinessObjects;
using Demo.Membership.Services;
using System.Threading.Tasks;

namespace Demo.Web.Models
{
    public class ProductCreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        private ILifetimeScope _scope;
        private IProductService _service;
        private IMapper _mapper;


        public ProductCreateModel(IProductService service, IMapper mapper)
        {
            _service = service;
        }

        public ProductCreateModel()
        {
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<IProductService>();
            _mapper = _scope.Resolve<IMapper>();
        }

        public async Task CreateAsync()
        {
            var product = _mapper.Map<Product>(this);

            await _service.CreateProductAsync(product);
        }
    }
}