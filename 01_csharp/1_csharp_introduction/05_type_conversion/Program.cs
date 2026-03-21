namespace _05_type_conversion
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            #region 隐式转换

            int i = 0;
            ushort s = 1;

            i = s;

            short s1 = 2;
            int i1 = 0;
            //s1 = i1;

            char c = 'c'; // 无符号
            Console.WriteLine(sizeof(char));
            Console.WriteLine(sizeof(short));
            Console.WriteLine(sizeof(ushort));
            long l = 2;
            ulong l1 = 2;
            //s1 = c;
            s = c;
            l = c;
            l1 = c;
            i = c;
            uint i11 = c;

            #endregion 隐式转换

            #region 显示转换

            short so1 = 4;
            int io1 = 0;
            so1 = (short)io1;

            //int io2 = int.Parse("123a");
            int io2 = int.Parse("123");

            //int io3 = Convert.ToInt32("123a");
            int io3 = Convert.ToInt32("123");

            int io4 = Convert.ToInt32(1.76);

            Console.WriteLine(io4);

            string str1 = io4.ToString();

            Console.WriteLine(str1);

            #endregion 显示转换
        }
    }
}