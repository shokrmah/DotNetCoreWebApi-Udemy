using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookDbContext bookContext;

        public UnitOfWork(BookDbContext context)
        {
            bookContext = context;
            Countries = new CountryRepository(bookContext);
        }

        public ICountryRepository Countries { get; private set; }

        public void Dispose()
        {
            bookContext.Dispose();
        }

        public int Save()
        {
            return bookContext.SaveChanges();
        }
    }
}
