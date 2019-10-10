using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqCustomType
{
    public class Bank
    {
        public string Ticker { get; set; }
        public int NumMillionaires { get; set; }

        public Bank(string ticker, int millionaires)
        {
            Ticker = ticker;
            NumMillionaires = millionaires;
        }
    }
}