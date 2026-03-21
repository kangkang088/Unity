namespace _06_exception_handing
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            try
            {
                string str1 = Console.ReadLine();

                int i = int.Parse(str1);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("一定会执行的部分");
            }
        }
    }
}