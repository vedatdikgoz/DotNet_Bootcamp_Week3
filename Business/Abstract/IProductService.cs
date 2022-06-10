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
    public interface IProductService
    {
        Task<IDataResult<List<Product>>> GetAllAsync();
        Task<IDataResult<Product>> GetByIdAsync(int id);
        Task<IResult> AddAsync(ProductAddDto productAddDto);
        Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto);
        Task<IResult> DeleteAsync(int productId);
        Task<IDataResult<List<ProductFullModel>>> GetProductFullModelAsync();
        Task<IDataResult<List<CategoryProductsModel>>> GetCategoryProductsModelAsync(int categoryId);
    }
}
