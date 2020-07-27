using BookAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Service
{
    interface IAuthorReprository : IRepository<Author>
    {
        IEnumerable<Author> GetAuthorsByCountryId(int countryId);
    }
}
