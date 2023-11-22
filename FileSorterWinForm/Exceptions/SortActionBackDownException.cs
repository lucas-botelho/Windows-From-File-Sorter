using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Exceptions
{
    public class SortActionBackDownException : Exception
    {
        public SortActionBackDownException()
        {
        }

        public SortActionBackDownException(string message) : base(message)
        {
        }

        public SortActionBackDownException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
