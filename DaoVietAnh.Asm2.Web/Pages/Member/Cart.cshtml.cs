using DaoVietAnh.Asm2.Repo.DTO;
using DaoVietAnh.Asm2.Repo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DaoVietAnh.Asm2.Web.Pages.Member
{
    [BindProperties]
    public class CartModel : PageModel
    {
        public List<PizzaDTO>? Cart;
        public int TotalCount;
        public int PageNumber;
        private int _pizzaId;
        private IOrderService _orderService;
        public CartModel(IOrderService orderService) {
            _orderService = orderService;
        }
        public void OnGet()
        {
            GetCartFromSession();
        }
        public IActionResult OnPostRemoveFromCart(int id)
        {
            _pizzaId = id;
            GetCartFromSession();
            RemovePizzaFromCart();
            return RedirectToPage("/Member/Cart");
        }
        public IActionResult OnPostPlaceOrder()
        {

        }
        private void RemovePizzaFromCart()
        {
            PizzaDTO pizzaDTO = Cart!.Single(pizza => pizza.Id == _pizzaId);
            Cart!.Remove(pizzaDTO);
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(Cart!));
        }
        private void GetCartFromSession()
        {
            string cart = HttpContext.Session.GetString("cart")!;
            Cart = JsonConvert.DeserializeObject<List<PizzaDTO>>(cart);    
        }
    }
}
