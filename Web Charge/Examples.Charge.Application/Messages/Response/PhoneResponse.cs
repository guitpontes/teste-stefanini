using Examples.Charge.Application.Common.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Messages.Response
{
    public class PhoneResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string PhoneType { get; set; }
        public int PhoneTypeID { get; set; }
        public string Owner { get; set; }
    }
}
