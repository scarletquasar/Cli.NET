using System;
using CLIdotNET.Controllers;

namespace CLIdotNET
{
    class Program
    {
        static void Main(string[] args = null)
        {
            if (args.Length < 1) {
                var com = Console.ReadLine();
                CommandController.Execute(com.Split(" "));
                Main(new string[]{});
            }
            else {
                Console.Write(args[0]);
            }
        }
    }
}
