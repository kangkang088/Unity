namespace _12_ternary_operator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string s = "1";

            s = s == "1" ? "2" : "3";

            Console.WriteLine(s);
        }
    }
}