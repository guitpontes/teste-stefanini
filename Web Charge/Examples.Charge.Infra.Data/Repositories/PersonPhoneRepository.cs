using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Delete(PersonPhone personPhone)
        {
            try
            {
                _context.PersonPhone.Remove(personPhone);

                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone.Include(m => m.PhoneNumberType).Include(x => x.Person));

        public PersonPhone Get(int id, string number, int typeId)
        {
            return _context.PersonPhone.Include(x => x.PhoneNumberType).Include(x => x.Person).Where(x => x.BusinessEntityID == id 
                                                                              && x.PhoneNumber == number 
                                                                              && x.PhoneNumberTypeID == typeId).FirstOrDefault();
        }

        public PersonPhone Insert(PersonPhone personPhone)
        {
            try
            {                
                var result = _context.PersonPhone.Add(personPhone);

                _context.SaveChanges();

                return result.Entity;
            }
            catch
            {
                throw;
            }
        }

        public PersonPhone Put(PersonPhone personPhone)
        {
            var result = _context.PersonPhone.Add(personPhone);

            _context.SaveChanges();

            return result.Entity;
        }
    }
}
