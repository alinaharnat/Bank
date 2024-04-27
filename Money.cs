using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Money
    {
        private int hryvnias;
        private int kopiyky;
        public Money(int hryvnias, int kopiyky)
        {
            if (hryvnias < 0 || kopiyky < 0 || kopiyky >= 100)
            {
                throw new ArgumentException("Entered data is wrong");
            }
            this.hryvnias = hryvnias;
            this.kopiyky = kopiyky;
        }

        public static Money operator +(Money money1, Money money2)
        {
            var hrn = money1.hryvnias + money2.hryvnias;
            var kop = money1.kopiyky + money2.kopiyky;
            while (kop - 100 >= 0)
            {
                hrn++;
                kop -= 100;
            }
            return new Money(hrn, kop);
        }

        public static Money operator -(Money money1, Money money2)
        {
            var hrn = money1.hryvnias - money2.hryvnias;
            var kop = 0;
            if (money1.kopiyky < money2.kopiyky)
            {
                kop = money1.kopiyky + 100 - money2.kopiyky;
                hrn--;
            }
            else
            {
                kop = money1.kopiyky - money2.kopiyky;
            }
            return new Money(hrn, kop);
        }

        public static bool operator >(Money money1, Money money2)
        {
            if (money1.hryvnias > money2.hryvnias)
            { return true; }
            else if (money1.hryvnias == money2.kopiyky && money1.kopiyky > money2.kopiyky)
            {
                return true;
            }

            return false;
        }

        public static bool operator <(Money money1, Money money2)
        {
            if (money1.hryvnias < money2.hryvnias)
            {
                return true;
            }
            else if (money1.hryvnias == money2.hryvnias && money1.kopiyky < money2.kopiyky)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{hryvnias}.{kopiyky}";
        }
        public static bool operator >=(Money money1, Money money2)
        {
            return money1 > money2 || money1 == money2;
        }

        public static bool operator <=(Money money1, Money money2)
        {
            return money1 < money2 || money1 == money2;
        }
    }
}
