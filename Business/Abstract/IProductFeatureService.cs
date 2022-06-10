using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductFeatureService
    {
        Task<IDataResult<List<ProductFeature>>> GetAllAsync();
        Task<IDataResult<ProductFeature>> GetByIdAsync(int id);
        Task<IResult> AddAsync(ProductFeatureAddDto productFeatureAddDto);
        Task<IResult> UpdateAsync(ProductFeatureUpdateDto productFeatureUpdateDto);
        Task<IResult> DeleteAsync(int productFeatureId);
    }
}
