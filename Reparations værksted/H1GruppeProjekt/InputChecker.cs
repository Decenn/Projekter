using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1GruppeProjekt
{
    public static class InputChecker
    {
        public static bool NameChecker(this string userInput)
        {
            string correctCharacters = "qwertyuiopasdfghjklzxcvbnmåæø";
            foreach (char c in userInput)
                if (!correctCharacters.Contains(c))
                    return false;
            return true;
        }

        #region Obsolete functions
        public static bool NumberChecker(this int userinput)
        {
            string correctCharacters = "1234567890";
            foreach (char c in userinput.ToString())
            {
                if (!correctCharacters.Contains(c))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userinput"></param>
        /// <returns></returns>
        public static bool NumberChecker(this decimal userinput)
        {
            string correctCharacters = "1234567890.";
            foreach (char c in userinput.ToString())
            {
                if (!correctCharacters.Contains(c))
                    return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// Used for string checking when constructing an object
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static string NameChecker(int X, int Y)
        {
            while (true)
            {
                Console.SetCursorPosition(X, Y);
                string s = Console.ReadLine();
                if(s.NameChecker())
                    return s;

                Console.SetCursorPosition(X, Y);
                Console.Write("Forkert input...Du skal kun bruge bogstaver.");
                System.Threading.Thread.Sleep(2000);
                Console.SetCursorPosition(X, Y);
                Console.Write("                                               ");


            }
        }

        /// <summary>
        /// Checks if the input is an interger value
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static int IntInputChecker(int X, int Y)
        {
            while (true)
            {
                try
                {
                    Console.SetCursorPosition(X, Y);
                    int i = Convert.ToInt32(Console.ReadLine());
                    return i;
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write("Forkert input...Du skal indtaste et tal");
                    System.Threading.Thread.Sleep(2000);
                    Console.SetCursorPosition(X, Y);
                    Console.Write("                                               ");

                }
            }


        }

        /// <summary>
        /// Checks if the input is a decimal value
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static int DecimalInputChecker(int X, int Y)
        {
            while (true)
            {
                try
                {
                    Console.SetCursorPosition(X, Y);
                    int i = Convert.ToInt32(Console.ReadLine());
                    return i;
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write("Forkert input...Du skal indtaste et tal");
                    System.Threading.Thread.Sleep(2000);
                    Console.SetCursorPosition(X, Y);
                    Console.Write("                                               ");

                }
            }


        }
    }
}
