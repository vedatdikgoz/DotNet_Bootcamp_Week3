using Core.DataAccess.EntityFrameworkCore;
using Entities.Concrete;


namespace DataAccess.Abstract
{
    public interface IProductFeatureRepository : IEntityRepository<ProductFeature>
    {
    }
}
