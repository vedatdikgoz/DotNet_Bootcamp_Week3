using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.Concrete
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DataContext _context;
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        private ProductFeatureRepository _productFeatureRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);

        public IProductRepository Products => _productRepository ?? new ProductRepository(_context);

        public IProductFeatureRepository ProductFeatures => _productFeatureRepository ?? new ProductFeatureRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }


        public IDbContextTransaction BeginTransection()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
