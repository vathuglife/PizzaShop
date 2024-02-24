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
    public class CategoryService : ICategoryService
    {              
        private GetAllCategoriesService? _getAllCategoriesService; 
        private InsertCategoryByNewPizzaDTOService? _insertCategoryByPizzaDTOService;    
        public CategoryService()
        {
            InitializeObjects();
        }
        
        public CategoryServiceResponse GetCategories()
        {
            return _getAllCategoriesService!.GetCategories();
        }
        //public CategoryServiceResponse InsertCategoryByNewPizzaDTO(NewPizzaDTO newPizzaDTO)
        //{
        //    return _insertCategoryByPizzaDTOService!.Insert(newPizzaDTO);
        //}
        private void InitializeObjects()
        {
            _getAllCategoriesService = new GetAllCategoriesService();
            _insertCategoryByPizzaDTOService = new InsertCategoryByNewPizzaDTOService();

        }
       
       
      
    }
}
