using System;
using System.Collections.Generic;
using System.Text;

namespace _24Aprel.Services
{
    public class CountIsNotTrue:Exception
    {
        public CountIsNotTrue(string message):base(message)
        {

        }
    }
}
