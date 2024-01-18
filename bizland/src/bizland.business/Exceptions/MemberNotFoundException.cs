using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.business.Exceptions
{
    public class MemberNotFoundException:Exception
    {
        public string PropertyName {  get; set; }
        public MemberNotFoundException()
        {
            
        }
        public MemberNotFoundException(string? message):base(message) 
        {
            
        }
        public MemberNotFoundException(string propertyname,string? message):base(message)
        {
            PropertyName = propertyname;
        }
    }
}
