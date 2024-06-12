using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Game
{
    internal class Program
    {
        static string NameOfThePlayer;
        static void Main()
        {
            GetPlayerName();
            Console.WriteLine($"Greetings {NameOfThePlayer} \nA warm welcome to the Trivia Quiz Game!");
            Console.ReadLine();
            Console.WriteLine("There are two Categories in this game \n1. Science  \n2. History");
            Console.ReadLine();
        }
        static void GetPlayerName()
        {
            Console.Write("Enter your name: ");
            NameOfThePlayer = Console.ReadLine();
        }
    }
}
