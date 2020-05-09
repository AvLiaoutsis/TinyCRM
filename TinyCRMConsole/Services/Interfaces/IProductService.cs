using System.Linq;

namespace TinyCRMConsole
{
    public interface IProductService
    {
        public Product Create(ProductOptions options);

        public void Update(ProductOptions options);

        public IQueryable<Product> Search(ProductOptions options);

        public Product SearchById(string id);

    }
}
