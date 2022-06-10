using Core.DataAccess.EntityFrameworkCore;
using Entities.Concrete;


namespace DataAccess.Abstract
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        Task<List<ProductFullModel>> GetProductFullModelAsync();
        Task<List<CategoryProductsModel>> GetCategoryProductsModelAsync(int categoryId);
    }
}
