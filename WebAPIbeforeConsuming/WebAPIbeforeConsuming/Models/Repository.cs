namespace WebAPIbeforeConsuming.Models
{
    public class Repository : IRepository
    {
        private Dictionary<int, Transaction> items;

        public Repository()
        {
            items = new Dictionary<int, Transaction>();
            new List<Transaction> {
                new Transaction {Id=1, Name = "Ankit", TypeTransaction = "Debit", Amount=34 },
                new Transaction {Id=2, Name = "Bobby", TypeTransaction = "Credit", Amount=99.6 },
                new Transaction {Id=3, Name = "Jacky", TypeTransaction = "Credit", Amount=34.7 }
                }.ForEach(r => AddReservation(r));
        }

        public Transaction this[int id] => items.ContainsKey(id) ? items[id] : null;

        public IEnumerable<Transaction> Reservations => items.Values;

        public Transaction AddReservation(Transaction reservation)
        {
            if (reservation.Id == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                reservation.Id = key;
            }
            items[reservation.Id] = reservation;
            return reservation;
        }

        public void DeleteReservation(int id) => items.Remove(id);

        public Transaction UpdateReservation(Transaction reservation) => AddReservation(reservation);
    }
}
