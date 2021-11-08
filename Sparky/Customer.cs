namespace Sparky
{
    public class Customer
    {
        public int Discount = 15;
        public string GreetMessage { get; set; }

        public string GreetAndCombineNames(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("Empty First Name");
            }

            GreetMessage = $"Hello, {firstName} {lastName}";
            Discount = 20;
            return GreetMessage;
        }
    }
}
