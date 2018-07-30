using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace KataLCDNumbers
{
    class Program
    {
        private static  string _NONE = "   ";
	    private static string _LEFT = "  |";
	   private static string _MIDL = " _ ";
	   private static string _MDLT = " _|";
	   private static string _MDRT = "|_ ";
	   private static string _FULL = "|_|";
	   private static string _BOTH = "| |";
        private static Dictionary<int, string[]> _SEGMENTS_FOR = new Dictionary<int, string[]>() {
            { 0, new string[] { _MIDL, _BOTH, _FULL } },
            { 1,new string[] { _NONE, _LEFT, _LEFT } },
            {2, new string[] { _MIDL, _MDLT, _MDRT } },
            {3,new string[] { _MIDL, _MDLT, _MDLT } },
            { 4, new string[] { _NONE, _FULL, _LEFT } },
            { 5, new string[] { _MIDL, _MDRT, _MDLT } },

            { 6, new string[] { _MIDL, _MDRT, _FULL }},
            { 7, new string[] { _MIDL, _LEFT, _LEFT } },
            { 8, new string[] { _MIDL, _FULL, _FULL } },
            { 9, new string[] { _MIDL, _FULL, _MDLT } },
            
	};
        public static string ToLCD(int number)
        {
            string[][] segments = getSegmentsForEachDigit(number);
            string[] result = Utils.arrangeHorizontally(segments);
            return toTextLines(result);
        }
        private static string toTextLines(string[] result)
        {
            return Utils.join(result, '\n');
        }

        private static string[][] getSegmentsForEachDigit(int number)
        {
            string digits = number.ToString();
            string[][] result = new string[digits.Length][];
            for (int digitIndex = 0; digitIndex < digits.Length; digitIndex++)
            {
                int n = digitAt(digits, digitIndex);
                result[digitIndex] = segmentsFor(n);
            }
            return result;
        }

        private static int digitAt(string digits, int i)
        {


            return Convert.ToInt32(digits.ElementAt(i).ToString()) ;
            
        }

        private static string[] segmentsFor(int number)
        {
            string[] result = _SEGMENTS_FOR.Values.ElementAt(number);
            if (null == result)
                throw new Exception (string.Format("enter degit",
                        number));
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter number ");
            int no = (int)Convert.ToInt32(Console.ReadLine());
            string result =  ToLCD(no);
            Console.WriteLine(result);
            Console.Read();
        }
    }
    class Utils
    {
        public static string join(string[] strings, char delim)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var s in strings)
            {
                if (sb.Length > 0)
                    sb.Append(delim);
                sb.Append(s);
            }
            return sb.ToString();
        }

        public static string[] arrangeHorizontally(string[][] data)
        {
            Debug.Assert(data.Length != 0);

            string[] result = (string[])data[0].Clone();
            for (int row = 1; row < data.Length; row++)
            {
                for (int col = 0; col < data[row].Length; col++)
                    result[col] += data[row][col];
            }
            return result;

        }


    }
}
