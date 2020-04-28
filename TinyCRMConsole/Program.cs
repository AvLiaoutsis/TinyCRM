using System;

namespace TinyCRMConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var aLiaoutsis = new Customer("123124125");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
