using Core.DataAccess.EntityFrameworkCore;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Concrete
{
    public class ProductFeatureRepository : EntityRepositoryBase<ProductFeature>, IProductFeatureRepository
    {
        public ProductFeatureRepository(DbContext context) : base(context)
        {
        }
    }
}
