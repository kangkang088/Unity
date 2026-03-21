namespace _04_escape_character
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string str = "\"\t你\n好\"";

            Console.WriteLine(str);

            str = "123\b123";

            Console.WriteLine(str);

            str = "123\0123";

            Console.WriteLine(str);

            str = "\a";

            Console.WriteLine(str);
        }
    }
}