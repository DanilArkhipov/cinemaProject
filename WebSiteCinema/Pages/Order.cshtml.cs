using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ORM;
using WebSiteCinema.DataStorage;
using WebSiteCinema.Services;

namespace WebSiteCinema.Pages
{
    public class Order : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IAuthorization _authorization;

        public Order(UnitOfWork unitOfWork, IAuthorization authorization)
        {
            _unitOfWork = unitOfWork;
            _authorization = authorization;
        }
        public IActionResult OnGet(string places)
        {
            if (_authorization.Authenticated)
            {
                return Page();
            }
            else return RedirectToPage("/Login");
        }

        public async Task<IActionResult> OnPostOrder(string number,int session_id)
        {
            try
            {
                var placeNumber = session_id + "-" + number;
                var place = await _unitOfWork.PlaceRepository.GetByNameAsync(placeNumber);
                var order = new Models.Order(place.id, _authorization.UserData.Login, DateTime.Now,
                    Guid.NewGuid().ToString());
                await _unitOfWork.OrderRepository.InsertAsync(order);
                await _unitOfWork.PlaceRepository.UpdateStatus(placeNumber,PlaceStatus.Reserved);
                return RedirectToPage("/Thanks", new {user_login = _authorization.UserData.Login,code = order.code});
            }
            catch
            {
                return Page();
            }

            
        }
    }
}