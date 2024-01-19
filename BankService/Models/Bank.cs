using System.Reflection.Metadata;

namespace BankService.Modules
{
    internal class Bank : BaseModel
    {
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        DateTime createdAt { get; set; }
        public Bank(string name, string address, string phone, DateTime createdAt)
        {
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.createdAt = createdAt;
        }

    }
}
