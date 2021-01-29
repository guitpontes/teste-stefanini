using AutoMapper;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PhoneFacade : IPhoneFacade
    {
        private readonly IMapper _mapper;
        private readonly IPersonService _personService;
        private readonly IPersonPhoneService _personPhoneService;
        private readonly IPhoneNumberTypeService _phoneNumberTypeService;

        public PhoneFacade(IMapper mapper, IPersonPhoneService personPhoneService, IPersonService personService, IPhoneNumberTypeService phoneNumberTypeService)
        {
            this._mapper = mapper;
            this._personPhoneService = personPhoneService;
            _personService = personService;
            _phoneNumberTypeService = phoneNumberTypeService;
        }

        public IPersonPhoneService PersonPhoneService { get; }

        public void Delete(PhoneRequest request)
        {
            _personPhoneService.Delete(request.PersonId, request.Number, request.PhoneTypeId);
        }

        public async Task<IEnumerable<PhoneResponse>> FindAllAsync()
        {
            var phones = await _personPhoneService.FindAll();

            return _mapper.Map<IEnumerable<PhoneResponse>>(phones);
        }

        public PhoneResponse Insert(PhoneRequest request)
        {
            var person = _personService.Find(request.PersonId);
            var type = _phoneNumberTypeService.FindAllAsync().Result.FirstOrDefault(x => x.PhoneNumberTypeID == request.PhoneTypeId);
            var result = _personPhoneService.Insert(person, request.Number, type);

            return _mapper.Map<PhoneResponse>(result);
        }

        public PhoneResponse Put(PhoneRequest oldPhone, PhoneEditRequest request)
        {
            var phoneToEdit = _personPhoneService.Get(oldPhone.PersonId, oldPhone.Number, oldPhone.PhoneTypeId);
            var type = _phoneNumberTypeService.FindAllAsync().Result.Where(x => x.PhoneNumberTypeID == request.PhoneTypeId).FirstOrDefault();
            
            return _mapper.Map<PhoneResponse>(_personPhoneService.Put(phoneToEdit, request.Number, type));
        }
    }
}
