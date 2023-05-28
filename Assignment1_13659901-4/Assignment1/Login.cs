using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Login
    {
        public void loginMenu()
        {
            if (check())
            {
                bool flag = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                    Console.WriteLine("┃    WELCOME TO SIMPLE BANKING SYSTEM    ┃");
                    Console.WriteLine("┃━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┃");
                    Console.WriteLine("┃            Login to start              ┃");
                    Console.WriteLine("┃                                        ┃");
                    Console.WriteLine("┃ User Name:                             ┃");
                    Console.WriteLine("┃ Password :                             ┃");
                    Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                    Console.SetCursorPosition(13, 5);
                    string userName = Console.ReadLine();
                    Console.SetCursorPosition(13, 6);
                    string password = readPassword();

                    if (checkID(userName, password))
                    {
                        //flag = false;
                        Console.SetCursorPosition(1, 8);
                        Console.WriteLine("Login Complete!, Press any key to continue");
                        Console.ReadKey();
                        Menu M = new Menu();
                        M.mainMenu();
                    }
                    else
                    {
                        Console.SetCursorPosition(1, 8);
                        Console.WriteLine("Check your ID or password");
                        Console.ReadKey();
                    }

                } while (flag);
            }
        }
        public bool checkID(string username, string password)
        {

            string[] lines = System.IO.File.ReadAllLines(".\\login.txt");
            foreach (string set in lines)
            {
                string[] splits = set.Split('|');
                if (username == splits[0])
                {
                    if (password == splits[1])
                        return true;
                }
            }
            return false;
        }
    
        //read each password as '*'
        public string readPassword()
        {
            string pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b"); 
                    pass = pass.Substring(0, pass.Length - 1);
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return pass;
        }
        public bool check() //Field Check whether each username is unique
        {
            string[] lines;
            try
            {
                lines = System.IO.File.ReadAllLines(".\\login.txt");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadKey();
                return false;
            }

            if (lines.Length <= 1) // Nothing written in the txt file lines.Length is 1
            {
                Console.Write("There is 0 data in the database");
                Console.ReadKey();
                return false;

            }

            string[] id = new string[lines.Length];
            int index = 0;
            foreach (string set in lines)
            {
                string[] splits = set.Split('|');
                id[index++] = splits[0];
            }
            for (int i = 0; i < lines.Length - 1; i++)
            {
                string refName = id[i];
                for (int j = i + 1; j < lines.Length; j++)
                {
                    string compareName = id[j];
                    if (refName == compareName)
                    {
                        Console.Write("Error, there is duplicate user name in the Login.txt data");
                        Console.ReadKey();
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
