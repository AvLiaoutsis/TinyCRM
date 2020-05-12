using System.Linq;
using TinyCrm.Core.Model;
using TinyCrm.Core.Services.Options;

namespace TinyCrm.Core.Services
{
    public interface IProductService
    {
        public Product Create(ProductOptions options);

        public void Update(ProductOptions options);

        public IQueryable<Product> Search(ProductOptions options);

        public Product SearchById(string id);

    }
}
