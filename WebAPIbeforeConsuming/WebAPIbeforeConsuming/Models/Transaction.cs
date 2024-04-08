namespace WebAPIbeforeConsuming.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeTransaction { get; set; }
        public double Amount { get; set; }
    }
}
