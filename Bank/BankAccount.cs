namespace BankAccountNS
{
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);

            if (amount < 0)
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);

            m_balance -= amount;
        }

        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("amount");

            m_balance -= amount;
        }

        public static void Main()
        {
            BankAccount bankAccount = new BankAccount("Altuğ Çelik", 11.99);

            bankAccount.Credit(81.81);
            bankAccount.Debit(81.01);
            Console.WriteLine(@$"Current balance is {bankAccount.Balance}");
        }
    }
}