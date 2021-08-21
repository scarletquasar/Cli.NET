using System;
using CLIdotNET.Controllers;

namespace CLIdotNET
{
    class Program
    {
        static void Main(string[] args = null)
        {
            // If there's no arguments, the program will read the user input
            if (args.Length < 1) {
                var com = Console.ReadLine();
                CommandController.Execute(com.Split(" "));
                Main(new string[]{});
            }
            // If there's arguments, the commands will be executed
            else {
                CommandController.Execute(args);
                Main(new string[]{});
            }
        }
    }
}
