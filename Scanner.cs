using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_III_2020_2_sesion_1
{
    public static class Scanner
    {
        static public byte NextByte()
        {
            byte x = Convert.ToByte(Console.ReadLine());
            return x;
        }

        static public short NextShort()
        {
            short x = Convert.ToInt16(Console.ReadLine());
            return x;
        }

        static public int NextInt()
        {
            int x = Convert.ToInt32(Console.ReadLine());
            return x;
        }

        static public long NextLong()
        {
            long x = Convert.ToInt64(Console.ReadLine());
            return x;
        }

        static public float NextFloat()
        {
            float x = Convert.ToSingle(Console.ReadLine());
            return x;
        }

        static public double NextDouble()
        {
            double x = Convert.ToDouble(Console.ReadLine());
            return x;
        }

        static public string NextLine()
        {
           return Console.ReadLine();            
        }

        static private int FindIndex(string x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == ' ')
                {
                    return i;
                }
            }

            return -1;
        }


        static public string Next()
        {
            string k = Console.ReadLine().Trim();

            k =  (FindIndex(k) > 0)? k.Substring(0, FindIndex(k) + 1): k;

            return k;
        }

    }
}
