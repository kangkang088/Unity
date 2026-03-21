namespace _08_string_concatenation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string s = "123";
            s = s + 1;
            Console.WriteLine(s);

            string s2 = string.Format("你是{0}，你今年{1}岁，你的性别是{2}","LiMing",15,"Male");
            Console.WriteLine(s2);

            Console.WriteLine("你是{0}，今年{1}岁","SunLi",15);
        }
    }
}