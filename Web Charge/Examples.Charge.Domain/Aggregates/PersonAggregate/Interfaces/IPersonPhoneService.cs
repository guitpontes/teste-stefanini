using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        PersonPhone Insert(Person person, string number, PhoneNumberType type);
        void Delete(int id, string number, int typeId);
        PersonPhone Put(PersonPhone phoneToEdit, string number, PhoneNumberType type);
        Task<IEnumerable<PersonPhone>> FindAll();
        PersonPhone Get(int id, string number, int typeId);
    }
}
