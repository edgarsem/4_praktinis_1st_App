using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _4_praktinis_1st_App
{
    internal class CrptEngine
    {

        public static BigInteger PQPrimeSet(BigInteger val)
        {
            while(IsPrime(val) == false)
            {
                val = BigInteger.Add(val, 1);
            }
            return val;
        }

        public static String keyGen()
        {

            BigInteger p = PQPrimeSet(new Random().Next(100, 1000));
            BigInteger q = PQPrimeSet(new Random().Next(100, 1000));

            //System.Windows.Forms.MessageBox.Show("P = " + p);
            //System.Windows.Forms.MessageBox.Show("Q = " + q);

            return keyFind(p, q);
        }


        public static bool CheckStringFormat(string input)
        {
            string[] splitInput = input.Split(',');
            if (splitInput.Length != 2)
            {
                return false;
            }
            bool isNumber1 = int.TryParse(splitInput[0], out int number1);
            bool isNumber2 = int.TryParse(splitInput[1], out int number2);
            return isNumber1 && isNumber2;
        }


        public static bool IsPrime(BigInteger n)
        {
            if (n <= 1)
            {
                return false;
            }
            if (n == 2)
            {
                return true;
            }
            if (n % 2 == 0)
            {
                return false;
            }
            for (BigInteger i = 3; i <= Sqrt(n); i += 2)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static BigInteger Sqrt(BigInteger n)
        {
            BigInteger root = 0;
            BigInteger bit = 1 << 30;
            while (bit > n)
            {
                bit >>= 2;
            }
            while (bit != 0)
            {
                if (n >= root + bit)
                {
                    n -= root + bit;
                    root += bit << 1;
                }
                root >>= 1;
                bit >>= 2;
            }
            return root;
        }


        private static BigInteger extendedGCD(BigInteger a, BigInteger b, BigInteger[] s, BigInteger[] t)
        {

            if (a == 0)
            {
                s[0] = 0;
                t[0] = 1;
                return b;
            }

            BigInteger[] s1 = new BigInteger[1], t1 = new BigInteger[1];
            BigInteger gcd = extendedGCD(b % a, a, s1, t1);

            s[0] = BigInteger.Subtract(t1[0], BigInteger.Multiply(BigInteger.Divide(b, a), s1[0]));
            t[0] = s1[0];

            return gcd;
        }

        public static String signingEngine(String text, BigInteger d, BigInteger n)
        {
            string encryptedText = "";
            for (int i = 0; i < text.Length; i++)
            {
                BigInteger num = BigInteger.ModPow((int)text[i], d, n);
                encryptedText += num.ToString() + " ";
            }
            return encryptedText.Trim();
        }

        public static String keyFind(BigInteger p, BigInteger q)
        {
            BigInteger n = BigInteger.Multiply(p, q);
            BigInteger phi = BigInteger.Multiply(BigInteger.Subtract(p, 1), BigInteger.Subtract(q, 1));

            BigInteger e = new Random().Next((int)phi);

            BigInteger[] x = new BigInteger[1], y = new BigInteger[1];

            BigInteger res = extendedGCD(e, phi, x, y);

            while (e < phi)
            {
                if (res == 1)
                    break;
                else
                    e = BigInteger.Add(e, 1);
                if(e == phi)
                    e = new Random().Next((int)phi);
                res = extendedGCD(e, phi, x, y);
            }

            BigInteger d = x[0];

            while (d <= 0 || d == e)
                d = BigInteger.Add(d, phi);

            return e.ToString() + ", " + n.ToString() + '|' + d.ToString() + ", " + n.ToString();
        }


    }
}
