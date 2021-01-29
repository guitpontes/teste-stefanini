using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPhoneFacade
    {
        PhoneResponse Insert(PhoneRequest request);
        PhoneResponse Put(PhoneRequest oldPhone, PhoneEditRequest request);
        void Delete(PhoneRequest request);
        Task<IEnumerable<PhoneResponse>> FindAllAsync();
    }
}
