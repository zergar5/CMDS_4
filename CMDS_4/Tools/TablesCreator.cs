using System.Globalization;
using System.Text;

namespace CMDS_4.Tools
{
    static public class TablesCreator
    {

        private readonly static CultureInfo _culture = CultureInfo.CreateSpecificCulture("en-US");

        static public void Create(int n, double h, List<double> yC, List<double> yA, FileStream fileStream)
        {
            using (var streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine("t y_числен y_аналит |y_числен-y_аналит|");
                for (int i = 0; i <= n; i++)
                {
                    var stringBulder = new StringBuilder((h * i).ToString("0.000", _culture));
                    stringBulder.Append(" ");
                    stringBulder.Append(yC[i].ToString("0.00e+00", _culture));
                    stringBulder.Append(" ");
                    stringBulder.Append(yA[i].ToString("0.00e+00", _culture));
                    stringBulder.Append(" ");
                    stringBulder.Append(Math.Abs(yC[i] - yA[i]).ToString("0.00e+00", _culture));
                    streamWriter.WriteLine(stringBulder.ToString());
                }
            }
        }
    }
}
