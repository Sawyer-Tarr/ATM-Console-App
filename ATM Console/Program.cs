using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;


    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance) 
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    
    }

    public string getNum()
    { 
        return cardNum; 
    }

    public int getPin() 
    {
        return pin;
    }

    public string getFirstName() 
    {
        return firstName;
    }

    public string getLastName() 
    {
        return lastName;
    }

    public double getBalance()
    { 
        return balance; 
    }

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(string newFirstName) 
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit?");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw?");
            double withdrawal = double.Parse(Console.ReadLine());
            if(currentUser.getBalance() < withdrawal) 
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you and have a nice day.");
            }    
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4654816813513", 1234, "Greg", "Jenning", 150.31));
        cardHolders.Add(new cardHolder("6846816638546", 4321, "Jolene", "Calt", 254.65));
        cardHolders.Add(new cardHolder("8481351563481", 5678, "Bob", "Bobbers", 421.94));
        cardHolders.Add(new cardHolder("6584651685135", 8765, "John", "Smith", 94.37));

        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);

                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again.");
            }
        }
         
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect PIN. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect PIN. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1)
            {
                deposit(currentUser);
            }
            else if (option == 2)
            {
                withdraw(currentUser);
            }
            else if (option == 3)
            {
                balance(currentUser);
            }
            else if ( option == 4)
            {
                break;
            }
            else 
            {
                option = 0;
            }
        }
        while (option != 4); 
        {

        }

    }

}