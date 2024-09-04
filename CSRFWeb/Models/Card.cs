namespace CSRFWeb.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpiryDate { get; set; }
        public string? CVV { get; set; }

    }
}
