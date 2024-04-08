using Microsoft.AspNetCore.Mvc;
using WebAPIbeforeConsuming.Models;

namespace APIControllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private IRepository repository;
        public ReservationController(IRepository repo) => repository = repo;

        [HttpGet]
        public IEnumerable<Transaction> Get() => repository.Reservations;

        [HttpGet("{id}")]
        public ActionResult<Transaction> Get(int id)
        {
            if (id == 0)
                return BadRequest("Value must be passed in the request body.");
            return Ok(repository[id]);
        }

        [HttpPost]
        public Transaction Post([FromBody] Transaction res) =>
        repository.AddReservation(new Transaction
        {
            Id = res.Id,
            Name = res.Name,
            TypeTransaction = res.TypeTransaction,
            Amount = res.Amount
        });

        [HttpPut]
        public Transaction Put([FromForm] Transaction res) => repository.UpdateReservation(res);

        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteReservation(id);

        [HttpPost]
        public async Task<IActionResult> DeleteReservation(int ReservationId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await
                httpClient.DeleteAsync("http://localhost:5154/api/Reservation/" + ReservationId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
}