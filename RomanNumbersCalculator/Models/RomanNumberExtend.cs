using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersCalculator.Models
{
    public class RomanNumberExtend : RomanNumber
    {

        static private ushort getNumber(string st)
        {
            if (st == null) throw new ArgumentNullException();
            ushort r = 0;
            char[] symbol = new char[] { 'M', 'D', 'C', 'L', 'X', 'V', 'I', ' ' };
            char[] symbol_2 = new char[] { 'C', 'X', 'I' };
            int index = 6;

            for (int i = st.Length - 1; i >= 0; --i)
            {
                char text = st[i];

                if (text == 'I')
                {
                    if (index < 6) r -= 1;
                    else r += 1;
                }
                if (text == 'V') { 
                    r += 5; 
                    index = 5; }

                if (text == 'X')
                {
                    if (index < 4) r -= 10;
                    else r += 10;
                    index = 4;
                }

                if (text == 'L') { 
                    r += 50; 
                    index = 3; }
                
                if (text == 'C')
                {
                    if (index < 2) r -= 100;
                    else r += 100;
                    index = 2;
                }

                if (text == 'D') { 
                    r += 500; 
                    index = 1; }

                if (text == 'M') { 
                    r += 1000; 
                    index = 0; }
            }

            return r;
        }
        public RomanNumberExtend(ushort n) : base(n) { }

        public RomanNumberExtend(string str) : base(getNumber(str))
        {
        }
    }
}
