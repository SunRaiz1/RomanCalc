﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersCalculator.Models
{
    public class RomanNumber : ICloneable, IComparable
    {

        private ushort value;
        private string romanVal;

        private string calcRomanValue(ushort n)
        {
            char[] symbol = new char[] { 'M', 'D', 'C', 'L', 'X', 'V' };
            char[] symbol_2 = new char[] { 'C', 'X', 'I' };
            string r = "";
            for (int i = 0; i < n / 1000; ++i) r += 'M';
            int p = n % 1000;
            for (int i = 100, k = 0; i > 0; i /= 10, ++k)
            {
                int x = p / i;
                if (x == 9) r = r + symbol_2[k] + symbol[k * 2];
                else if (x >= 5)
                {
                    r += symbol[1 + k * 2];
                    for (int j = 0; j < x - 5; ++j) r += symbol_2[k];
                }
                else
                {
                    if (x == 4) r = r + symbol_2[k] + symbol[1 + k * 2];
                    else
                    {
                        for (int j = 0; j < x; ++j) r += symbol_2[k];
                    }
                }
                p = p % i;
            }
            return r;
        }

        
        public RomanNumber(ushort n)
        {
            if (!(n > 0)) throw new RomanNumberException();
            value = n;
            romanVal = calcRomanValue(n);
        }

        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new ArgumentNullException();
            return new RomanNumber((ushort)(n1.value + n2.value));
        }

        
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new ArgumentNullException();
            if (n1.value <= n2.value) throw new RomanNumberException();
            return new RomanNumber((ushort)(n1.value - n2.value));
        }
        
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new ArgumentNullException();
            return new RomanNumber((ushort)(n1.value * n2.value));
        }
        
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null) throw new ArgumentNullException();
            if (n2.value == 0 || ((ushort)(n1.value / n2.value)) == 0) throw new RomanNumberException();
            return new RomanNumber((ushort)(n1.value / n2.value));
        }

        public override string ToString()
        {
            return romanVal;
        }

        public object Clone()
        {
            return new RomanNumber(value);
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            RomanNumber another = obj as RomanNumber;

            if (another == null) throw new ArgumentException("Object is not a RomanNumber.");

            return value.CompareTo(another.value);
        }
    }
}
