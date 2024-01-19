using System.Collections;

namespace BankService.Modules
{
    internal class User : BaseModel
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public double Balance { get; set; } = 0;
        public DateTime LastLogin { get; set; }

        public List<Card> Cards = new List<Card>();
        public User(string fullName, string password, string phone)
        {
            this.FullName = fullName;
            this.Password = password;
            this.Phone = phone;

        }

    }
}
