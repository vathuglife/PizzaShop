using DaoVietAnh.Asm2.Repo.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DaoVietAnh.Asm2.Web.Pages.Pizza
{
    public class DetailsModel : PageModel
    {
        public PizzaDTO? SelectedPizza;
        public IActionResult OnGet(string selectedPizza)
        {
            SelectedPizza = JsonConvert.DeserializeObject<PizzaDTO>(selectedPizza);
            return Page();
        }
    }
}
