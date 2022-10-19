using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.Exceptions
{
    public class RecordDuplicatedException : Exception
    {
        public RecordDuplicatedException(string message) : base(message)
        {
        }
    }
}
