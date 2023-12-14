using CoreApplication.Models.Product;
using CoreApplication.ports;

namespace Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
