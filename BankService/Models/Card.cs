namespace BankService.Modules
{
    internal class Card : BaseModel
    {
        public string Number { get; set; }
        public string Pin { get; set; }
        public double Balance { get; set; } = 0;
        public DateTime ExpireAt { get; set; }
        public bool Blocked { get; set; } = false;

        public Card(string number, string pin,DateTime expireAt)
        {
            Number = number;
            Pin = pin;
            ExpireAt = expireAt;
        }
    }
}
