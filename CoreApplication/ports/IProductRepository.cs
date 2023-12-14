using CoreApplication.Models.Product;

namespace CoreApplication.ports
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }
}
