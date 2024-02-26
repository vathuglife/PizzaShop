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
        private DeletePizzaByIdService? _deletePizzaByIdService;
        private GetUpdatePizzaByIdService? _getUpdatePizzaByIdService;
        private UpdatePizzaService? _updatePizzaService; 

        public PizzaService()
        {
            InitializeObjects();
        }
        public Task<PizzaServiceResponse> GetAllPizzas(PizzaServicePagingParameters pageConfig)
        {
            return Task.Run(() => _getAllPizzaService!.GetAllPizzas(pageConfig));
        }
        public PizzaServiceResponse GetPizzaById(int id)
        {
            return _getPizzaByIdService!.GetById(id);
        }
        public PizzaServiceResponse GetUpdatePizzaById(int id)
        {
            return _getUpdatePizzaByIdService!.Get(id);
        }
        public PizzaServiceResponse Insert(NewPizzaDTO newPizzaDTO)
        {
            try
            {
                _insertPizzaService!.Insert(newPizzaDTO);
                return GetSuccessfulPizzaInsertResult();
            }
            catch (Exception e)
            {
                return GetUnsuccessfulPizzaInsertResult(e.Message);
            }

        }
        public PizzaServiceResponse Update(UpdatePizzaDTO updatePizzaDTO)
        {
            try
            {
                _updatePizzaService!.Update(updatePizzaDTO);
                return GetSuccessfulPizzaInsertResult();
            }
            catch (Exception e)
            {
                return GetUnsuccessfulPizzaInsertResult(e.Message);
            }

        }
        public PizzaServiceResponse Delete(int id)
        {
            try
            {
                _deletePizzaByIdService!.Delete(id);
                return GetSuccessfulPizzaDeleteResult();
            }
            catch (Exception e)
            {
                return GetUnsuccessfulPizzaDeleteResult(e.Message);
            }
        }
        private void InitializeObjects()
        {
            _getAllPizzaService = new GetAllPizzaService();
            _insertPizzaService = new InsertPizzaService();
            _getPizzaByIdService = new GetPizzaByIdService();
            _getUpdatePizzaByIdService = new GetUpdatePizzaByIdService();
            _deletePizzaByIdService = new DeletePizzaByIdService();
            _updatePizzaService = new UpdatePizzaService();
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
        private PizzaServiceResponse GetSuccessfulPizzaDeleteResult()
        {
            return new PizzaServiceResponse()
            {
                Result = PizzaServiceEnum.SUCCESS,
                Message = "Successfully deleted the pizza from the database."
            };
        }
        private PizzaServiceResponse GetUnsuccessfulPizzaDeleteResult(string msg)
        {
            return new PizzaServiceResponse()
            {
                Result = PizzaServiceEnum.FAILURE,
                Message = msg
            };
        }        
    }
}
