using DaoVietAnh.Asm2.Repo.Constants.Enums;
using DaoVietAnh.Asm2.Repo.DAL;
using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Entities;
using DaoVietAnh.Asm2.Repo.Payload.Request;
using DaoVietAnh.Asm2.Repo.Payload.Response;
using DaoVietAnh.Asm2.Repo.Utils;

namespace DaoVietAnh.Asm2.Repo.Services.Implementation.PizzaServiceImpl
{
    public class GetPizzasByService
    {
        private IUnitOfWork _unitOfWork;
        private GetPizzasByRequest? _request;
        private List<PizzaDTO>? _pizzaDTOs;
        private IEnumerable<Product>? _pizzas;
        private Dictionary<GetPizzasByEnum, Action>? _getPizzasByCases;

        public GetPizzasByService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeObjects();
        }
        public PizzaServiceResponse GetBy(GetPizzasByRequest request)
        {
            _request = request;
            if (!IsRequestValid()) return GetInvalidInputResult();
            GetPizzasByRequest();
            ConvertPizzasToPizzaDTOs();
            return GetSuccessfulGetPizzaByResult();
        }
        private void InitializeObjects()
        {
            _getPizzasByCases = new Dictionary<GetPizzasByEnum, Action>
        {
            { GetPizzasByEnum.ID,() => GetById() } ,
            { GetPizzasByEnum.NAME,() => GetByName() },
            { GetPizzasByEnum.UNIT_PRICE,() => GetByUnitPrice() }
        };
            _pizzaDTOs = new List<PizzaDTO>();
        }
        private void GetPizzasByRequest()
        {
            _getPizzasByCases?.First(kvp => kvp.Key == _request!.Option)
               .Value();
        }
        private void ConvertPizzasToPizzaDTOs()
        {
            foreach (var pizza in _pizzas!)
            {
                Category category = _unitOfWork?.CategoryRepository!.GetByID(pizza.CategoryId!)!;
                PizzaDTO pizzaDTO = GetPizzaDTO(pizza, category);
                _pizzaDTOs?.Add(pizzaDTO);
            }
        }

        private void GetById()
        {
            _pizzas = _unitOfWork!.ProductRepository!
                .Get(pizza => pizza.ProductId ==
                Int32.Parse(_request!.Value!));
        }
        private void GetByName()
        {
            _pizzas = _unitOfWork!.ProductRepository!
                .Get(pizza => pizza.ProductName!
                .Contains(_request!.Value!));
        }
        private void GetByUnitPrice()
        {
            _pizzas = _unitOfWork!.ProductRepository!
                .Get(pizza => pizza.UnitPrice ==
                Decimal.Parse(_request!.Value!)
                );
        }
        private bool IsRequestValid()
        {
            if (ValidationUtils.IsDecimal(_request?.Value!) ||
                ValidationUtils.IsNumeric(_request?.Value!) ||
                !string.IsNullOrEmpty(_request?.Value!))
                return true;
            return false;
        }
        private PizzaDTO GetPizzaDTO(Product pizza, Category category)
        {

            return new PizzaDTO
            {
                Id = pizza.ProductId,
                Name = pizza.ProductName,
                Category = category.CategoryName,
                Description = category.Description,
                Price = pizza.UnitPrice,
                Image = ImageUtils.GetBase64ImageFromByteArray(pizza.ProductImage!)

            };
        }
        private PizzaServiceResponse GetSuccessfulGetPizzaByResult()
        {
            return new PizzaServiceResponse()
            {
                Result = PizzaServiceEnum.SUCCESS,
                Message = "",
                ReturnData = _pizzaDTOs
            };
        }
        private PizzaServiceResponse GetInvalidInputResult()
        {
            return new PizzaServiceResponse()
            {
                Result = PizzaServiceEnum.FAILURE,
                Message = "The input data is invalid. Please try again."
            };
        }
    }
}
