using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonAggregate.PersonPhone>> FindAllAsync();
        PersonPhone Insert(PersonPhone personPhone);
        void Delete(PersonPhone personPhone);
        PersonPhone Put(PersonPhone personPhone);
        PersonPhone Get(int id, string number, int typeId);
    }
}
