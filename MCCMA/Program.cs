using System;

namespace MCCMA
{
    class MainClass
    {
        public static Login profile = new Login();
        public static MainMenu mymenu = new MainMenu();

        public static void Main(string[] args)
        {
            ///Header
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("| MCCMA - Multiple Credit Card Management Application |");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("|*         Default account for first time login      *|");
            Console.WriteLine("|*                  Username: temp                   *|");
            Console.WriteLine("|*                Password: password                 *|");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("");

            ///Login
            profile.FirstLogin();
            ///Menu that can access to all functions/features
            mymenu.Menu();
        }

    }
}
