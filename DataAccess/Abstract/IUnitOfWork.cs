using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IProductFeatureRepository ProductFeatures { get; }
        Task CommitAsync();
        IDbContextTransaction BeginTransection();
    }
}
