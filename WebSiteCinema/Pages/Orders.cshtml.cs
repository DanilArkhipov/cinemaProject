using Microsoft.AspNetCore.Mvc.RazorPages;
using ORM;

namespace WebSiteCinema.Pages
{
    public class Orders : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        
        public void OnGet()
        {
            
        }

        public void OnPost(object[] places)
        {
           
        }
    }
}