using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Media.Imaging;
using System.IO;

namespace PokedexWPF.Logic
{
    public partial class Backend
    {
        private readonly string _dataAPIPokedex = "pokedex/";
        private readonly string _dataAPIPokemon = "pokemon/";
        private readonly string _dataAPISpecies = "pokemon-species/";

        private HttpClient _httpClient;
        private HttpClient _httpPngClient;

        private HashSet<string> _pokedex;
        private Dictionary<string, List<PokemonData>> _pokemon;
        public Dictionary<string, List<PokemonData>> Pokemon
        {
            get
            {
                if (_pokemon == null)
                {
                    return null;
                }
                return _pokemon.ToDictionary(entry => entry.Key,
                                               entry => entry.Value);
            }
        }

        public PokemonDetailsData LastReadDetails { get; set; }

        public Backend()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            _httpPngClient = new HttpClient();
            _httpPngClient.BaseAddress = new Uri("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/");
        }

        public async Task ReadShallowData()
        {
            _pokedex = new HashSet<string>();

            HttpResponseMessage response = await _httpClient.GetAsync(_dataAPIPokedex);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                JToken obj = JObject.Parse(responseBody)["results"];
                foreach (var item in obj)
                {
                    _pokedex.Add(item["name"].ToString());
                }
            }

            _pokemon = new Dictionary<string, List<PokemonData>>();

            foreach (string dex in _pokedex)
            {
                List<PokemonData> newData = new List<PokemonData>();
                response = await _httpClient.GetAsync(_dataAPIPokedex + dex);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    JToken obj = JObject.Parse(responseBody)["pokemon_entries"];
                    if(obj.HasValues)
                    {
                        foreach (var item in obj)
                        {
                            JToken entry = item["pokemon_species"];
                            if(entry.HasValues)
                            {
                                entry = entry["name"];
                                if (entry != null)
                                {
                                    newData.Add(new PokemonData((int)item["entry_number"], entry.ToString()));
                                }
                            }
                        }
                    }
                }
                await Task.Delay(250);
                _pokemon.Add(dex, newData);
            }
        }

        public async Task ReadPokemonDetails(string name)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_dataAPIPokemon + name);
            List<string> types = new List<string>();
            string habitat = "";
            string description = "";
            BitmapImage sprite = null;

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                JToken obj = JObject.Parse(responseBody)["types"];

                if(obj.HasValues)
                {
                    foreach (var item in obj)
                    {
                        JToken type = item["type"];
                        if(type.HasValues)
                        {
                            type = type["name"];
                            if(type != null)
                            {
                                types.Add(type.ToString());
                            }
                        }
                    }
                }

                obj = JObject.Parse(responseBody)["id"];
                if(obj != null)
                {
                    string spritePath = obj.ToString();
                    response = await _httpPngClient.GetAsync(spritePath + ".png");
                    if (response.IsSuccessStatusCode)
                    {
                        var bytes = await response.Content.ReadAsByteArrayAsync();
                        if (bytes != null && bytes.Count() != 0)
                        {
                            sprite = ToImage(bytes);
                        }
                    }
                }
            }
            else
            {
                LastReadDetails = null;
                return;
            }

            response = await _httpClient.GetAsync(_dataAPISpecies + name);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                JToken habitatObj = JObject.Parse(responseBody)["habitat"];
                if(habitatObj.HasValues)
                {
                    habitatObj = habitatObj["name"];
                    if (habitatObj != null)
                    {
                        habitat = habitatObj.ToString();
                    }
                }
                
                JToken desc = JObject.Parse(responseBody)["flavor_text_entries"];
                if (desc.HasValues)
                {
                    var allEn = desc.Where(d => 
                    d["language"].HasValues && 
                    d["language"]["name"] != null && 
                    d["language"]["name"].ToString().Equals("en")
                    ).ToList();

                    Random rand = new Random();
                    desc = allEn[rand.Next(0, allEn.Count() - 1)]["flavor_text"];
                    if(desc != null)
                    {
                        description = desc.ToString();
                    }
                }
            }
            else
            {
                LastReadDetails = null;
                return;
            }

            LastReadDetails = new PokemonDetailsData(description, types, habitat, sprite);
        }

        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
}
