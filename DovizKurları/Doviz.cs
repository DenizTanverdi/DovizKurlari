using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DovizKurları
{
    class Doviz
    {
        private string currencycode;

        public string CurrencyCode
        {
            get { return currencycode; }
            set { currencycode = value; }
        }
        private string currencyname;

        public string CurrencyName
        {
            get { return currencyname; }
            set { currencyname = value; }
        }

        private decimal forexbuying;

        public decimal ForexBuying
        {
            get { return forexbuying; }
            set { forexbuying = value; }
        }

        private decimal forexselling;

        public decimal ForexSelling
        {
            get { return forexselling; }
            set { forexselling = value; }
        }
        public override string ToString()
        {
            return CurrencyName;
        }

    }
}
