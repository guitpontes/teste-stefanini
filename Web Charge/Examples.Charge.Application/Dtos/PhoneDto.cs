using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Dtos
{
    public class PhoneDto
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneTypeDto PhoneType { get; set; }
    }
}
