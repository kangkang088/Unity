namespace _02_variable
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int id = 1;

            sbyte sb = 1;

            short s = 3;

            long l = 5;

            byte b = 5;
            uint ui = 5;
            ushort us = 5;
            ulong ul = 6;

            float f = 0.123456789f; // 7/8 位有效数字

            Console.WriteLine(f);

            double d = 5.1278; // 15~17位有效数字

            decimal dc = 659745.4545m; // 27~28

            bool bl = true;
            char c = 'a';
            string str = "dasde";
        }
    }
}