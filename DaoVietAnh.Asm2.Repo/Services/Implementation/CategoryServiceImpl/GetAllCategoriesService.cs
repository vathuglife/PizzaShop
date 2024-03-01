using AutoMapper;
using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Mappers;
using DaoVietAnh.Asm2.Repo.Payload.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation.CategoryServiceImpl
{
    public class GetAllCategoriesService
    {
        private IUnitOfWork? _unitOfWork;
        private List<Category>? _categories;
        private List<CategoryDTO>? _categoryDTOs;
        private Mapper? _mapper;
        public GetAllCategoriesService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            InitializeObjects();
        }
        public CategoryServiceResponse GetCategories()
        {
            GetAllCategoriesFromDb();
            MapCategoriesToCategoryDTOs();
            return GetSuccessfulRetrievalResult();
        }
        private void InitializeObjects()
        {            
            _mapper = new Mapper(CategoryMapper.CategoryToCategoryDTOMap());
            _categoryDTOs = new List<CategoryDTO>();
            
        }
        private void GetAllCategoriesFromDb()
        {
            _categories = _unitOfWork!.CategoryRepository!.Get().ToList();
        }
        private void MapCategoriesToCategoryDTOs()
        {
            foreach (var category in _categories!)
            {
                CategoryDTO categoryDTO = _mapper!.Map<CategoryDTO>(category);
                _categoryDTOs!.Add(categoryDTO);

            }
        }
        private CategoryServiceResponse GetSuccessfulRetrievalResult()
        {
            return new CategoryServiceResponse()
            {
                Result = Constants.Enums.CategoryServiceEnum.SUCCESS,
                ReturnData = _categoryDTOs
            };
        }

         
    }
}
