using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos;

namespace Business.Concrete
{
    //use transection
    public class ProductFeatureManager : IProductFeatureService
    {
     
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductFeatureManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(ProductFeatureAddDto productFeatureAddDto)
        {
            var productFeature = _mapper.Map<ProductFeature>(productFeatureAddDto);
            await _unitOfWork.ProductFeatures.AddAsync(productFeature);
            using(var transection= _unitOfWork.BeginTransection())
            {
                transection.Commit();
            }
            return new SuccessResult(Messages.ProductFeatureAdded);
        }

        public async Task<IResult> DeleteAsync(int productFeatureId)
        {
            var productFeature= await _unitOfWork.ProductFeatures.GetAsync(pf=>pf.Id==productFeatureId);
            if (productFeature != null)
            {
                await _unitOfWork.ProductFeatures.DeleteAsync(productFeature);
                using (var transection = _unitOfWork.BeginTransection())
                {
                    transection.Commit();
                }
                return new SuccessResult(Messages.ProductFeatureDeleted);
            }
            return new ErrorResult(Messages.ProductFeatureNotFound);
        }

        public async Task<IDataResult<List<ProductFeature>>> GetAllAsync()
        {
            var productFeatures = await _unitOfWork.ProductFeatures.GetAllAsync();
            return new SuccessDataResult<List<ProductFeature>>(productFeatures, Messages.ProductFeaturesListed);
        }

        public async Task<IDataResult<ProductFeature>> GetByIdAsync(int id)
        {
            var productFeature = await _unitOfWork.ProductFeatures.GetAsync(p => p.Id == id);
            return new SuccessDataResult<ProductFeature>(productFeature, Messages.ProductFeatureListed);
        }

        public async Task<IResult> UpdateAsync(ProductFeatureUpdateDto productFeatureUpdateDto)
        {
            var productFeature = _mapper.Map<ProductFeature>(productFeatureUpdateDto);
            await _unitOfWork.ProductFeatures.UpdateAsync(productFeature);
            using (var transection = _unitOfWork.BeginTransection())
            {
                transection.Commit();
            }
            return new SuccessResult(Messages.ProductFeatureUpdated);
        }
    }
}
