namespace Sparky
{
    public class BankAccount
    {
        public int Balance { get; set; }
        public readonly ILogBook _logBook;
        public BankAccount(ILogBook logBook)
        {
            _logBook = logBook;
            Balance = 0;
        }

        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit invoked");
            _logBook.Message("Test");
            _logBook.LogSeverity = 101;
            int temp = _logBook.LogSeverity;
            Balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (Balance >= amount)
            {
                _logBook.LogToDb($"Withdraw Amount: {amount}");
                Balance -= amount;
                return _logBook.LogBalanceAfterWithdraw(Balance);
            }
            return _logBook.LogBalanceAfterWithdraw(Balance-amount);
        }

        public int GetBalance()
        {
            return Balance;
        }
    }
}
