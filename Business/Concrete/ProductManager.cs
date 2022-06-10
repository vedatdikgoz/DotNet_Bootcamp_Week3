using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CommitAsync();
            return new SuccessResult(Messages.ProductAdded);
        }


        public async Task<IResult> DeleteAsync(int productId)
        {
            var product = await _unitOfWork.Products.GetAsync(p => p.Id == productId);
            if (product!=null)
            {
                await _unitOfWork.Products.DeleteAsync(product);
                await _unitOfWork.CommitAsync();
                return new SuccessResult(Messages.ProductDeleted);
            }
            return new ErrorResult(Messages.ProductNotFound);
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetAsync(p => p.Id == id);
            return new SuccessDataResult<Product>(product, Messages.ProductListed);
        }

        public async Task<IDataResult<List<Product>>> GetAllAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return new SuccessDataResult<List<Product>>(products, Messages.ProductsListed);
        }

        public async Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var product = _mapper.Map<Product>(productUpdateDto);
            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.CommitAsync();
            return new SuccessResult(Messages.ProductUpdated);
        }

        public async Task<IDataResult<List<ProductFullModel>>> GetProductFullModelAsync()
        {
            var result= await _unitOfWork.Products.GetProductFullModelAsync();
            return new SuccessDataResult<List<ProductFullModel>>(result, Messages.ProductsWithCategoryListed);
        }

        public async Task<IDataResult<List<CategoryProductsModel>>> GetCategoryProductsModelAsync(int categoryId)
        {
            var result = await _unitOfWork.Products.GetCategoryProductsModelAsync(categoryId);
            return new SuccessDataResult<List<CategoryProductsModel>>(result, Messages.ProductsWithCategoryListed);
        }
    }
}
