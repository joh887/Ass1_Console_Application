using System;
using System.IO;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Menu
    {
        public void mainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                ShowMenu();
                exit = SelectMenu();
            }
            Console.ReadKey(true);
        }
        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃    WELCOME TO SIMPLE BANKING SYSTEM    ┃");
            Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
            Console.WriteLine("┃         1. Create a new account        ┃");
            Console.WriteLine("┃         2. Search for an account       ┃");
            Console.WriteLine("┃         3. Deposit                     ┃");
            Console.WriteLine("┃         4. Withdraw                    ┃");
            Console.WriteLine("┃         5. A/C statement               ┃");
            Console.WriteLine("┃         6. Delete account              ┃");
            Console.WriteLine("┃         7. Exit                        ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        }
        public bool SelectMenu()
        {
            while(true)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                //erase the input user inserted from the screen
                Console.Write("\b \b"); 
                char ch = userInput.KeyChar;
                switch (ch)
                {
                    case '1':
                        createAccount();
                        return false;
                    case '2':
                        searchAccount();
                        return false;
                    case '3':
                        deposit();
                        return false;
                    case '4':
                        withdrawal();
                        return false;
                    case '5':
                        accountStatement();
                        return false;
                    case '6':
                        delete();
                        return false;
                    case '7':
                        Console.WriteLine("Program End");
                        return true;
                    default:
                        Console.Write("\b \b");
                        break;
                }
            }
        }

        public void createAccount()
        {
            bool flag = false;
            string firstName;
            string lastName;
            string address;
            int phone;
            string email;
            do
            {
                Console.Clear();
                Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("┃           CREATE A NEW ACCOUNT         ┃");
                Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
                Console.WriteLine("┃            ENTER THE DETAILS           ┃");
                Console.WriteLine("┃  First Name  :                         ┃");
                Console.WriteLine("┃  Last Name   :                         ┃");
                Console.WriteLine("┃  Address     :                         ┃");
                Console.WriteLine("┃  Phone       :                         ┃");
                Console.WriteLine("┃  Email       :                         ┃");
                Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

                Console.SetCursorPosition(16, 4);
                firstName = Console.ReadLine();
                Console.SetCursorPosition(16, 5);
                lastName = Console.ReadLine();
                Console.SetCursorPosition(16, 6);
                address = Console.ReadLine();
                phone = 0;
                email = null;
                //Field check for phone
                do
                {
                    Console.SetCursorPosition(16, 7);
                    string sPhone = Console.ReadLine();

                    if (sPhone.Length <= 10)
                    {
                        try
                        {
                            phone = Convert.ToInt32(sPhone);
                            flag = true;
                        }
                        catch
                        {
                            Console.SetCursorPosition(16,7);
                            //erase wrongly inserted text in console
                            Console.WriteLine("                        "); 
                            Console.SetCursorPosition(1, 10);
                            Console.WriteLine("Phone number should be a integer             ");
                            Console.ReadKey(true);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(16, 7);
                        Console.WriteLine("                        ");
                        Console.SetCursorPosition(1, 10);
                        Console.WriteLine("The character should be no more than 10          ");
                        Console.ReadKey(true);
                    }
                } while (flag == false);
                Console.SetCursorPosition(1, 10);
                Console.WriteLine("                                       ");
                flag = false;
                //field check for email
                do
                {
                    Console.SetCursorPosition(16, 8);
                    email = Console.ReadLine();   
                    if (email.Contains("@"))
                    {
                        if (email.Contains("gmail.com") ||
                            email.Contains("outlook.com") || email.Contains("uts.edu.au"))
                        {
                            flag = true;
                        }
                        else
                        {
                            Console.SetCursorPosition(16, 8);
                            Console.WriteLine("                        ");
                            Console.SetCursorPosition(1, 10);
                            Console.WriteLine("The Email should be one of gmail, outlook, or UTS domain       ");
                            Console.ReadKey(true);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(16, 8);
                        Console.WriteLine("                        ");
                        Console.SetCursorPosition(1, 10);
                        Console.WriteLine("The email must contain '@'                        ");
                        Console.ReadKey(true); ;
                    }
                } while (flag == false);

                Console.Clear();
                Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("┃              DETAIL CHECK              ┃");
                Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
                Console.WriteLine("┃                                        ┃");
                Console.WriteLine("┃  First Name  :                         ┃");
                Console.WriteLine("┃  Last Name   :                         ┃");
                Console.WriteLine("┃  Address     :                         ┃");
                Console.WriteLine("┃  Phone       :                         ┃");
                Console.WriteLine("┃  Email       :                         ┃");
                Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Console.SetCursorPosition(16, 4);
                Console.WriteLine(firstName);
                Console.SetCursorPosition(16, 5);
                Console.WriteLine(lastName);
                Console.SetCursorPosition(16, 6);
                Console.WriteLine(address);
                Console.SetCursorPosition(16, 7);
                Console.WriteLine(phone);
                Console.SetCursorPosition(16, 8);
                Console.WriteLine(email);

                flag = false; 
                bool yes_or_no_flag = false; 

                do
                {
                    Console.SetCursorPosition(1, 10);
                    Console.WriteLine("Is the information correct?(y/n)");
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.KeyChar == 'Y' || key.KeyChar == 'y')
                    {
                        yes_or_no_flag = true;
                        flag = true;
                    }
                    else if (key.KeyChar == 'N' || key.KeyChar == 'n')
                    {
                        yes_or_no_flag = true;
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("Insert Y/N to continue ");
                    }
                } while (yes_or_no_flag == false);

            } while (flag == false);



            int accountNum = generateAccountNumber();
            Console.WriteLine("The generated Account Number is: {0}", accountNum);
            Console.WriteLine("Account details will be provided via email");


            string str = string.Format(".\\{0}.txt", accountNum);
            using (StreamWriter sw = new StreamWriter(str))
            {
                sw.WriteLine("First Name|{0}", firstName);
                sw.WriteLine("Last Name|{0}", lastName);
                sw.WriteLine("Address|{0}", address);
                sw.WriteLine("Phone|{0}", phone);
                sw.WriteLine("Email|{0}", email);
                sw.WriteLine("accountNo|{0}", accountNum);
                sw.WriteLine("Balance|0");
            }

            string body = string.Format("<html><body>First Name: {0}<br>Last Name: {1}<br>Address: {2}<br>Phone number: {3}<br> Email: {4}<br>accountNumber: {5}<br></body></html> ",
                        firstName, lastName, address, phone, email, accountNum);
            sendEMail(email, body);
            
        }
        //Number of built account numbers are saved in txt file to avoid duplication
        public int generateAccountNumber()
        {
            int accountNum;
            StreamReader sr = new StreamReader(".\\accountCounter.txt");
            accountNum = Convert.ToInt32(sr.ReadLine());
            sr.Close();
            StreamWriter sw = new StreamWriter(".\\accountCounter.txt");
            sw.Write(accountNum + 1);
            sw.Close();
            return accountNum;
        }
        public void searchAccount()
        {
            bool flag = false;
            do
            {
                Console.Clear();
                Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("┃        SEARCH AN ACCOUNT        ┃");
                Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
                Console.WriteLine("┃        ENTER THE DETAILS        ┃");
                Console.WriteLine("┃  Account Number :               ┃");
                Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Console.SetCursorPosition(20, 4);
                string strAccountNum = Console.ReadLine();
                if (check10Char(strAccountNum))
                {

                    int accountNum = changeUserInputToDigit(strAccountNum);
                    if (accountNum == -1)
                    {
                        Console.SetCursorPosition(1, 6);
                        Console.WriteLine("Account Number should be an integer");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        if (isValid(accountNum))
                        {
                            string path = string.Format(".\\{0}.txt", accountNum);
                            StreamReader sr = new StreamReader(path);
                            string line;
                            Console.Clear();
                            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                            Console.WriteLine("┃           ACCOUNT DETAILS              ┃");
                            Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
                            Console.WriteLine("┃                                        ┃");
                            Console.WriteLine("┃  Account No  :                         ┃");
                            Console.WriteLine("┃  Balance     :                         ┃");
                            Console.WriteLine("┃  First Name  :                         ┃");
                            Console.WriteLine("┃  Last Name   :                         ┃");
                            Console.WriteLine("┃  Address     :                         ┃");
                            Console.WriteLine("┃  Phone       :                         ┃");
                            Console.WriteLine("┃  Email       :                         ┃");
                            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                            Console.WriteLine("┃     SEARCH FOR OTHER ACCOUNT? (Y/N)    ┃");
                            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] items = line.Split('|');

                                switch (items[0])
                                {
                                    case "accountNo":
                                        Console.SetCursorPosition(16, 4);
                                        Console.Write(items[1]);
                                        break;
                                    case "Balance":
                                        Console.SetCursorPosition(16, 5);
                                        Console.Write(items[1]);
                                        break;
                                    case "First Name":
                                        Console.SetCursorPosition(16, 6);
                                        Console.Write(items[1]);
                                        break;
                                    case "Last Name":
                                        Console.SetCursorPosition(16, 7);
                                        Console.Write(items[1]);
                                        break;
                                    case "Address":
                                        Console.SetCursorPosition(16, 8);
                                        Console.Write(items[1]);
                                        break;
                                    case "Phone":
                                        Console.SetCursorPosition(16, 9);
                                        Console.Write(items[1]);
                                        break;
                                    case "Email":
                                        Console.SetCursorPosition(16, 10);
                                        Console.Write(items[1]);
                                        break;
                                }
                            }
                            sr.Close();
                            Console.SetCursorPosition(37, 12);
                            if (!yesNoLoop())
                            {
                                flag = true;
                            }
                        }
                        else
                        {
                            Console.SetCursorPosition(1, 6);
                            Console.WriteLine("Invalid account number");
                            Console.ReadKey(true);
                        }
                    }    
                }   
                else
                {
                    Console.SetCursorPosition(1,6);
                    Console.WriteLine("The input should be below 10 degit");
                    Console.ReadKey(true);
                }
            } while (flag == false);
        }
        //check if the txt file for certain account number exist in the path
        public bool isValid(int accountNo)
        {
            string accountStr = accountNo.ToString() + ".txt";
            DirectoryInfo di = new DirectoryInfo(".\\");
            try
            {
                foreach (FileInfo filename in di.GetFiles("*.txt"))
                {
                    if (filename.Name.CompareTo(accountStr) == 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool yesNoLoop()
        {
            while (true)
            {
                
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.Write("\b \b");
                if (key.KeyChar == 'Y' || key.KeyChar == 'y')
                {
                    return true;
                }
                else if (key.KeyChar == 'N' || key.KeyChar == 'n')
                {
                    return false;
                }
            }
        }
        public void deposit()
        {
            bool flag = false;
            
            int accountNum = 0;

            do
            {
                string strAccountNum;
                Console.Clear();
                Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("┃             DEPOSIT ACCOUNT            ┃");
                Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
                Console.WriteLine("┃            ENTER THE DETAILS           ┃");
                Console.WriteLine("┃                                        ┃");
                Console.WriteLine("┃  Account Number :                      ┃");
                Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Console.SetCursorPosition(19, 5);
                strAccountNum = Console.ReadLine();
                if (check10Char(strAccountNum))
                {
                    accountNum = changeUserInputToDigit(strAccountNum);
                    if (accountNum == -1)
                    {
                        Console.SetCursorPosition(1, 7);
                        Console.WriteLine("Account Number should be an integer");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        if (isValid(accountNum))
                        {
                            bool minusFlag = false;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                                Console.WriteLine("┃                DEPOSIT                 ┃");
                                Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
                                Console.WriteLine("┃            ENTER THE DETAILS           ┃");
                                Console.WriteLine("┃                                        ┃");
                                Console.WriteLine("┃  Account Number : {0}               ┃", accountNum);
                                Console.WriteLine("┃  Deposit amount : $                    ┃");
                                Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                                Console.SetCursorPosition(22, 6);
                                string strAmount = Console.ReadLine();
                                
                                double amount;
                                string line;
                                int count = 0;
                                int lineNumber = 0;
                                double currentBalance = 0;
                                string history;
                                string path = string.Format(".\\{0}.txt", accountNum);
                                StreamReader file = new StreamReader(path);

                                amount = changeMoneytoDouble(strAmount);
                                if (amount != -1)
                                {
                                    while ((line = file.ReadLine()) != null)
                                    {
                                        string[] values = line.Split('|');
                                        if (values[0].Equals("Balance"))
                                        {
                                            currentBalance = Convert.ToDouble(values[1]);
                                            lineNumber = count;
                                        }
                                        count++;
                                    }
                                    file.Close();
                                    string[] balanceEditFile = File.ReadAllLines(path);
                                    double totalAmount = currentBalance + amount;
                                    balanceEditFile[lineNumber] = "Balance|" + (totalAmount);
                                    File.WriteAllLines(path, balanceEditFile);
                                    history = DateTime.Now.ToString("dd.MM.yyyy|") + ("Deposit|") + (amount + "|") + (totalAmount);
                                    File.AppendAllText(path, history);
                                    flag = true;
                                    Console.SetCursorPosition(1, 8);
                                    Console.WriteLine("Deposit was done successfully");
                                    minusFlag = true;
                                    Console.ReadKey(true);
                                }
                                else
                                {
                                    file.Close();
                                }
                            } while (minusFlag == false);
                            
                        }
                               
                        else
                        {
                            Console.SetCursorPosition(1, 7);
                            Console.WriteLine("Invalid account number");
                            Console.ReadKey(true);
                        }
                    }

                }
                else
                {
                    Console.SetCursorPosition(1, 7);
                    Console.WriteLine("Account number should be no more then 10 char");
                    Console.ReadKey(true);
                }

            } while (flag == false);
        }

        // change user input string to number and check if user inputs are digits all
        int changeUserInputToDigit(string str)
        {
            int rv;
            try
            {
                rv = Convert.ToInt32(str);
            }
            catch
            {
                return -1;
            }
            return rv;
        }
        double changeMoneytoDouble(string str)
        {
            double rv;
            try
            {
                rv = Convert.ToDouble(str);
            }
            catch
            {
                return -1;
            }
            return rv;
        }

        public void withdrawal()
        {
            bool flag = false;

            int accountNum=0;

            do
            {
                string strAccountNum;
                Console.Clear();
                Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("┃             WITHDRAW ACCOUNT           ┃");
                Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
                Console.WriteLine("┃            ENTER THE DETAILS           ┃");
                Console.WriteLine("┃                                        ┃");
                Console.WriteLine("┃  Account Number :                      ┃");
                Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Console.SetCursorPosition(19, 5);
                strAccountNum = Console.ReadLine();
                if (check10Char(strAccountNum))
                {
                    accountNum = changeUserInputToDigit(strAccountNum);
                    if(accountNum == -1)
                    {
                        Console.SetCursorPosition(1, 7);
                        Console.WriteLine("Account Number should be an integer");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        if (isValid(accountNum))
                        {
                            bool minusFlag = false;
                            string strAmount;
                            double amount;
                            string line;
                            int count = 0;
                            int lineNumber = 0;
                            double currentBalance = 0;
                            string history;
                            string path = string.Format(".\\{0}.txt", accountNum);
                            StreamReader file = new StreamReader(path);
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                                Console.WriteLine("┃                WITHDRAW                ┃");
                                Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
                                Console.WriteLine("┃            ENTER THE DETAILS           ┃");
                                Console.WriteLine("┃                                        ┃");
                                Console.WriteLine("┃  Account Number  : {0}              ┃", accountNum);
                                Console.WriteLine("┃  Withdraw amount : $                   ┃");
                                Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                                Console.SetCursorPosition(23, 6);
                                strAmount =Console.ReadLine();
                                amount = changeMoneytoDouble(strAmount);
                                if (amount != -1)
                                {
                                    while ((line = file.ReadLine()) != null)
                                    {
                                        string[] values = line.Split('|');
                                        if (values[0].Equals("Balance"))
                                        {
                                            currentBalance = Convert.ToDouble(values[1]);
                                            lineNumber = count;
                                        }
                                        count++;
                                    }
                                    if (currentBalance < amount)
                                    {
                                        Console.SetCursorPosition(1, 8);
                                        Console.WriteLine("Withdrawing amount is bigger than balance");
                                        Console.ReadKey(true);
                                    }
                                    else
                                    {
                                        minusFlag = true;
                                    }
                                }
                                else
                                {
                                    file.Close();
                                }
                            } while (minusFlag == false);
                            file.Close();
                            string[] balanceEditFile = File.ReadAllLines(path);
                            double totalAmount = currentBalance - amount;
                            balanceEditFile[lineNumber] = "Balance|" + (totalAmount);
                            File.WriteAllLines(path, balanceEditFile);
                            history = DateTime.Now.ToString("dd.MM.yyyy|") + ("Withdraw|") + (amount + "|") + (totalAmount);
                            File.AppendAllText(path, history);
                            flag = true;
                            Console.SetCursorPosition(1, 8);
                            Console.WriteLine("Withdraw was done successfully");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            Console.SetCursorPosition(1,7);
                            Console.WriteLine("Invalid account number");
                            Console.ReadKey(true);
                        }
                    }
                }
                else
                {
                    Console.SetCursorPosition(1, 7);
                    Console.WriteLine("Account number should be no more then 10 char");
                    Console.ReadKey(true);
                }
            } while (flag == false);
        }





        public void accountStatement()
        {
            bool flag = false;
            do
            {
                Console.Clear();
                Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("┃                STATEMENT               ┃");
                Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
                Console.WriteLine("┃            ENTER THE DETAILS           ┃");
                Console.WriteLine("┃                                        ┃");
                Console.WriteLine("┃  Account Number:                       ┃");
                Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Console.SetCursorPosition(18, 5);
                string strAccountNum = Console.ReadLine();
                if (check10Char(strAccountNum))
                {
                    int accountNum = changeUserInputToDigit(strAccountNum);
                    if(accountNum != -1)
                    {
                        if (isValid(accountNum))
                        {
                            string path = string.Format(".\\{0}.txt", accountNum);
                            StreamReader sr = new StreamReader(path);
                            string line;
                            List<string> trans_hist = new List<string>();

                            Console.Clear();
                            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                            Console.WriteLine("┃          SIMPLE BANKING SYSTEM         ┃");
                            Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
                            Console.WriteLine("┃  Account Statement                     ┃");
                            Console.WriteLine("┃                                        ┃");
                            Console.WriteLine("┃  Account No :                          ┃");
                            Console.WriteLine("┃  Balance    :                          ┃");
                            Console.WriteLine("┃  First Name :                          ┃");
                            Console.WriteLine("┃  Last Name  :                          ┃");
                            Console.WriteLine("┃  Address    :                          ┃");
                            Console.WriteLine("┃  Phone      :                          ┃");
                            Console.WriteLine("┃  Email      :                          ┃");
                            Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
                            Console.WriteLine("┃     Last 5 Transaction History         ┃");
                            Console.WriteLine("┃                                        ┃");
                            Console.WriteLine("┃                                        ┃");
                            Console.WriteLine("┃                                        ┃");
                            Console.WriteLine("┃                                        ┃");
                            Console.WriteLine("┃                                        ┃");
                            Console.WriteLine("┃                                        ┃");
                            Console.WriteLine("┃                                        ┃");
                            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] items = line.Split('|');

                                switch (items[0])
                                {
                                    case "accountNo":
                                        Console.SetCursorPosition(15, 5);
                                        Console.Write(items[1]);
                                        break;
                                    case "Balance":
                                        Console.SetCursorPosition(15, 6);
                                        Console.Write(items[1]);
                                        break;
                                    case "First Name":
                                        Console.SetCursorPosition(15, 7);
                                        Console.Write(items[1]);
                                        break;
                                    case "Last Name":
                                        Console.SetCursorPosition(15, 8);
                                        Console.Write(items[1]);
                                        break;
                                    case "Address":
                                        Console.SetCursorPosition(15, 9);
                                        Console.Write(items[1]);
                                        break;
                                    case "Phone":
                                        Console.SetCursorPosition(15, 10);
                                        Console.Write(items[1]);
                                        break;
                                    case "Email":
                                        Console.SetCursorPosition(15, 11);
                                        Console.Write(items[1]);
                                        break;
                                    default:
                                        trans_hist.Add(line);
                                        break;
                                }
                            }
                            sr.Close();
                            // writing transaction history
                            for (int i = 0; i < 5; i++)
                            {
                                string str_hist = getTransHist(trans_hist, i);
                                Console.SetCursorPosition(3, 15 + i);
                                Console.Write(str_hist);
                            }
                            Console.SetCursorPosition(1, 23);
                            Console.WriteLine("Email statement (Y/N)");
                            if (yesNoLoop() == true)
                            {
                                sendAccountStatement(accountNum);
                                Console.SetCursorPosition(1, 23);
                                Console.WriteLine("Email sent successfully");
                                Console.ReadKey(true);
                                flag = true;
                            }
                            else
                            {
                                flag = true;
                            }

                        }
                        else
                        {
                            Console.SetCursorPosition(1, 7);
                            Console.WriteLine("Invalid account number");
                            Console.ReadKey(true);
                        }
                    }                                        
                }
                else
                {
                    Console.SetCursorPosition(1,7);
                    Console.WriteLine("The account number should not exceed 10 character");
                    Console.ReadKey(true);
                }
            } while (flag == false);
        }
        // get last 5 transaction history string
        private string getTransHist(List<string> hist, int count)
        {
            if(hist.Count < 5)
            {
                if (count < hist.Count)
                {
                    return hist[count];
                }
                else return "";
            }
            else 
            {
                return hist[hist.Count - 5 + count];
            }
        }

        private void sendAccountStatement(int accountNum)
        {
            string path = string.Format(".\\{0}.txt", accountNum);
            StreamReader sr = new StreamReader(path);
            List<string> emailText = new List<string>();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                emailText.Add(line);
            }
            if (emailText.Count < 8)
            {
                sr.Close();
                return;
            }
                
            string email_address = emailText[4].Split('|')[1];
            string firstName = emailText[0].Split('|')[1];
            string lastName = emailText[1].Split('|')[1];
            string address = emailText[2].Split('|')[1];
            string phone = emailText[3].Split('|')[1];
            string[] hist = new string[5];

            if (emailText.Count > 13)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (emailText.Count >= i + 8) hist[i] = emailText[8 + i];
                    else hist[i] = "";
                }
            }
            else
            {
                for(int i=0;i<5; i++)
                {
                    hist[i] = emailText[emailText.Count - 5 + i];
                }
            }

            string body = string.Format("<html><body>First Name: {0}<br>Last Name: {1}<br>Address: {2}<br>Phone number: {3}<br> Email: {4}<br>accountNumber: {5}<br>{6}<br>{7}<br>{8}<br>{9}<br>{10}<br></body></html> ",
                        firstName, lastName, address, phone, email_address, accountNum, hist[0], hist[1], hist[2], hist[3], hist[4]);
            sendEMail(email_address, body);
            sr.Close();

        }
        private bool sendEMail(string address, string body)
        {
            MailMessage mail = new MailMessage();
            try
            {
                mail.From = new MailAddress("MinsooJoh@uts.edu.au", "Minsoo Joh",
                    System.Text.Encoding.UTF8);
                mail.To.Add(address);
                mail.Subject = ("Account details");
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.BodyEncoding = System.Text.Encoding.UTF8;

                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Credentials = new System.Net.NetworkCredential("13659901uts@gmail.com", "13651365");
                SmtpServer.Send(mail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public void delete()
        {
            bool flag = false;
            string strAccountNum;
            
            do
            {
                Console.Clear();
                Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("┃           DELETE AN ACCOUNT            ┃");
                Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
                Console.WriteLine("┃           ENTER THE DETAILS            ┃");
                Console.WriteLine("┃                                        ┃");
                Console.WriteLine("┃  Account Number:                       ┃");
                Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Console.SetCursorPosition(18, 5);
                strAccountNum = Console.ReadLine();
                if (strAccountNum.Length <= 10)
                {
                    int accountNum = changeUserInputToDigit(strAccountNum);
                    if(accountNum != -1)
                    {
                        if (isValid(accountNum))
                        {
                            string path = string.Format(".\\{0}.txt", accountNum);
                            StreamReader sr = new StreamReader(path);
                            string line;
                            Console.Clear();
                            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                            Console.WriteLine("┃           ACCOUNT DETAILS              ┃");
                            Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
                            Console.WriteLine("┃                                        ┃");
                            Console.WriteLine("┃  Account No  :                         ┃");
                            Console.WriteLine("┃  Balance     :                         ┃");
                            Console.WriteLine("┃  First Name  :                         ┃");
                            Console.WriteLine("┃  Last Name   :                         ┃");
                            Console.WriteLine("┃  Address     :                         ┃");
                            Console.WriteLine("┃  Phone       :                         ┃");
                            Console.WriteLine("┃  Email       :                         ┃");
                            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                            while ((line = sr.ReadLine()) != null)
                            {

                                string[] items = line.Split('|');

                                switch (items[0])
                                {
                                    case "accountNo":
                                        Console.SetCursorPosition(16, 4);
                                        Console.Write(items[1]);
                                        break;
                                    case "Balance":
                                        Console.SetCursorPosition(16, 5);
                                        Console.Write(items[1]);
                                        break;
                                    case "First Name":
                                        Console.SetCursorPosition(16, 6);
                                        Console.Write(items[1]);
                                        break;
                                    case "Last Name":
                                        Console.SetCursorPosition(16, 7);
                                        Console.Write(items[1]);
                                        break;
                                    case "Address":
                                        Console.SetCursorPosition(16, 8);
                                        Console.Write(items[1]);
                                        break;
                                    case "Phone":
                                        Console.SetCursorPosition(16, 9);
                                        Console.Write(items[1]);
                                        break;
                                    case "Email":
                                        Console.SetCursorPosition(16, 10);
                                        Console.Write(items[1]);
                                        break;
                                }
                            }
                            sr.Close();
                            Console.SetCursorPosition(1, 12);
                            Console.WriteLine("Would you delete this account? (Y/N)");
                            if (yesNoLoop())
                            {
                                File.Delete(path);
                                Console.SetCursorPosition(1, 12);
                                Console.WriteLine("File successfully deleted            ");
                                Console.ReadKey();
                                flag = true;
                            }
                            else
                            {
                                flag = true;
                            }
                        }
                        else
                        {
                            Console.SetCursorPosition(1, 7);
                            Console.WriteLine("Invalid account number");
                            Console.ReadKey(true);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(1, 7);
                        Console.WriteLine("Account Number should be an integer");
                        Console.ReadKey(true);
                    }
                }
                else
                {
                    Console.SetCursorPosition(1, 7);
                    Console.WriteLine("The character can not exceed 10 character");
                    Console.ReadKey(true);
                }
            }while(flag == false) ;      
        }
        //check if the input does not exceed 10 character
        public bool check10Char(string accountNumstr)
        {
            if (accountNumstr.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
