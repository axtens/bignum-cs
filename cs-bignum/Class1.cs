using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace cs_bignum
{
    public class BignumLib
    {
        private int MAXDIGITS = 100;
        private const int PLUS = 1;
        private const int MINUS = -1;
    
        public BignumLib()
        {
            return;
        }
    }

    public class Bignum
    {
        private const int PLUS = 1;
        private const int MINUS = -1;

        public char[] digits = null;
        public int signbit = 1;
        public int lastdigit = -1;

        private const int MAXDIGITS = 100;

        public Bignum()
        {
            digits = new char[MAXDIGITS];
            return;
        }

        public Bignum(int n)
        {
            this.digits = new char[MAXDIGITS];

            this.signbit = (n >= 0) ? PLUS : MINUS;
            this.lastdigit = -1;
            int t = Math.Abs(n);
            while (t > 0)
            {
                this.lastdigit++;
                this.digits[this.lastdigit] = (char)(t % 10);
                t = t / 10;
            }
            if (n == 0)
            {
                this.lastdigit = 0;
            }
            return;
        }
    
        public Bignum(string initial)
        {
            this.digits = new char[MAXDIGITS];
            this.lastdigit = -1;
            if (initial.Substring(0,1) == "-")
            {
                this.signbit = MINUS;
                initial = initial.Substring(1);
            }
            else
            {
                this.signbit = PLUS;
            }
            if (initial.Length == 0)
            {
                return;
            }

            for (var i = initial.Length - 1; i >= 0; i--)
            {
                this.lastdigit++;
                this.digits[this.lastdigit] = initial.ToCharArray(i, 1)[0];
            }
            return;
        }

        public Bignum(int n, int maxdigits)
        {
            this.digits = new char[maxdigits];

            this.signbit = (n >= 0) ? PLUS : MINUS;
            this.lastdigit = -1;
            int t = Math.Abs(n);
            while (t > 0)
            {
                this.lastdigit++;
                this.digits[this.lastdigit] = (char)(t % 10);
                t = t / 10;
            }
            if (n == 0)
            {
                this.lastdigit = 0;
            }
            return;
        }

        public Bignum(string initial, int maxdigits)
        {
            this.digits = new char[maxdigits];
            this.lastdigit = -1;
            if (initial.Substring(0, 1) == "-")
            {
                this.signbit = MINUS;
                initial = initial.Substring(1);
            }
            else
            {
                this.signbit = PLUS;
            }
            if (initial.Length == 0)
            {
                return;
            }

            for (var i = initial.Length - 1; i >= 0; i--)
            {
                this.lastdigit++;
                this.digits[this.lastdigit] = initial.ToCharArray(i, 1)[0];
            }
            return;
        }
        public string toString()
        {
            ArrayList b = new ArrayList(this.digits);
            b = b.GetRange(0, this.lastdigit + 1);
            b.Reverse();
            return (this.signbit == MINUS ? "-" : "") + b.ToString();
        }
    }
}

