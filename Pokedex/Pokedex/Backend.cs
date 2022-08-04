using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pokedex
{
    public partial class Backend
    {
        private readonly string _dataAPIPokedexi = "pokedex/";

        private HttpClient _httpClient;

        private HashSet<string> _pokedex;
        private Dictionary<string, List<PokemonData>> _pokemon;
        public Dictionary<string, List<PokemonData>> Pokemon
        {
            get {
                if (_pokemon == null)
                {
                    return null;
                }
                return _pokemon.ToDictionary(entry => entry.Key,
                                               entry => entry.Value); 
            }
        }

        public Backend()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }

        public async Task ReadShallowData()
        {
            _pokedex = new HashSet<string>();

            HttpResponseMessage response = await _httpClient.GetAsync(_dataAPIPokedexi);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                JToken obj = JObject.Parse(responseBody)["results"];
                foreach(var item in obj)
                {
                    _pokedex.Add(item["name"].ToString());
                }
            }

            _pokemon = new Dictionary<string, List<PokemonData>>();

            foreach (string dex in _pokedex)
            {
                List<PokemonData> newData = new List<PokemonData>();
                response = await _httpClient.GetAsync(_dataAPIPokedexi + dex);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    JToken obj = JObject.Parse(responseBody)["pokemon_entries"];
                    foreach (var item in obj)
                    {
                        newData.Add(new PokemonData(item["entry_number"].ToString(), item["pokemon_species"]["name"].ToString()));
                    }
                }
                await Task.Delay(500);
                _pokemon.Add(dex, newData);
                break;
            }
        }
    }
}
