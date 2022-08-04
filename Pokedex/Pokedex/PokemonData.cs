using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex
{
    public struct PokemonData
    {
        public string Name;
        public string EntryNumber;

        public PokemonData(string entryNumber, string name) : this()
        {
            EntryNumber = entryNumber;
            Name = name;
        }
    }
}
