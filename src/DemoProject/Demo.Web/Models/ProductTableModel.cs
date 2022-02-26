using Autofac;
using Demo.Membership.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Web.Models
{
    public class ProductTableModel
    {

        private ILifetimeScope _scope;
        private IProductService _service;

        public ProductTableModel(IProductService service)
        {
            _service = service;
        }

        public ProductTableModel()
        {
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<IProductService>();
        }

        internal async Task<object> GetProductDataAsyns(DataTablesAjaxRequestModel dataTableModel)
        {
            var data = await _service.GetUserDataAsync(
                dataTableModel.PageIndex,
                dataTableModel.PageSize,
                dataTableModel.SearchText,
                dataTableModel.GetSortText(new string[] {"Name", "Price" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDispaly,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.Price.ToString(),
                                record.Id.ToString()
                        }
                        ).ToArray()
            };
        }

        internal async Task RemoveAsync(int id)
        {
            await _service.DeleteAsync(id);
        }
    }
}