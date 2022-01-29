using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gozen.Domain.Exceptions
{
    public class UniqueIdAlreadyTakenException : Exception
    {
        public UniqueIdAlreadyTakenException()
        {
        }

        public UniqueIdAlreadyTakenException(string message) : base(message)
        {
        }

        public UniqueIdAlreadyTakenException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
