using BookAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Service
{
    public class AuthorRepsoitory : Repository<Author>, IAuthorReprository
    {
        public BookDbContext BookDbContext { get { return Context as BookDbContext; } }
        public AuthorRepsoitory(BookDbContext bookDbContext) : base(bookDbContext)
        {

        }

        public IEnumerable<Author> GetAuthorsByCountryId(int countryId)
        {
            return GetAll().Where(author => author.Country.Id == countryId);
        }

    }
}
