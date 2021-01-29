using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public void Delete(int id, string number, int typeId)
        {
            PersonPhone phoneToDelete = _personPhoneRepository.Get(id, number, typeId);

            _personPhoneRepository.Delete(phoneToDelete);
        }

        public async Task<IEnumerable<PersonPhone>> FindAll()
        {
            return await _personPhoneRepository.FindAllAsync();
        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public PersonPhone Insert(Person person, string number, PhoneNumberType type)
        {
            PersonPhone phone = new PersonPhone { PhoneNumber = number, 
                                                  Person = person, 
                                                  PhoneNumberType = type,
                                                  PhoneNumberTypeID = type.PhoneNumberTypeID };

            return _personPhoneRepository.Insert(phone);
        }

        public PersonPhone Put(PersonPhone phoneToEdit, string number, PhoneNumberType type)
        {
            if (phoneToEdit != null)
            {
                var newPhone = new PersonPhone
                {
                    BusinessEntityID = phoneToEdit.BusinessEntityID,
                    Person = phoneToEdit.Person,
                    PhoneNumber = number,
                    PhoneNumberType = type,
                    PhoneNumberTypeID = type.PhoneNumberTypeID
                };
                this._personPhoneRepository.Delete(phoneToEdit);

                phoneToEdit.PhoneNumber = number;
                phoneToEdit.PhoneNumberType = type;
                phoneToEdit.PhoneNumberTypeID = type.PhoneNumberTypeID;
            }
            return _personPhoneRepository.Put(phoneToEdit);
        }

        public PersonPhone Get(int id, string number, int typeId)
        {
            return _personPhoneRepository.Get(id, number, typeId);
        }
    }
}
