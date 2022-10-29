using System.Globalization;

namespace CMDS_4.Tools
{
    public static class Reader
    {
        public static void Read(ref int start, ref int end, ref double h)
        {
            var numbers = Console.ReadLine().Replace(".", ",").Split(' ');
            start = Convert.ToInt32(numbers[0]);
            end = Convert.ToInt32(numbers[1]);
            h = Convert.ToDouble(numbers[2]);
        }
    }
}
