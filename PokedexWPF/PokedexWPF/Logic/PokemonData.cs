using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexWPF.Logic
{
    public struct PokemonData
    {
        public string Name { get; set; }
        public int EntryID { get; set; }

        public PokemonData(int entryID, string name) : this()
        {
            EntryID = entryID;
            Name = name;
        }
    }
}
