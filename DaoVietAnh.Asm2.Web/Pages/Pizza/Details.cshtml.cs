using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DaoVietAnh.Asm2.Web.Pages.Pizza
{
    public class DetailsModel : PageModel
    {
        public PizzaDTO? SelectedPizza;
        private IPizzaService _pizzaService;

        public DetailsModel(IPizzaService pizzaService) {
            _pizzaService = pizzaService;
        }
        public void OnGet(int pizzaId)
        {                                
            SelectedPizza = (PizzaDTO) _pizzaService.GetPizzaById(pizzaId).ReturnData!;    
        }
    }
}
