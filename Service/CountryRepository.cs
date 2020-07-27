using BookAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Service
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public BookDbContext BookDbContext { get { return Context as BookDbContext; } }
        public CountryRepository(BookDbContext bookDbContext) : base(bookDbContext)
        {

        }
        public Country GetCountryByAuthorId(int authorId)
        {
            AuthorRepsoitory authorRepsoitory = new AuthorRepsoitory(BookDbContext);
            Author author = authorRepsoitory.GetById(authorId);
            return (author != null) ? author.Country : null;
    
        }
    }
}
