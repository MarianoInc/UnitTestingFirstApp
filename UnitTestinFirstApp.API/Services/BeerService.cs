using System.Collections.Generic;
using System.Linq;
using UnitTestinFirstApp.API.Models;

namespace UnitTestinFirstApp.API.Services
{
    public class BeerService : IBeerService
    {
        private List<Beer> _beers = new List<Beer>()
        {
            new Beer()
            {
                Id = 1,
                Name = "Corona",
                Brand = "Modelo"
            },
            new Beer()
            {
                Id = 2,
                Name = "Pikantus",
                Brand = "Erdinger"
            }
        };        

        public IEnumerable<Beer> Get() => _beers;

        public Beer? Get(int id) => _beers.FirstOrDefault(b => b.Id == id);
    }
}
