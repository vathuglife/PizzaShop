using DaoVietAnh.Asm2.Repo.Constants.Enums;
using DaoVietAnh.Asm2.Repo.DAL;
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
        private GetPizzasByService? _getPizzasByService;    
        private IUnitOfWork _unitOfWork;

        public PizzaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeObjects();
        }
        public Task<PizzaServiceResponse> GetAllPizzas(PizzaServicePagingRequest pageConfig)
        {
            return Task.Run(() => _getAllPizzaService!.GetAllPizzas(pageConfig));
        }
        public Task<PizzaServiceResponse> GetPizzasBy(GetPizzasByRequest getPizzaByRequest)
        {
            return Task.Run(() => _getPizzasByService!.GetBy(getPizzaByRequest));
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
            _getAllPizzaService = new GetAllPizzaService(_unitOfWork);
            _insertPizzaService = new InsertPizzaService(_unitOfWork);
            _getPizzaByIdService = new GetPizzaByIdService(_unitOfWork);
            _getUpdatePizzaByIdService = new GetUpdatePizzaByIdService(_unitOfWork);
            _deletePizzaByIdService = new DeletePizzaByIdService(_unitOfWork);
            _updatePizzaService = new UpdatePizzaService(_unitOfWork);
            _getPizzasByService = new GetPizzasByService(_unitOfWork);
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
