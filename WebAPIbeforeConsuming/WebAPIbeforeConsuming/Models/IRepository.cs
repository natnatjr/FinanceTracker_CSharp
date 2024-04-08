namespace WebAPIbeforeConsuming.Models
{
    public interface IRepository
    {
        IEnumerable<Transaction> Reservations { get; }
        Transaction this[int id] { get; }
        Transaction AddReservation(Transaction reservation);
        Transaction UpdateReservation(Transaction reservation);
        void DeleteReservation(int id);
    }
}
