using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PokedexWPF.Logic
{
    public class PokemonDetailsData
    {
        public string Habitat;
        public List<string> Types;
        public string Description;
        public BitmapImage Sprite;

        public PokemonDetailsData(string description, List<string> types, string habitat, BitmapImage sprite)
        {
            Description = description;
            Types = types;
            Habitat = habitat;
            Sprite = sprite;
        }
    }
}
