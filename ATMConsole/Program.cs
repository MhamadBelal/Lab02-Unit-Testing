namespace ATMConsole
{
    public class Program
    {
        static public decimal Balance = 0;
        static void Main(string[] args)
        {
            UserInterface();
        }

        public static void UserInterface()
        {
            Console.WriteLine("Welcome to the ATM!");

            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Withdraw Cash");
                Console.WriteLine("3. Deposit Cash");
                Console.WriteLine("4. Quit");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine($"Your current balance is: {ViewBalance():C}");
                        break;
                    case "2":
                        Console.WriteLine("Enter the amount to withdraw:");
                        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        decimal withdrawnAmount = Withdraw(withdrawAmount);
                        if (withdrawnAmount >= 0)
                            Console.WriteLine($"Your Balance now is {withdrawnAmount:C}");
                        else if (withdrawnAmount == -1)
                            Console.WriteLine("Insufficient funds");
                        else
                            Console.WriteLine("Invalid amount");
                        break;
                    case "3":
                        Console.WriteLine("Enter the amount to deposit:");
                        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                        decimal depositedAmount = Deposit(depositAmount);
                        if (depositedAmount >= 0)
                            Console.WriteLine($"Your Balance now is {depositedAmount:C}");
                        else
                            Console.WriteLine("Invalid amount");
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

        }

        public  static decimal ViewBalance()
        {
            return Balance;
        }

        public static decimal Withdraw(decimal amount)
        {

            if (amount > Balance)
            {
                return -1; // Insufficient funds
            }

            if (amount < 0)
            {
                return -2; // Invalid amount
            }

            Balance -= amount;
            return Balance;
        }

        public static decimal Deposit(decimal amount)
        {
            if (amount < 0)
            {
                return -1; // Invalid amount
            }

            Balance += amount;
            return Balance;
        }


    }
}