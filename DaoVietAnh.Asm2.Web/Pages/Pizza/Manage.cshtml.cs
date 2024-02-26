using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Payload.Request;
using DaoVietAnh.Asm2.Repo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DaoVietAnh.Asm2.Web.Pages.Pizza
{
    public class ManageModel : PageModel
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; } = 15;
        public List<PizzaDTO>? PizzaDTOs;
        private IPizzaService _pizzaService;

        public ManageModel(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public async Task OnGet()
        {
            var result = await Task.Run(() =>
                _pizzaService.GetAllPizzas(new PizzaServicePagingParameters()
                {
                    PageNumber = PageNumber,
                    PageSize = PageSize
                })
            );
            PizzaDTOs = (List<PizzaDTO>)result.ReturnData!;
        }
        public IActionResult OnPostDeletePizza(int id)
        {
            var result = _pizzaService.Delete(id);
            return RedirectToPage("/Pizza/Manage");
        }
        public IActionResult OnPostUpdatePizza(int pizzaId)
        {
            return RedirectToPage("/Pizza/Update", new { pizzaId = pizzaId });        
        }
    }
}
