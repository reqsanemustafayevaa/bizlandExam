using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.business.Exceptions
{
    public class InvalidCreadExceptions:Exception
    {
        public string PropertyName { get; set; }
        public InvalidCreadExceptions()
        {

        }
        public InvalidCreadExceptions(string? message) : base(message)
        {

        }
        public InvalidCreadExceptions(string propertyname, string? message) : base(message)
        {
            PropertyName = propertyname;
        }
    }
}
