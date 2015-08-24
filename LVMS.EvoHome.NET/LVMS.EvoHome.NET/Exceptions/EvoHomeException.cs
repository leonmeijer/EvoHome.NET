using System;

namespace LVMS.EvoHome.Exceptions
{
    public class EvoHomeException : Exception
    {
        public EvoHomeException()
        {

        }

        public EvoHomeException(string message ) : base(message)
        {

        }

        public EvoHomeException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
