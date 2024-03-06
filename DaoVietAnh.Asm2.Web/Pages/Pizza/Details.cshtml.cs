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
        private List<PizzaDTO>? _cart;

        public DetailsModel(IPizzaService pizzaService) {
            _pizzaService = pizzaService;
        }
        public void OnGet(int pizzaId)
        {                                
            SelectedPizza = (PizzaDTO) _pizzaService.GetPizzaById(pizzaId).ReturnData!;    
        }
        public IActionResult OnPostAddToCart([FromBody] PizzaDTO? pizza)
        {
            SelectedPizza = pizza;
            GetCart();
            AddToCart();
            return RedirectToPage("/Pizza/Details");
        }
        private void GetCart()
        {
            string cart = HttpContext.Session.GetString("cart")!;
            _cart = JsonConvert.DeserializeObject<List<PizzaDTO>>(cart);
        }
        private void AddToCart()
        {
            _cart!.Add(SelectedPizza!);
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(_cart));
            
        }
    }
}
