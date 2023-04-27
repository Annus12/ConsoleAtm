using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CardHolder
{
    string Cardnum;
    int pin;
    string FirstName;
    string Lastname;
    int balance;
    public CardHolder(string Cardnum,int pin,string FirstName, string Lastname,int balance)
    {
        this.Cardnum = Cardnum;
        this.pin = pin;
        this.FirstName = FirstName;
        this.Lastname = Lastname;
        this.balance = balance;
    }

    public string getNum()
    {
        return Cardnum;
    }
    public int getPin()
    {
        return pin;
    }
    public string getFirstName()
    {
        return FirstName;
    }
    public string getLastName()
    {
        return Lastname;
    }
    public int getBalance()
    {
        return balance;
    }

    public void setNum(string newcardNum)
    {
        Cardnum = newcardNum;
    }
    public void setPin(int newpin)
    {
        pin = newpin;
    }

    public void setfirstname(string newFirstName) {
        FirstName = newFirstName;
    }

    public void setLastName(string newLastName) 
    {
        Lastname = newLastName;
    }

    public void setBalance(int newBalance) {

        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOption()
        {
            Console.WriteLine("Please Choose Form One Of The Following Options...");
            Console.WriteLine("1. Deposite");
            Console.WriteLine("2. Withdrow");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exite");
        }


        void deposite(CardHolder CurrentUser)
        {
            Console.WriteLine("How much $$ Would You Like To Deposite: ");
            int deposit = int.Parse(Console.ReadLine());
            CurrentUser.setBalance(CurrentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for $$ Your new balance is: " + CurrentUser.getBalance());
        }

        void withdraw(CardHolder CurrentUser)
        {
            Console.WriteLine("How much $$ Would You Like To Withdraw: ");
            int withdraw = int.Parse(Console.ReadLine());
            // cheack If User has eenogh money
            if (CurrentUser.getBalance() > withdraw)
            {
                CurrentUser.setBalance(CurrentUser.getBalance() - withdraw);
                Console.WriteLine("Now Your's Current Balance :" +CurrentUser.getBalance()+" )");
                Console.WriteLine("You're good to go ! Thank You :)");
            }
            else
            {
   
                Console.WriteLine("Insufficient Balance :(");


            }
        }
         void balance(CardHolder currentUser)
        {
            Console.WriteLine("Current Balance: " + currentUser.getBalance());
        }

        List<CardHolder> cardholders = new List<CardHolder>();
        cardholders.Add(new CardHolder("32476428374", 1234, "Annus", "Ahmed", 2300));
        cardholders.Add(new CardHolder("34627346", 1235, "Minhaj", "Ahmed", 10000));
        cardholders.Add(new CardHolder("231989837", 1204, "Ammad", "Ahmed", 8999));
        cardholders.Add(new CardHolder("821873892", 0234, "Shakoor", "Ahmed", 9000));
        cardholders.Add(new CardHolder("32847329847", 7898, "Amjad", "Ahmed", 9000));

        //Prompt User

        Console.WriteLine("Welcome To SimpeATM");
        Console.WriteLine("Please Insert Yous debit Card:");

        string debitCardNum = "";
        CardHolder currentuser;
        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //cheack Over db
                currentuser = cardholders.FirstOrDefault(a => a.Cardnum == debitCardNum);
                if (currentuser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("card Not recognized. Please try Agin");
                }
            }
            catch
            {
                Console.WriteLine("card Not recognized. Please try Agin");

            }

            
        }
        Console.WriteLine("Please Insert Your Pin");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //cheack Over db
                if (currentuser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect Pin. Please try Agin");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect Pin. Please try Agin");

            }


        }

        Console.WriteLine("Welcome " + currentuser.getFirstName() + ":)");
        int Option = 0;
        do
        {
            printOption();
            try 
            {
                Option = int.Parse(Console.ReadLine());
            }
            catch
            {

            }

            if (Option == 1)
            {
                deposite(currentuser);
            }
            if (Option == 2)
            {
                withdraw(currentuser);
            }
            if (Option == 3)
            {
                balance(currentuser);
            } 
        } while (Option != 4);
        {
            Console.WriteLine("Thank You Have A Nice Day");
        }
    }

}
