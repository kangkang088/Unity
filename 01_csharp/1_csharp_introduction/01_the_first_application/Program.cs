namespace _01_the_first_application
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.Write("你好");
            Console.WriteLine("Hello");
            Console.Write("你好");

            if(Console.ReadLine() == "c")
            {
                Console.WriteLine("c");
            }

            Console.ReadKey();
        }
    }
}