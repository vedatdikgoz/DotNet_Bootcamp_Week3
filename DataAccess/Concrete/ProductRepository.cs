using Core.DataAccess.EntityFrameworkCore;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ProductRepository : EntityRepositoryBase<Product>, IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DbContext context) : base(context)
        {
            _context = (DataContext)context;
        }


        //stored procedure
        public async Task<List<ProductFullModel>> GetProductFullModelAsync()
        {
            var products = await _context.ProductsFullModels.FromSqlRaw("exec sp_full_products").ToListAsync();
            return products;
        }


        //function
        public async Task<List<CategoryProductsModel>> GetCategoryProductsModelAsync(int categoryId)
        {
            var products = await _context.CategoryProductsModels.FromSqlInterpolated($"select * from dbo.fnc_category_products({categoryId})").ToListAsync();
            return products;
        }
    }
}
