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
    public class InsertCategoryByNewPizzaDTOService
    {
        private NewPizzaDTO? _newPizzaDTO;
        private IUnitOfWork? _unitOfWork;
        private Category? _category;
        private Mapper? _categoryMapper;
        public InsertCategoryByNewPizzaDTOService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeObjects();
        }
        public void Insert(NewPizzaDTO newPizzaDTO)
        {
            _newPizzaDTO = newPizzaDTO;
            MapNewPizzaDTOToCategory();
            InsertPizzaCategoryIntoDB();            
        }
      
        private void InitializeObjects()
        {
            _categoryMapper = new Mapper(CategoryMapper.NewPizzaDTOToCategoryMap());            
        }
        
        private void MapNewPizzaDTOToCategory()
        {
            _category = _categoryMapper!.Map<Category>(_newPizzaDTO);
            _category.CategoryId = GetLatestCategoryId();
        }
        private void InsertPizzaCategoryIntoDB()
        {
            _unitOfWork!.CategoryRepository!.Insert(_category!);
            _unitOfWork!.Save();
        }
        private int GetLatestCategoryId()
        {
            Category latestCategory = _unitOfWork?.CategoryRepository?
                .Get()
                .OrderByDescending(category => category.CategoryId)
                .FirstOrDefault()!;
            if (latestCategory == null) return 0;
            int latestCategoryId = latestCategory.CategoryId + 1;
            return latestCategoryId;
        }               

    }
}
