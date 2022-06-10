using Core.DataAccess.EntityFrameworkCore;
using Entities.Concrete;


namespace DataAccess.Abstract
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
    }
}
