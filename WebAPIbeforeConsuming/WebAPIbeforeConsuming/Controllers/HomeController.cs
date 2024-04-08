using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAPIbeforeConsuming.Models;

namespace WebAPIbeforeConsuming.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _ticketReservation;
        public HomeController(IRepository ticketReservation)
        {
            _ticketReservation = ticketReservation;
        }

        public IActionResult Index()
        {
            return View(_ticketReservation.Reservations);
        }

        [HttpPost]
        public IActionResult AddReservation(Transaction reservation) {
            _ticketReservation.AddReservation(reservation);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteReservation(int reservationId)
        {
            _ticketReservation.DeleteReservation(reservationId);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
