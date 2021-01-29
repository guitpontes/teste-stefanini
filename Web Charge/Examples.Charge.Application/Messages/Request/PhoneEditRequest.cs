using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Messages.Request
{
    public class PhoneEditRequest
    {
        public int PhoneTypeId { get; set; }
        public string Number { get; set; }
    }
}
