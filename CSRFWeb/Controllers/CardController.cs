using CSRFWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSRFWeb.Controllers
{

    [Route("[controller]")]
    public class CardController : Controller
    {
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Card(int id)
        {
            Card card = new Card() { CardNumber = "1234 5678 9012 3456", CVV = "123", ExpiryDate = "12/2022", Name = "John Doe", Id = id };

            return View(card);
        }
    }
}
