using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Service
{
    public interface IUnitOfWork : IDisposable
    {
        public ICountryRepository Countries { get; }
        public int Save();
    }
}
