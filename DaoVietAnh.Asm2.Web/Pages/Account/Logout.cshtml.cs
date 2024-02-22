using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DaoVietAnh.Asm2.Web.Pages.Account
{
    public class LogoutModel : PageModel
    {       
        public IActionResult OnGet() {
            Logout();
            return new RedirectToPageResult("/Index");
        }

        public void Logout()
        {
            HttpContext.Session.Clear();            
        }
    }
}
