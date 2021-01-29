using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Messages.Request
{
    public class PhoneRequest
    {
        public int PersonId { get; set; }
        public int PhoneTypeId { get; set; }
        public string Number { get; set; }
    }
}
