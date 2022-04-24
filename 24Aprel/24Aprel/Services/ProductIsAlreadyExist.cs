using System;
using System.Collections.Generic;
using System.Text;

namespace _24Aprel.Services
{
    public class ProductIsAlreadyExist:Exception
    {
        public ProductIsAlreadyExist(string message):base(message)
        {

        }
    }
}
