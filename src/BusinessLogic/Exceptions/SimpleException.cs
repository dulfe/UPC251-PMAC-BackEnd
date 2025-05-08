using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSystem.BusinessLogic.Exceptions
{
    public class SimpleException:Exception
    {
        public SimpleException(int code, string message) : base(message)
        {
            Code = code;
        }
        public int Code { get; }
    }
}
