using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> AddAsync(CategoryAddDto categoryAddDto)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.CommitAsync();
            return new SuccessResult(Messages.CategoryAdded);
        }

        public async Task<IResult> DeleteAsync(int categoryId)
        {
            var category= await _unitOfWork.Categories.GetAsync(c=>c.Id==categoryId);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.CommitAsync();
                return new SuccessResult(Messages.CategoryDeleted);
            }
            return new ErrorResult(Messages.CategoryNotFound);
        }

        public async Task<IDataResult<List<Category>>> GetAllAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            return new SuccessDataResult<List<Category>>(categories, Messages.CategoriesListed);
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Category>(await _unitOfWork.Categories.GetAsync(c => c.Id == id), Messages.CategoryListed);
        }

        public async Task<IResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
            await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.CommitAsync();
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
