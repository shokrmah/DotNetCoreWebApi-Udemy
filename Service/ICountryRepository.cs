using BookAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Service
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country GetCountryByAuthorId(int authorId);
    }
}
