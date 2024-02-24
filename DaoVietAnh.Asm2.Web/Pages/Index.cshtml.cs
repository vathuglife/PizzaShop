using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Payload.Request;
using DaoVietAnh.Asm2.Repo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DaoVietAnh.Asm2.Web.Pages
{
    public class IndexModel : PageModel
    {

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; } = 15;
       
        private readonly IPizzaService _pizzaService;

        public IndexModel(IPizzaService pizzaService)

        {
            _pizzaService = pizzaService;
        }

        public async Task OnGetAsync(int pageNumber)
        {
            var pizzaServiceResult = await _pizzaService.GetAllPizzas(
                new PizzaServicePagingParameters()
                {
                    PageNumber = pageNumber,
                    PageSize = PageSize
                }
            );
            ViewData["Pizzas"] = pizzaServiceResult.ReturnData;
        }
        public IActionResult OnPostShowDetails(int pizzaId)
        {                       
            return RedirectToPage("/Pizza/Details", new { pizzaId = pizzaId});
        }
    }
}
