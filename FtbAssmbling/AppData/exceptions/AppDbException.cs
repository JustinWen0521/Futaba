using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.exceptions
{
    public class AppDbException : Exception
    {
        public AppDbException()
        {
        }

        public AppDbException(string result, string message)
        {
            this.Result = result;
            this.Message = message;
        }

        public string Result { get; set; }
        public new string Message { get; set; }
    }
}
