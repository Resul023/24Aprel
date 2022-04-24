using System;
using System.Collections.Generic;
using System.Text;

namespace _24Aprel.Services
{
    public class PriceIsNotTrue:Exception
    {
        public PriceIsNotTrue(string message):base(message)
        {

        }
    }
}
