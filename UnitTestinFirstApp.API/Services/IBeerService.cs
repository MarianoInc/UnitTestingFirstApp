using System.Collections.Generic;
using UnitTestinFirstApp.API.Models;

namespace UnitTestinFirstApp.API.Services
{
    public interface IBeerService
    {
        public IEnumerable<Beer> Get();
        public Beer? Get(int id); 
    }
}
