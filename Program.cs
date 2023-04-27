using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public class CardHolder
{

    //For Creating A DataTable
    DataTable dt = new DataTable();
    //Get The Conneaction Form The The app.Config
    string constr = ConfigurationManager.ConnectionStrings["DB_ATMEntities"].ConnectionString;



    string Cardnum;
    int pin;
    string FirstName;
    string Lastname;
    int balance;
    public CardHolder(string Cardnum, int pin, string FirstName, string Lastname, int balance)
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

    public void setfirstname(string newFirstName)
    {
        FirstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        Lastname = newLastName;
    }

    public void setBalance(int newBalance)
    {

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
            Console.WriteLine("4. You' Are Admin");
            Console.WriteLine("5. Exite");
        }


        void deposite(string depobalnce,string cardnum)
        {
            Console.WriteLine("How much $$ Would You Like To Deposite: ");
            int deposit = int.Parse(Console.ReadLine()) + int.Parse(depobalnce);
            string connstr = ConfigurationManager.ConnectionStrings["DB_ATMEntities"].ConnectionString;
            string query = @"update USR_INFO
                                set
                                BALANCE = '"+ deposit +@"'
                                where
                                CARD_NUM = '"+cardnum+"'";
            SqlConnection con = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("Thank you for $$ Your new balance is: " + deposit);
        }

        void withdraw(string withBalance,string CardNUm)
        {
            Console.WriteLine("How much $$ Would You Like To Withdraw: ");
            int withdraws = int.Parse(Console.ReadLine());
            // cheack If User has eenogh money
            if (int.Parse(withBalance) > withdraws)
            {
                int ProperBalance = int.Parse(withBalance) - withdraws;
                string connstr = ConfigurationManager.ConnectionStrings["DB_ATMEntities"].ConnectionString;
                string query = @"update USR_INFO
                                    set
                                    BALANCE = '"+ ProperBalance + @"'
                                    where
                                    CARD_NUM = '"+ CardNUm + "'";
                SqlConnection con = new SqlConnection(connstr);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Now Your's Current Balance :" + ProperBalance + " )");
                Console.WriteLine("You're good to go ! Thank You :)");
            }
            else
            {

                Console.WriteLine("Insufficient Balance :(");


            }
        }
        void balance(string Balanc)
        {
            Console.WriteLine("Current Balance: " + Balanc);
        }


        void Admin(string cardNum)
        {
            if (cardNum == "111")
            {
                Console.WriteLine("Please Provide  a new Usr First Name ..");
                string newUsrFirtname = Console.ReadLine();
                Console.WriteLine("Please Provide  a new Usr Last Name ..");
                string newUsrLastName = Console.ReadLine();
                Console.WriteLine("Please Provide  a new Usr Card Number ..");
                string newCardNum = Console.ReadLine();
                Console.WriteLine("Please Provide  a new Usr Pin ..");
                string newPin = Console.ReadLine();
                Console.WriteLine("And Last Provide Initial Balance ..");
                string newbalance = Console.ReadLine();

                string constr = ConfigurationManager.ConnectionStrings["DB_ATMEntities"].ConnectionString;
                string query = @"insert into USR_INFO
                                (CARD_NUM,PIN,FIRST_NAME,LAST_NAME,BALANCE)
                                values
                                ('"+ newCardNum + "','"+ newPin + "','"+ newUsrFirtname + "','"+ newUsrLastName + "','"+ newbalance + "')";
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Congratulation's You Created The New User");
                printOption();

            }
            else
            {
                Console.WriteLine("You's Have Not Admin Permissions : )");
            }

            Console.WriteLine(Console.ReadLine());


        }
        //List<CardHolder> cardholders = new List<CardHolder>();
        //cardholders.Add(new CardHolder("32476428374", 1234, "Annus", "Ahmed", 2300));
        //cardholders.Add(new CardHolder("34627346", 1235, "Minhaj", "Ahmed", 10000));
        //cardholders.Add(new CardHolder("231989837", 1204, "Ammad", "Ahmed", 8999));
        //cardholders.Add(new CardHolder("821873892", 0234, "Shakoor", "Ahmed", 9000));
        //cardholders.Add(new CardHolder("32847329847", 7898, "Amjad", "Ahmed", 9000));

        //Prompt User

        Console.WriteLine("Welcome To SimpeATM");
        Console.WriteLine("Please Insert Yous debit Card:");

        //string debitCardNum = "";
        //CardHolder currentuser;
        int userPin = 0;
        string FirstName = "";
        string LastName = "";
        int Balance = 0;
        string CardNum = "";
        while (true)
        {
            try
            {
                DataTable dt = new DataTable();
                string constr = ConfigurationManager.ConnectionStrings["DB_ATMEntities"].ConnectionString;
                //debitCardNum = ;
                CardNum = Console.ReadLine();
                string query = @"select * from USR_INFO where CARD_NUM = '"+ CardNum + "'";

                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                con.Dispose();
                //cheack Over db
                //currentuser = cardholders.FirstOrDefault(a => a.Cardnum == debitCardNum);
                if (dt.Rows.Count > 0)
                {
                    userPin = int.Parse(dt.Rows[0]["PIN"].ToString());
                    FirstName = dt.Rows[0]["FIRST_NAME"].ToString();
                    LastName = dt.Rows[0]["LAST_NAME"].ToString();
                    Balance =int.Parse(dt.Rows[0]["BALANCE"].ToString());
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
        
        while (true)
        {
            try
            {
                //cheack Over db
                
                if (userPin == int.Parse(Console.ReadLine()))
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

        Console.WriteLine("Welcome " + FirstName+" "+ LastName + ":)");
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
                deposite(Balance.ToString(), CardNum);
            }
            if (Option == 2)
            {
               withdraw(Balance.ToString(), CardNum);
            }
            if (Option == 3)
            {
                balance(Balance.ToString());
            }
            if (Option == 4)
            {
                Admin(CardNum);
            }
        } while (Option != 5);
        {
            Console.WriteLine("Thank You Have A Nice Day");
        }
    }

}
