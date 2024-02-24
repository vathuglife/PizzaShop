using DaoVietAnh.Asm2.Repo.Constants.Enums;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Payload.Request;
using DaoVietAnh.Asm2.Repo.Payload.Response;
using DaoVietAnh.Asm2.Repo.Services.Implementation.CategoryServiceImpl;
using DaoVietAnh.Asm2.Repo.Services.Implementation.SupplierServiceImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation.PizzaServiceImpl
{
    public class PizzaService : IPizzaService
    {
        private GetAllPizzaService? _getAllPizzaService;
        private InsertPizzaService? _insertPizzaService;
        private GetPizzaByIdService? _getPizzaByIdService;
        private CategoryService? _categoryService;
        private SupplierService? _supplierService;  
        public PizzaService()
        {
            InitializeObjects();
        }
        public Task<PizzaServiceResponse> GetAllPizzas(PizzaServicePagingParameters pageConfig)
        {
            return Task.Run(()=>_getAllPizzaService!.GetAllPizzas(pageConfig));
        }
        public PizzaServiceResponse GetPizzaById(int id)
        {
            return _getPizzaByIdService!.GetById(id);
        }
        public PizzaServiceResponse Insert(NewPizzaDTO newPizzaDTO)
        {
            try
            {                
                _insertPizzaService!.Insert(newPizzaDTO);                
                return GetSuccessfulPizzaInsertResult();
            }catch (Exception e)
            {
                return GetUnsuccessfulPizzaInsertResult(e.Message);
            }
            
        }
        private void InitializeObjects()
        {
            _getAllPizzaService = new GetAllPizzaService();
            _insertPizzaService = new InsertPizzaService();
            _getPizzaByIdService = new GetPizzaByIdService();
            _categoryService = new CategoryService();
            _supplierService = new SupplierService();
        }
        private PizzaServiceResponse GetSuccessfulPizzaInsertResult()
        {
            return new PizzaServiceResponse()
            {
                Result = PizzaServiceEnum.SUCCESS,
                Message = "Successfully inserted the pizza into the database."
            };
        }
        private PizzaServiceResponse GetUnsuccessfulPizzaInsertResult(string msg)
        {
            return new PizzaServiceResponse()
            {
                Result = PizzaServiceEnum.FAILURE,
                Message = msg
            };
        }
    }
}
